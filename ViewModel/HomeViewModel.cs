using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public String Info {
            get
            {
                return Info;
            }
            set
            {
                Info = value;
                OnPropertyChanged("info");

            }
        }

        #region property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }


        #endregion

    }
}
