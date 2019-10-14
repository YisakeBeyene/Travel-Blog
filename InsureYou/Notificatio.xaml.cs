using System;
using System.Collections.Generic;
using System.Windows.Controls;
using InsureModel;

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for Notificatio.xaml
    /// </summary>
    public partial class Notificatio : Page
    {
        public Notificatio()
        {
            InitializeComponent();
            List<Notification> all = Notification.GetAll();
            listbox.ItemsSource = all;
        }

       
    }
}
