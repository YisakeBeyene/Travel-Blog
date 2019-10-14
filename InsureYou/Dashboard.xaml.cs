using InsureModel;
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

namespace InsureYou
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();

            InData consumo = new InData();
            DataContext = new InDataViewModel(consumo);

            total.Text= InsureInfo.total().ToString();
            updates.Text = Notification.GetCount().ToString();

        }

        private class InData
        {
            public string Title { get; private set; }
            public int Percentage { get; private set; }
            public InData()
            {
                Title = "Consumo Atual";
                Percentage = CalcularPercentage();
            }

            private int CalcularPercentage()
            {
                return 47;
            }
        }

        private class InDataViewModel
        {
            public List<InData> Consumo { get; private set; }

            public InDataViewModel(InData consumo)
            {
                Consumo = new List<InData>();
                this.Consumo.Add(consumo);
            }
        }
    }
}
