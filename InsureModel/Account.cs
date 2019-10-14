using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InsureModel  
{
    public class Account : INotifyPropertyChanged , IDataErrorInfo
    {
        public string UserName { get; set; }
        public string Pass { get; set; }

        

        public Account(String UserName, String Pass)
        {
            this.UserName = UserName;
            this.Pass = Pass;
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

        #region IDataError
        public string Error
        {
            get;
            private set;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "UserName" || columnName=="Pass")
                {
                    if (String.IsNullOrWhiteSpace(Pass))
                    {
                        Error = "UserName and Password cannot be Empty";
                    }
                    else if (String.IsNullOrWhiteSpace(UserName))
                    {
                        Error = "UserName and Password cannot be Empty";
                    }
                    else {
                        Error = null; 
                    }
                }
                return Error;
            }
        }
        #endregion
    }
}
