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
using System.Diagnostics;
using System.Linq;
using Microsoft.Identity.Client;
using NOC.Interfaces;
using NOC.Constants;

namespace NOC.ViewModels
{
    class LoginPageViewModel : ViewModelBase
    {

        public IPublicClientApplication IdentityClient { get; set; }
      

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
            try
            {
               
                var result = await GetAuthenticationToken();
                if(!string.IsNullOrWhiteSpace(result.Token))
                {
                    UserAuthorizationModel userDetails = await TokenClass.GetTokenAzureTokenDetails(result.Token);//access token
                    if (!string.IsNullOrWhiteSpace(userDetails.roles))
                     {
                        var userID = await TokenClass.PostApiCallForUserID(result.Token);
                        UserTypes userType = GetUserTypeFromUserDetails(userDetails);
                        Session.Instance.CurrentUserType = userType;
                        Session.Instance.Token = result.Token;
                        Session.Instance.CurrentUserID = userID;
                        Preferences.Set("UserType", userType.ToString());
                        Preferences.Set("Token", Session.Instance.Token);
                        //Preferences.Set("UserName", EmailText);
                        //Preferences.Set("Password", PasswordText);
                        Preferences.Set("CurrentUserID", userID);
                        Preferences.Set("IsLoggedIN", true);
                        //Preferences.Set("CurrentUsersolutionroleid", userDetails?.authorizedrole?.FirstOrDefault()?.solutionroleid??0);
                        if (getCurrentUsersolutionroleid(userDetails) > 0)
                        {
                            Preferences.Set("CurrentUsersolutionroleid", getCurrentUsersolutionroleid(userDetails));
                            await NavigationService.NavigateAsync("NavigationPage/HomePage");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayToastAsync("Unable to find user role", 10000);
                        }
                       
                       
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync("Unable to find user role", 10000);
                       await logOutFromMSAL();
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Unauthorized user", 10000);
                }

              
            }

            catch (Exception ex)
            {
               
                await Application.Current.MainPage.DisplayToastAsync("There is some problem with login Please try again later", 10000);
            }



        }

        private async Task<bool> logOutFromMSAL()
        {
            try
            {

                if (IdentityClient == null)
                {
                    IdentityClient = App.PlatformService.GetIdentityClient(Constant.ApplicationId);
                }
                var accounts = await IdentityClient.GetAccountsAsync();

                // Go through all accounts and remove them.
                while (accounts.Any())
                {
                    await IdentityClient.RemoveAsync(accounts.FirstOrDefault());
                    accounts = await IdentityClient.GetAccountsAsync();
                }
                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }

        private int getCurrentUsersolutionroleid(UserAuthorizationModel userDetails)
        {
            int SoloutionRoleID = 0;

            try
            {

                foreach (var author in userDetails.authorizedrole)
                {
                    if (author.AuthorizedName == "Officer")
                    {
                        SoloutionRoleID = author.solutionroleid;
                        break;
                    }
                    else if (author.AuthorizedName == "Reviewer")
                    {
                        SoloutionRoleID = author.solutionroleid;
                        break;
                    }
                    else if (author.AuthorizedName == "Stakeholder")
                    {
                        SoloutionRoleID = author.solutionroleid;
                        break;
                    }
                    else
                    {
                        SoloutionRoleID = 0;
                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return SoloutionRoleID;
        }
        //private async void PerformLoginComand(object obj)
        //{
        //    string tokentotest = "30bg5S1aKCc9Qrfq48harPC0CJwKTsbh8mSvOxqp4jrSeLSJMmPRw8PXslDsm2gdwI_XHYMF5RiPC5tX4tggOptgXXVmBtO5mGBpxoXSmXf5iR624LiJ-pTcqDS2SD-a6ygMcMJ5_WA8JhQqFVoAq2JkW3b3g5Za2elGP2IpLAfgrO1t2JxQti0kIp6y7YIoKl1JAEiuZthqEzAQQO_aZsmvZB7M0eHhkba5oaJsPW5RQVqgqZiZRGCWElTmBwP10kPcdWGrLMiozc3rtQYyvMR3egYghhReqPoDkI892fvTtS8sxQq3C3oGxM5wKToO3Z1AOggW0E6el_f7cIETZs02ilwM0ljnsEloiPfo-ucCvpU3dYdMYHLuU9B6AwDcTLdWGj9oY87mkjdATRhYyiIXAGNkFCtiDfh1LxDaz3IkH02YzSM0DppQhAQcaemrl3jywiYCeV7E3daKMPgU8dIFzz_zC_DRfTsl9QAGWOI5ad_dPYky7LP8Fy7wKBjwr3nGPCPkPPVhyGnSYwwzTHYx-3mjFUIMEs2IgRP9nH_3Jt9tgj4Rxr7Qd1lQ1yev3YgVVVJPAz3tLUAtbJg__rMDBnrVSjn2ammIUbGFxtKZDpwDSpg6OvrkY2OSaCsm1jZu5LwJpX6wue9Lf2y1x8XTYWvMHnEEz8SjFRlFteBOkLOvaazQn2HeZygYEtIm6C8xdc7BJDM6RhHgq1OQjrpWua7U0V7NrX0JBD5kZH5iWA_evAm-DL5AgNdJ-rSjgEB5MtvxeQPMDMPgb7-SwszwFq8nTqTW5JNX3GUZgaX0dyX2qiN4S3mOkrQ-FsYeriy0A1gLGGlSUR7lMzeJV246wAEmr7sI1Bi79OtUc0a34iZVLH3eQS-GNKUXY8OlXCv8Wm8dhUvG6Ft8aWVTnQtPrWQR9YyMKnYTyjGMMYZCgI_qNCX_BO4KT62E553tWxkJ0YEp2AWAUejaQZqsFQmq-4wGWthE001m_l1PD6koDGkhLsG5DHwe5f7uFak6UTrI5yf6N2OIUh_ngEdrLoG7nKCrX_X-rLvWTgPDiz4P8O_xroBFYRwihcFE9lI-OOnb-K48ufh97-JM9xFAGZpR_Sc-L__7H-mQOpp_guWOclQU2Im_a4Rb4u_wIIMwy40FLFKOlPg5DPLtkcUKmVgKlf7LvelZxmoNwrRKwuuByu8SFmgukJiy7zZt5UdlQ2W-ttFm9CRrFDdHS4GkzAiYST1N6k0uDCDeVOq6mN-9ugoKA-U8XL5j9uD2G3JFSiIDmTNkVc5hAzMO8X-OBs7GHx2X5ZwAsBRJ4y42YXH__fY5HdTjx-QTCa19cgWHr74ChLJ12w6qRVhLJUf-HWhmetjQxYZcQ86ZBNERVNtnTeOGf_TfAAo4AGtsajrWuMXWUTTCO-gW2kngiAbDFszrgu9Ia2JBoaOJKzQiWCQFi-3qGgEaLLK3-M9ccoNjPtW2rsLkUMZc5JM1TuHaJsjS2sXxP2WCRzGETEepN7Bh97jqGo8SEOsoV92k3vHIfEVcagvmi25Wae6sTFJQHhllCt2mEXBfnHWMlKQTcqU";
        //  var res=  await TokenClass.GetTokenDetails(tokentotest);
        //    var yurde = res;
        //    #region Credentials New
        //    //            USERID                               UserName           Password      Role                 Role Type

        //    //af3c6b7b - 84b2 - 4317 - bafe - 6f0fa2fab083    Erengineering_uat   User@123    Engineering            3
        //    //c6d2a521 - cd9c - 402a - a83d - b11e7d36e2bd    Eroperator_uat      User@123    Operators(ER Infra)    7
        //    //018ad094 - ef5f - 4b19 - 9017 - f4173f28c11f    Eroperations_uat    User@123    Operation              4
        //    //37d715a8 - 02e5 - 4d8a - 9b02 - c2917e8e1684    Applicant_uat       User@123    Applicant              1
        //    //c2d82d6c - b585 - 49ba - adba - e7fa2552b953    Officer_uat         User@123    officer                2
        //    //70a0f3ba - c038 - 468d - abc4 - 9698ef4ca0a3    Reviwer_uat         User@123    Reviewer               12
        //    //48e6acb5 - 4688 - 4614 - b782 - b51fb0798df7    eradmin_test        User@123    Admin                  14


        //    //OLD
        //    //EmailText = "applicant_test";
        //    //PasswordText = "U$er123";

        //    //for Processor
        //    //EmailText = "officer_test";
        //    //PasswordText = "user123";

        //    //StakHolder
        //    //EmailText = "stackholder_test";
        //    //PasswordText = "user123";

        //    //for Reviewer
        //    //EmailText = "reviwer_test";
        //    //PasswordText = "user123";
        //    #endregion


        //    IsBusy = true;
        //    try
        //    {
        //        //EmailText = "Officer_uat";
        //        //PasswordText = "User@123";

        //        //for new stackholder

        //        //EmailText = "dcc_test";
        //        //PasswordText = "user123";
        //        if (String.IsNullOrEmpty(EmailText) || String.IsNullOrEmpty(PasswordText))
        //        {
        //            await Application.Current.MainPage.DisplayToastAsync("Please enter the valid Username and Password", 10000);
        //        }
        //        else
        //        {
        //            var token = await TokenClass.GetToken(EmailText, passwordText);





        //            var userID = await TokenClass.GetTokenDetails(token);

        //            if (!string.IsNullOrEmpty(token))
        //            {
        //                UserTypes userType = await RecogniseTokenAndReturnTheUserType(token);
        //                if (userType == UserTypes.Applicant)
        //                {
        //                    Session.Instance.CurrentUserType = userType;
        //                    Session.Instance.Token = token;
        //                    Session.Instance.CurrentUserID = userID;

        //                    Preferences.Set("UserType", userType.ToString());
        //                    Preferences.Set("Token", token);
        //                    Preferences.Set("UserName", EmailText);
        //                    Preferences.Set("CurrentUserID", userID);
        //                    Preferences.Set("Password", PasswordText);
        //                    Preferences.Set("IsLoggedIN", true);

        //                    await NavigationService.NavigateAsync("NavigationPage/HomePage");
        //                }
        //                else //if (userType == UserTypes.Officer)
        //                {
        //                    Session.Instance.CurrentUserType = userType;
        //                    Session.Instance.Token = token;
        //                    Session.Instance.CurrentUserID = userID;
        //                    Preferences.Set("UserType", userType.ToString());
        //                    Preferences.Set("Token", token);
        //                    Preferences.Set("UserName", EmailText);
        //                    Preferences.Set("Password", PasswordText);
        //                    Preferences.Set("CurrentUserID", userID);
        //                    Preferences.Set("IsLoggedIN", true);
        //                    await NavigationService.NavigateAsync("NavigationPage/HomePage");
        //                }
        //                //else
        //                //{
        //                //    await Application.Current.MainPage.DisplayToastAsync("Currently supporting only applicant flow");
        //                //}
        //            }
        //            else
        //            {
        //                await Application.Current.MainPage.DisplayToastAsync("Please enter the valid Username and Password");

        //            }



        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    IsBusy = false;
        //}

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

       

        private UserTypes GetUserTypeFromUserDetails(UserAuthorizationModel userDetails)
        {
            UserTypes userType= new UserTypes();
            try
            {
                if (userDetails.ActiveRole.ToLower() == "reviewer")
                {
                    userType = UserTypes.Reviewer;
                }
                else if (userDetails.ActiveRole.ToLower() == "officer")
                {
                    userType = UserTypes.Officer;
                }
                else if (userDetails.ActiveRole.ToLower() == "stakeholder")
                {
                    userType = UserTypes.Stackholder;
                }
                return userType;
            }
            catch (Exception ex)
            {

                return userType; 
            }
        }

        public async Task<AuthenticationToken> GetAuthenticationToken()
        {
            if (IdentityClient == null)
            {
                IdentityClient = App.PlatformService.GetIdentityClient(Constant.ApplicationId);
            }

            var accounts = await IdentityClient.GetAccountsAsync();
            AuthenticationResult result = null;
            bool tryInteractiveLogin = false;

            try
            {
                result = await IdentityClient
                    .AcquireTokenSilent(Constant.Scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                tryInteractiveLogin = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MSAL Silent Error: {ex.Message}");
            }

            if (tryInteractiveLogin)
            {
                try
                {
                    

                    result = await IdentityClient
                        .AcquireTokenInteractive(Constant.Scopes)
                        .ExecuteAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"MSAL Interactive Error: {ex.Message}");
                }
            }

            return new AuthenticationToken
            {
                DisplayName = result?.Account?.Username ?? "",
                ExpiresOn = result?.ExpiresOn ?? DateTimeOffset.MinValue,
                Token = result?.AccessToken ?? "",
                UserId = result?.Account?.Username ?? "",
                IDToken=result?.IdToken??""
                
            };
        }
    }
}
