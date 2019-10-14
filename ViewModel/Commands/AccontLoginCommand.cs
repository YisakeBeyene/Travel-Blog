using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    class AccontLoginCommand : ICommand

    {
        public AccontLoginCommand(AccountViewModel viewModel) {
            this.Account = viewModel;
        }
        public AccountViewModel Account
        {
            get;set;
        }

        #region ICommand part
        public event System.EventHandler CanExecuteChanged
        {
            add {CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
         
        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(Account.Account.Error);
        }

        public void Execute(object parameter)
        {
            Account.login();
        }
        #endregion
    }
}
