using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHelp.Mail;
using MySql.Data.MySqlClient;

namespace DataHelp.Services
{
	public static class RegisterService
	{
		private static readonly string dbConnectionString = "Server=remotemysql.com;Database=POs3de1PII;Uid=POs3de1PII;Pwd=TSij2DKOIg;";
		public static bool RegisterUser(string email, string username, string password)
		{
			bool valid = MailService.SendMailRegisterSuccess(email, username);
			if (!valid) { return false; }

			MySqlConnection connection = new MySqlConnection(dbConnectionString);
			connection.Open();

			string sqlCommand = "INSERT INTO Users(email, username, user_password, register_date) VALUES(@email, @username, @user_password, @register_date)";
			MySqlCommand command = new MySqlCommand(sqlCommand, connection);
			command.Parameters.AddWithValue("@email", email);
			command.Parameters.AddWithValue("@username", username);
			command.Parameters.AddWithValue("@user_password", password);
			command.Parameters.AddWithValue("@register_date", DateTime.Now.ToString());

			command.ExecuteNonQuery();

			connection.Close();
			return true;

		}
	}
}
