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
using NOC.Enums;

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
            #region Credentials New
            //            USERID                               UserName           Password      Role                 Role Type

            //af3c6b7b - 84b2 - 4317 - bafe - 6f0fa2fab083    Erengineering_uat   User@123    Engineering            3
            //c6d2a521 - cd9c - 402a - a83d - b11e7d36e2bd    Eroperator_uat      User@123    Operators(ER Infra)    7
            //018ad094 - ef5f - 4b19 - 9017 - f4173f28c11f    Eroperations_uat    User@123    Operation              4
            //37d715a8 - 02e5 - 4d8a - 9b02 - c2917e8e1684    Applicant_uat       User@123    Applicant              1
            //c2d82d6c - b585 - 49ba - adba - e7fa2552b953    Officer_uat         User@123    officer                2
            //70a0f3ba - c038 - 468d - abc4 - 9698ef4ca0a3    Reviwer_uat         User@123    Reviewer               12
            //48e6acb5 - 4688 - 4614 - b782 - b51fb0798df7    eradmin_test        User@123    Admin                  14


            //OLD
            //EmailText = "applicant_test";
            //PasswordText = "U$er123";

            //for Processor
            //EmailText = "officer_test";
            //PasswordText = "user123";

            //StakHolder
            //EmailText = "stackholder_test";
            //PasswordText = "user123";

            //for Reviewer
            //EmailText = "reviwer_test";
            //PasswordText = "user123";
            #endregion

           
            IsBusy = true;
            try
            {
                EmailText = "Eroperator_uat";
                PasswordText = "User@123";
                if (String.IsNullOrEmpty(EmailText) || String.IsNullOrEmpty(PasswordText))
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please enter the valid Username and Password", 10000);
                }
                else
                {
                    var token = await TokenClass.GetToken(EmailText, passwordText);

                    var userID = await TokenClass.GetTokenDetails(token);

                    if (!string.IsNullOrEmpty(token))
                    {
                        UserTypes userType = await RecogniseTokenAndReturnTheUserType(token);
                        if (userType == UserTypes.Applicant)
                        {
                            Session.Instance.CurrentUserType = userType;
                            Session.Instance.Token = token;
                            Session.Instance.CurrentUserID = userID;

                            Preferences.Set("UserType", userType.ToString());
                            Preferences.Set("Token", token);
                            Preferences.Set("UserName", EmailText);
                            Preferences.Set("CurrentUserID", userID);
                            Preferences.Set("Password", PasswordText);
                            Preferences.Set("IsLoggedIN", true);

                            await NavigationService.NavigateAsync("NavigationPage/HomePage");
                        }
                        else //if (userType == UserTypes.Officer)
                        {
                            Session.Instance.CurrentUserType = userType;
                            Session.Instance.Token = token;
                            Session.Instance.CurrentUserID = userID;
                            Preferences.Set("UserType", userType.ToString());
                            Preferences.Set("Token", token);
                            Preferences.Set("UserName", EmailText);
                            Preferences.Set("Password", PasswordText);
                            Preferences.Set("CurrentUserID", userID);
                            Preferences.Set("IsLoggedIN", true);
                            await NavigationService.NavigateAsync("NavigationPage/HomePage");
                        }
                        //else
                        //{
                        //    await Application.Current.MainPage.DisplayToastAsync("Currently supporting only applicant flow");
                        //}
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
                // please check this is not providing correct user type by the urls because of tis reason its being date 13-08-2022
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
