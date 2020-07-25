using DataHelp.Global;
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
	/// Interaction logic for ChatWindow.xaml
	/// </summary>
	public partial class ChatWindow : Window
	{
		public ChatWindow()
		{
			InitializeComponent();
			LblUsername.Text = $"{CurrentUser.Username}, '{ CurrentUser.Id}' ";
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
	}
}
