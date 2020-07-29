using Chat_Project.Windows;
using DataHelp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat_Project
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            CheckUserLoginInfo();
        }

        private void CheckUserLoginInfo()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string loginInfoPath = $"{documentsPath}\\trianglelogin.txt";

            if (File.Exists(loginInfoPath))
            {
                List<string> lines = File.ReadAllLines(loginInfoPath).ToList();
                TbUsername.Text = lines[0];
                TbPassword.Password = lines[1];
            }
            else
            {

            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister windowRegister = new WindowRegister();
            windowRegister.Show();
            this.Hide();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool logged = LoginService.LoginUser(TbUsername.Text, TbPassword.Password);

            if (logged)
            {
                if (RbKeep.IsChecked == true)
                {
                    SaveLoginInfo();
                }
                ChatWindow chatWindow = new ChatWindow();
                chatWindow.Show();
                this.Hide();
            }
            else
            {
                LblSignIn.Foreground = Brushes.Red;
                LblSignIn.Text = "User not found!";
            }

        }

        private void SaveLoginInfo()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string loginInfoPath = $"{documentsPath}\\trianglelogin.txt";
            string username = TbUsername.Text;
            string password = TbPassword.Password;
            List<string> lines = new List<string>();
            lines.Add(username);
            lines.Add(password);
            if (!File.Exists(loginInfoPath))
            {
                File.AppendAllLines(loginInfoPath, lines.ToArray());
            }
            else
            {
                File.WriteAllLines(loginInfoPath, lines.ToArray());
            }
        }

        private void BtnForgotPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowForgottenPass windowForgottenPass = new WindowForgottenPass();
            windowForgottenPass.Show();
            this.Hide();
        }
    }
}
