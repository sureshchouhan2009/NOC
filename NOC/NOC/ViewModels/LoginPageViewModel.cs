using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private ICommand loginComand;

        public ICommand LoginComand
        {
            get
            {
                if (loginComand == null)
                {
                    loginComand = new Command(PerformLoginComand);
                }

                return loginComand;
            }
        }

       

        private string emailText;

        public string EmailText { get => emailText; set => SetProperty(ref emailText, value); }

        private string passwordText;

        public string PasswordText { get => passwordText; set => SetProperty(ref passwordText, value); }


        private async void PerformLoginComand(object obj)
        {
            IsBusy = true;
            //perform api calling 
           var token= await TokenClass.GetToken();
            var t = token;

           await NavigationService.NavigateAsync("HomePage");

            IsBusy = false;
        }
    }
}
