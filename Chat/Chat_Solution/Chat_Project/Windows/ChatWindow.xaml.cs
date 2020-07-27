using DataHelp.Chat;
using DataHelp.Friends;
using DataHelp.Global;
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
	/// Interaction logic for ChatWindow.xaml
	/// </summary>
	public partial class ChatWindow : Window
	{
		public ChatWindow()
		{
			InitializeComponent();
			PopulateInfo();

		}

        private void PopulateInfo()
        {
			LblUsername.Text = $"{CurrentUser.Username}, '{ CurrentUser.Id}' ";

			PopulateService.PopulateFriendsList();
			LvFriends.ItemsSource = Friends.FriendsList;
		}

        private void Button_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
			string friend_username = LvFriends.SelectedItem.ToString();
			int friend_id = ChatServices.GetIdByUsername(friend_username);

			ChatServices.SendMessage(CurrentUser.Id, friend_id, TbMessage.Text);
			TbMessage.Text = "";
		}
    }
}
