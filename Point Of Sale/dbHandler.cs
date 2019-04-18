using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace Point_Of_Sale
{
	public class dbHandler
	{

		/// <summary>
		/// Gets the existing list of distributors from PoS.db
		/// </summary>
		/// <returns></returns>
		public static string ReadDistributors()
		{
			using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				var output = cnn.Query<string>("select * from Distributors", new DynamicParameters());
				return output.ToString();
			}
		}

		/// <summary>
		/// Inserts a new distributor entry into the PoS.db
		/// </summary>
		/// <param name="DistName">Name of distributor</param>
		/// <param name="ContactName">Name of contact person for the distributor</param>
		/// <param name="ContactNumber">Number of contact person for the distributor</param>
		public static void InsertDistributor(string DistName, string ContactName, string ContactNumber)
		{
			//Load the connection in using statement to ensure it's closed when done here
			using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
			{
				connection.Open();

				SQLiteCommand command = new SQLiteCommand("INSERT INTO Distributors (CompanyName, ContactName, ContactNumber) VALUES (?, ?, ?)", connection);
				command.Parameters.AddWithValue("CompanyName", DistName);
				command.Parameters.AddWithValue("ContactName", ContactName);
				command.Parameters.AddWithValue("ContactNumber", ContactNumber);
				command.CommandTimeout = 3;

				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					if(ex.Message.StartsWith("constraint failed\r\nUNIQUE constraint failed:"))
					{
						
					}

					else if (ex.Message.StartsWith("database is locked\r\ndatabase is locked"))
					{

					}

					else
					{
						throw new Exception(ex.Message);
					}
				}


				connection.Close();
			}
		}

		private static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
