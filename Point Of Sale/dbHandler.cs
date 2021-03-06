﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Point_Of_Sale
{
	//TODO: Copy PoS.db before and after each operation for consistent backups, just in case the db is caught in eternal locked limbo
	//TODO: Restore backup PoS.db in the event of issues

	/// <summary>
	/// Handles operations with PoS.db
	/// </summary>
	public class dbHandler
	{

		/// <summary>
		/// Gets the existing list of distributors from PoS.db
		/// </summary>
		/// <returns>Return value will have rows if successful.</returns>
		public static DataTable ReadDistributors()
		{
			DataTable output = new DataTable(); //DataTable to be returned

			//Setup columns in the DataTable
			output.Columns.Add("Id");
			output.Columns.Add("Company_Name");
			output.Columns.Add("Contact_Name");
			output.Columns.Add("Contact_Number");

			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				SQLiteCommand command = new SQLiteCommand("SELECT * FROM Distributors", connection);

				try
				{
					connection.Open();
					
					SQLiteDataReader reader = command.ExecuteReader(); //Begin reading the first row

					DataRow row;

					//While there is a line to read
					while (reader.Read())
					{
						//Copy the values from the PoS.db row to the DataTable row
						row = output.NewRow();
						row[0] = reader["Id"];
						row[1] = reader["Company_Name"];
						row[2] = reader["Contact_Name"];
						row[3] = reader["Contact_Number"];

						output.Rows.Add(row); //Add the row to the DataTable
					}
				}

				catch(Exception ex)
				{
					throw new Exception(ex.Message);
				}

				finally
				{
					connection.Close();
				}

				return output;
			}
		}

		/// <summary>
		/// Gets the existing list of distributors, returning only the name of each distributor
		/// </summary>
		/// <returns>Return value will have rows of distributor names if successful.</returns>
		public static DataTable ReadDistributorNames()
		{
			DataTable output = new DataTable(); //DataTable to be returned

			//Setup columns in the DataTable
			output.Columns.Add("Id");
			output.Columns.Add("Company_Name");

			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				SQLiteCommand command = new SQLiteCommand("SELECT Id, Company_Name FROM Distributors", connection);

				try
				{
					connection.Open();

					SQLiteDataReader reader = command.ExecuteReader();

					DataRow row;

					while (reader.Read())
					{
						row = output.NewRow();
						row[0] = reader["Id"];
						row[1] = reader["Company_Name"];

						output.Rows.Add(row);
					}
				}

				catch (Exception ex)
				{

					throw new Exception(ex.Message);
				}

				finally
				{
					connection.Close();
				}

				return output;
			}
		}

		/// <summary>
		/// Inserts a new distributor entry into the PoS.db
		/// </summary>
		/// <param name="DistName">Name of distributor</param>
		/// <param name="ContactName">Name of contact person for the distributor</param>
		/// <param name="ContactNumber">Number of contact person for the distributor</param>
		public static bool InsertDistributor(string DistName, string ContactName, string ContactNumber)
		{
			//This check can probably be housed in it's own method
			if (File.Exists(Directory.GetCurrentDirectory() + @"\PoS.db"))
			{
				//Load the connection in using statement to ensure it's closed when done here
				using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
				{
					//Setup the command to the db
					SQLiteCommand command = new SQLiteCommand("INSERT INTO Distributors (Company_Name, Contact_Name, Contact_Number) VALUES (?, ?, ?)", connection);
					command.Parameters.AddWithValue("Company_Name", DistName);
					command.Parameters.AddWithValue("Contact_Name", ContactName);
					command.Parameters.AddWithValue("Contact_Number", ContactNumber);
					command.CommandTimeout = 3;

					//I did it. Instead of having the Open() and the ExecuteNonQuery() sitting on top of eachother like before, I've realized you can try within a try (insert Xzibit meme)
					try
					{
						//This will catch here if the connection did not open
						connection.Open();

						//If the connection was opened, execute the INSERT
						try
						{
							command.ExecuteNonQuery();
						}

						//Handle any exceptions while executing the INSERT.
						catch (Exception ex)
						{
							//Handle(ish) a constraint failure. At this moment, Id is the only constrained field.
							if (ex.Message.StartsWith("constraint failed\r\nUNIQUE constraint failed:"))
							{
								MessageBox.Show("Unable to insert entry into the database. An attempt to insert a non-unique value where a unique value is required was stopped", "Non-unique value", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}

							//Handle(ish) a locked database.
							else if (ex.Message.StartsWith("database is locked\r\ndatabase is locked"))
							{
								MessageBox.Show("Unable to insert entry into the database. The database is currently locked. This is likely because there is a change pending on the database, or an app crashed while making changes to the database.", "Database locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}

							//Unhandled exception.
							else
							{
								throw new Exception(ex.Message);
							}

							//Close connection, and return false since command didn't execute successfully.
							connection.Close();
							return false;
						}

						finally
						{
							connection.Close();
						}

						//Since you can't use return statements within finally, if it gets here, I'm almost 100% sure it was successful.
						return true;
					}

					//Connection did not open
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error opening connection to PoS.db. Unable to make changes.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						connection.Close();
						return false;
					}
				}
			}

			//PoS.db does NOT exist
			else
			{
				//TODO: Restore backup if the program paths to this point.
				MessageBox.Show("The file PoS.db does not exist in the current directory. Ensure PoS.db exists in the same folder as \"Point Of Sale.exe\"", "Unable to open PoS.db", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		/// <summary>
		/// Deletes a specific row from the Distributors table based on the Id
		/// </summary>
		/// <param name="Id">The Id of the distributor to delete</param>
		public static void DeleteDistributor(string Id)
		{
			//This check can probably be housed in it's own method
			if (File.Exists(Directory.GetCurrentDirectory() + @"\PoS.db"))
			{
				using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
				{
					SQLiteCommand command = new SQLiteCommand("DELETE FROM Distributors WHERE Id=(?)", connection);
					command.Parameters.AddWithValue("Id", Id);
					command.CommandTimeout = 3;

					try
					{
						connection.Open();

						try
						{
							command.ExecuteNonQuery();
						}

						catch (Exception ex)
						{
							throw new Exception(ex.Message);
						}

						finally
						{
							connection.Close();
						}
					}

					//Connection did not open
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error opening connection to PoS.db. Unable to make changes.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						connection.Close();
					}
				}
			}

			else
			{
				//TODO: Restore backup if the program paths to this point.
				MessageBox.Show("The file PoS.db does not exist in the current directory. Ensure PoS.db exists in the same folder as \"Point Of Sale.exe\"", "Unable to open PoS.db", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static DataTable ReadItemsByDistributor(int DistributorID)
		{
			DataTable output = new DataTable(); //DataTable to be returned

			//Setup columns in the DataTable
			output.Columns.Add("Id");
			output.Columns.Add("Item_Name");
			output.Columns.Add("Distributor_Id");
			output.Columns.Add("Purchase_Price");

			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				SQLiteCommand command = new SQLiteCommand("SELECT * FROM Distributor_Items WHERE (Distributor_Id = ?)", connection);
				command.Parameters.AddWithValue("Distributor_Id", DistributorID.ToString());

				try
				{
					connection.Open();

					SQLiteDataReader reader = command.ExecuteReader(); //Begin reading the first row

					DataRow row;

					//While there is a line to read
					while (reader.Read())
					{
						//Copy the values from the PoS.db row to the DataTable row
						row = output.NewRow();
						row[0] = reader["Id"];
						row[1] = reader["Item_Name"];
						row[2] = reader["Distributor_Id"];
						row[3] = reader["Purchase_Price"];

						output.Rows.Add(row); //Add the row to the DataTable
					}
				}

				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				finally
				{
					connection.Close();
				}

				return output;
			}
		}

		/// <summary>
		/// Provides a connection string
		/// </summary>
		/// <param name="id">If a different id is specified in App.config</param>
		/// <returns>The connection string</returns>
		private static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
