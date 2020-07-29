using DataHelp.Services;
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

namespace Chat_Project.Windows
{
    /// <summary>
    /// Interaction logic for WindowForgottenPass.xaml
    /// </summary>
    public partial class WindowForgottenPass : Window
    {
        public WindowForgottenPass()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ForgottenPasswordService.ResetPassword(TbEmail.Text);
            MessageBox.Show("You got a new email");
            WindowLogin windowLogin = new WindowLogin();
            windowLogin.Show();
            this.Hide();
        }

        private void TbEmail_MouseEnter(object sender, MouseEventArgs e)
        {
            TbEmail.Text = "";
            TbEmail.Foreground = Brushes.Black;
        }
    }
}
