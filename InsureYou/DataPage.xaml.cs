using InsureModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        List<InsureInfo> all;
        public DataPage()
        {
            InitializeComponent();
            all = InsureInfo.GetAll();
        }
        public void load_All()
        {

            all = InsureInfo.GetAll();
            this.listView.ItemsSource = all;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView.SelectedIndex == -1) { System.Windows.Forms.MessageBox.Show("Select an item first."); return; }
            int index = this.listView.SelectedIndex;
            AddInsure add = new AddInsure();
            add.id.Text = all[index].ID.ToString();
            add.provider.Text = all[index].Provider;
            add.date.Text = all[index].ExpireDate.ToString();
            add.button.Content = "Edit";
            add.ShowDialog();
            load_All();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddInsure add = new AddInsure();
            add.button.Content = "ADD";
            add.ShowDialog();
            load_All();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView.SelectedIndex == -1) { System.Windows.Forms.MessageBox.Show("Select an item first."); return; }
            int index = this.listView.SelectedIndex;
            int intid = all[index].ID;
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes) {
                InsureInfo.Delete(intid);
                load_All();
            }
            
        }

        

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView.SelectedIndex == -1) { System.Windows.Forms.MessageBox.Show("Select an item first."); return; }
            int index = this.listView.SelectedIndex;
            InsureInfo current = all[index];
            string detail = string.Format("Insurance ID= {0}, Provider={1}, Expire Date={2}, Total worth={3}, Associated Item={4}", current.ID, current.Provider, current.ExpireDate, current.TotalWorth, "50");
            infoDialog ii = new infoDialog("Details",detail);
            ii.ShowDialog();

        }
    }
}
