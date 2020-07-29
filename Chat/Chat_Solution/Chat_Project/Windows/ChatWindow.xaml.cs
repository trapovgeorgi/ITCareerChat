using DataHelp.Chat;
using DataHelp.Friends;
using DataHelp.Global;
using DataHelp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        ObservableCollection<MessageModel> messages;
        private Timer tmCheckMessages = new Timer();
        private Timer tmVisualiseMessages = new Timer();
        private bool timerStarted = false;
        public ChatWindow()
        {
            InitializeComponent();
            PopulateInfo();
            tmCheckMessages.Elapsed += new ElapsedEventHandler(ChangeMessages);
            tmCheckMessages.Interval = 1000;
            
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

        private void LvFriends_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            if (!timerStarted)
            {
                tmCheckMessages.Start();
            }

            string friend_username = LvFriends.SelectedItem.ToString();
            LblChatFriend.Text = "Chatting with: " + friend_username;
            if (CurrentUser.Username == friend_username)
            {
                LblChatFriend.Text = "Chatting with yourself (psycho)";
            }

        }

        private async void ChangeMessages(object sender, ElapsedEventArgs e)
        {
            Action action = () =>
            {
                string username = LvFriends.SelectedItem.ToString();
                messages = ChatServices.GetAllMessages(username);
                LvChat.ItemsSource = messages;

            };

            await Task.Run(() => Dispatcher.Invoke(action));

        }
    }
}
