using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelp.Chat
{
    public static class ChatServices
    {
        private static readonly string dbConnectionString = "Server=remotemysql.com;Database=POs3de1PII;Uid=POs3de1PII;Pwd=TSij2DKOIg;";

		public static int GetIdByUsername(string username)
		{
			MySqlConnection connection = new MySqlConnection(dbConnectionString);
			connection.Open();

			string sqlCommand = $"SELECT id, username FROM Users WHERE username = '{username}'";
			MySqlCommand command = new MySqlCommand(sqlCommand, connection);

			MySqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				int id = reader.GetInt16(0);
				connection.Close();
				return id;
			}

			connection.Close();
			return 0;
		}

		public static void SendMessage(int sender_id, int receiver_id, string message)
        {

			MySqlConnection connection = new MySqlConnection(dbConnectionString);
			connection.Open();

			string sqlCommand = "INSERT INTO Messages(sender_id, receiver_id, send_date, message, seen) VALUES(@sender_id, @receiver_id, @send_date, @message, @seen)";
			MySqlCommand command = new MySqlCommand(sqlCommand, connection);
			command.Parameters.AddWithValue("@sender_id", sender_id);
			command.Parameters.AddWithValue("@receiver_id", receiver_id);
			command.Parameters.AddWithValue("@send_date", DateTime.Now.ToString());
			command.Parameters.AddWithValue("@message", message);
			command.Parameters.AddWithValue("@seen", 0);

			command.ExecuteNonQuery();

			connection.Close();
		}

	}
}

