using InsureModel;

namespace ViewModel
{
    using System.Windows.Input;
    public class AccountViewModel
    {
        private HomeViewModel childViewModel;
        public Account Account
        {
            get;set;
        }

        public AccountViewModel()
        {
            Account = new Account("admin", "amin");
            LoginCommand = new Commands.AccontLoginCommand(this);
            childViewModel = new HomeViewModel();
        }
        
        public ICommand LoginCommand
        {
            get;
            private set;
        }
       

        public void login()
        {
            if (Account.UserName == "simret" && Account.Pass == "simret") {
                
            }
            System.Console.WriteLine(".................Login..............");

        }
    }
}
