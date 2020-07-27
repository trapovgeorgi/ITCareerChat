using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataHelp.Friends;
using System.Threading.Tasks;

namespace DataHelp.Services
{
    public static class PopulateService
    {
		private static readonly string dbConnectionString = "Server=remotemysql.com;Database=POs3de1PII;Uid=POs3de1PII;Pwd=TSij2DKOIg;";

		public static void PopulateFriendsList()
		{
			MySqlConnection connection = new MySqlConnection(dbConnectionString);
			connection.Open();

			string sqlCommand = $"SELECT username FROM Users";
			MySqlCommand command = new MySqlCommand(sqlCommand, connection);

			MySqlDataReader reader = command.ExecuteReader();

			Friends.Friends.FriendsList = new List<string>();
			while (reader.Read())
			{ 

				Friends.Friends.FriendsList.Add(reader.GetString(0));
			}
			connection.Close();
		}



	}
}
