using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using NOC.Models;
using NOC.Service;
using System.Threading.Tasks;
using Xamarin.Essentials;

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
            EmailText = "applicant_test";
            PasswordText = "user123";
            IsBusy = true;
            try
            {
                if (String.IsNullOrEmpty(EmailText) || String.IsNullOrEmpty(PasswordText))
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please enter the valid Username and Password", 10000);
                }
                else
                {
                    var token = await TokenClass.GetToken(EmailText, passwordText);

                    if (!string.IsNullOrEmpty(token))
                    {
                        UserTypes userType = await RecogniseTokenAndReturnTheUserType(token);
                        if (userType == UserTypes.Applicant)
                        {
                            Session.Instance.Token = token;
                            Preferences.Set("UserType", userType.ToString());
                            Preferences.Set("Token", token);
                            Preferences.Set("UserName", EmailText);
                            Preferences.Set("Password", PasswordText);
                            Preferences.Set("IsLoggedIN", true);

                            await NavigationService.NavigateAsync("NavigationPage/HomePage");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayToastAsync("Currently supporting only applicant flow");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync("Please enter the valid Username and Password");

                    }



                }
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private async Task<UserTypes> RecogniseTokenAndReturnTheUserType(string token)
        {
            UserTypes userType = new UserTypes();

            try
            {
                if (await ApiService.Instance.ValidateUserTypeFromToken(token, Urls.CheckApplicant))
                {
                    userType = UserTypes.Applicant;
                }
                else if (await ApiService.Instance.ValidateUserTypeFromToken(token, Urls.CheckReviewer))
                {
                    userType = UserTypes.Reviewer;
                }
                else if (await ApiService.Instance.ValidateUserTypeFromToken(token, Urls.CheckOfficer))
                {
                    userType = UserTypes.Officer;
                }
                else if (await ApiService.Instance.ValidateUserTypeFromToken(token, Urls.CheckStakeholder))
                {
                    userType = UserTypes.Stackholder;
                }
                else
                {
                    userType = UserTypes.Applicant;
                }

            }
            catch (Exception ex)
            {
                userType = UserTypes.Applicant;

            }

            return userType;
        }
    }
}
