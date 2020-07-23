using Chat_Project.Windows;
using System;
using System.Collections.Generic;
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
		}

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
			WindowRegister windowRegister = new WindowRegister();
			windowRegister.Show();
			this.Hide();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForgotPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
			WindowForgottenPass windowForgottenPass = new WindowForgottenPass();
			windowForgottenPass.Show();
			this.Hide();

        }
    }
}
