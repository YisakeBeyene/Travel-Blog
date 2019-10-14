using System;
using System.Windows;
using InsureModel;
namespace InsureYou
{
    /// <summary>
    /// Interaction logic for AddInsure.xaml
    /// </summary>
    public partial class AddInsure : Window
    {
        public AddInsure()
        {
            InitializeComponent();
            if (button.Content.ToString().Equals("Edit")) {
                item.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idint;
            int.TryParse( id.Text.ToString(),out idint);
            int worth;
            int.TryParse(id.Text.ToString(), out worth);
            DateTime expDate = DateTime.Now;
            String prov = provider.Text.ToString();
            String itemID = item.Text.ToString();
            if (date.SelectedDate != null)
            {

                expDate = (DateTime)date.SelectedDate;
            }
            if (String.IsNullOrWhiteSpace(prov) || String.IsNullOrWhiteSpace(itemID))
            {
                MessageBox.Show("Fields must be field out");
                return;
            }
            if (button.Content.ToString().Equals("ADD"))
            {
                
                

                //MessageBox.Show(expDate.ToString());
                InsureInfo.Add(prov, expDate, itemID,worth);
                MessageBox.Show("New Item Added!");
                this.Close();
            }
            else if (button.Content.ToString().Equals("Edit"))
            {

                InsureInfo.Edit(idint,prov, expDate, "");
                infoDialog ii = new infoDialog("Insurance Update", "You have successfully Updated your data");
                ii.ShowDialog();
                this.Close();
            }

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
