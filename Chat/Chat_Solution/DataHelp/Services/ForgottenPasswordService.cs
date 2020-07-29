using DataHelp.Mail;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelp.Services
{
    public static class ForgottenPasswordService
    {

        private static readonly string dbConnectionString = "Server=remotemysql.com;Database=POs3de1PII;Uid=POs3de1PII;Pwd=TSij2DKOIg;";

        public static void ResetPassword(string email)
        {
            MySqlConnection connection = new MySqlConnection(dbConnectionString);
            connection.Open();

            string sqlCommand = $"UPDATE Users SET user_password = @password WHERE email = @email";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            command.Parameters.AddWithValue("@email", email);

            string newPassword = GeneratePassword();
            command.Parameters.AddWithValue("@password", newPassword);
            command.ExecuteNonQuery();

            MailService.SendMailForgottenPassword(email, newPassword);

        }

        public static string GeneratePassword()
        {
            string pass = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random Rdpass = new Random();
            string password = String.Empty;
            for (int i = 0; i < 8; i++)
            {
                password += pass[Rdpass.Next(0, pass.Length)];
            }
            return password;
        }


    }
}
