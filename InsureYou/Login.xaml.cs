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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        
        public Login()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Login_Loaded);

        }
        void Login_Loaded(object sender, RoutedEventArgs e)
        {
            pass.Focus();
        }


        public String[] getCredintials() {
            String[] cred = new String[2];
            cred[0] = id.Text;
            cred[1] = pass.Password;

            return cred;
        }
        
        }
}
