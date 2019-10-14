using System.Windows;
using System.Windows.Controls;
using ViewModel;
using MySql.Data.MySqlClient;
using System.Windows.Input;

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountViewModel accountViewModel = new AccountViewModel();
        Login current;
        public MainWindow()
        {
            InitializeComponent();
            current = new Login();
            main.Content = current;
            current.DataContext = accountViewModel;
            
        }




        private void new_Click(object sender, RoutedEventArgs e)
        {

            string[] aa = current.getCredintials();
            if (aa[0].Equals(null) || aa[0].Equals("") || aa[1].Equals(null) || aa[1].Equals(""))
            {
                return;
            }
            if (aa[0].Equals("admin") && aa[1].Equals("admin"))
            {
                HomeView home = new HomeView();
                home.Show();

                this.Close();
            }
            else
            {
                infoDialog ii = new infoDialog("Login", "Incorrect ID or Password :(");
                ii.ShowDialog();
               
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string[] aa = current.getCredintials();
                if (aa[0].Equals(null) || aa[0].Equals("") || aa[1].Equals(null) || aa[1].Equals(""))
                {
                    return;
                }
                if (aa[0].Equals("admin") && aa[1].Equals("admin"))
                {
                    HomeView home = new HomeView();
                    home.Show();

                    this.Close();
                }
                else
                {
                    infoDialog ii = new infoDialog("Login", "Incorrect ID or Password :(");
                    ii.ShowDialog();

                }

            }
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
