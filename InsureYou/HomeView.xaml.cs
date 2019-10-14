using System;
using System.Windows;
using InsureModel;
using System.Collections.Generic;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Threading;

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        List<InsureInfo> all;
        DataPage data = new DataPage();
        Dashboard dash = new Dashboard();



        public HomeView()
        {
            InitializeComponent();
            load_All();
            content.Content = dash;
            var t = new Thread(() => notificationGetter(IconNotificatio, TextNotifictio));
            int count = Notification.GetCount();
            if (count > 0)
            {
                IconNotificatio.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xB0, 0x39, 0x39));
                TextNotifictio.Text = String.Format($"{count}");

            }
            
        }
        public void load_All() {
            
             all = InsureInfo.GetAll();
            data.listView.ItemsSource = all;
             
        }

       
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddInsure add = new AddInsure();
            add.button.Content = "ADD";
            add.ShowDialog();
            load_All();
        }
        private void listView_Selected(object sender, RoutedEventArgs e)
        {
            
             
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure?", "Quit", System.Windows.MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void ButtonData_Click(object sender, RoutedEventArgs e)
        {
            content.Content = data;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            content.Content = dash;
        }

        private void ButtonNotification_Click(object sender, RoutedEventArgs e)
        {
            Notificatio notificatio = new Notificatio();
            content.Content = notificatio;

            IconNotificatio.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
            TextNotifictio.Text = String.Format("");
        }
        public void notificationGetter(PackIcon IconNotificatio, TextBlock TextNotifictio)
        {
            this.Dispatcher.Invoke(() =>
            {


                
                    int count = Notification.GetCount();
                    if (count > 0)
                    {
                        IconNotificatio.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xB0, 0x39, 0x39));
                        TextNotifictio.Text = String.Format($"{count}");
                    }
                    //Thread.Sleep(1000000000);

                
                
            });
        }

        

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            content.Content = help;

        }
    }
    

}
