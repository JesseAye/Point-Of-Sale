using Dapper;
using System;
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
		/// <returns></returns>
		public static string ReadDistributors()
		{
			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				var output = connection.Query<string>("SELECT * FROM Distributors", new DynamicParameters());
				return output.ToString();
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
			//Load the connection in using statement to ensure it's closed when done here
			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				//Setup the command to the db
				SQLiteCommand command = new SQLiteCommand("INSERT INTO Distributors (CompanyName, ContactName, ContactNumber) VALUES (?, ?, ?)", connection);
				command.Parameters.AddWithValue("CompanyName", DistName);
				command.Parameters.AddWithValue("ContactName", ContactName);
				command.Parameters.AddWithValue("ContactNumber", ContactNumber);
				command.CommandTimeout = 3;

				// At first, I had the Open(), ExecuteNonQuery(), and Close() in a single try block, but that just seems dangerous. Is it worth it to open the connection in a try block?
				try
				{
					//Lets make sure the file exists first. This also ensures that a blank PoS.db will not be generated in lieu of an existing PoS.db
					if (File.Exists(Directory.GetCurrentDirectory() + @"\PoS.db"))
					{
						connection.Open();
					}

					else
					{
						//TODO: Restore backup if the program paths to this point.
						MessageBox.Show("The file PoS.db does not exist in the current directory. Ensure PoS.db exists in the same folder as \"Point Of Sale.exe\"", "Unable to open PoS.db", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
				}

				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				//execute the INSERT
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

				//Close connection, and return true since command executed successfully.
				connection.Close();
				return true;
			}
		}

		private static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
