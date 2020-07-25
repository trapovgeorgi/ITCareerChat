using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelp.Services
{
	public static class LoginService
	{
		private static readonly string dbConnectionString = "Server=remotemysql.com;Database=POs3de1PII;Uid=POs3de1PII;Pwd=TSij2DKOIg;";

		public static bool LoginUser(string username, string password)
		{
			MySqlConnection connection = new MySqlConnection(dbConnectionString);
			connection.Open();

			string sqlCommand = $"SELECT username, user_password FROM Users WHERE username = '{username}'";
			MySqlCommand command = new MySqlCommand(sqlCommand, connection);

			MySqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				if (username == reader.GetString(0))
				{
					if (password == reader.GetString(1))
					{
						return true;
					}
				}

			}

			return false;
		}
	}
}
