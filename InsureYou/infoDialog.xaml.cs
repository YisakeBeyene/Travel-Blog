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

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for infoDialog.xaml
    /// </summary>
    public partial class infoDialog : Window
    {
        public infoDialog(String Title, String Content)
        {
            InitializeComponent();
            title.Text = Title;
            content.Text = Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
