﻿using Microsoft.Identity.Client;
using NOC.Constants;
using NOC.Enums;
using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {

        public IPublicClientApplication IdentityClient { get; set; }
        private string _inProgressNOCsCount;
        public string InProgressNOCsCount
        {
            get
            {
                return _inProgressNOCsCount;
            }
            set
            {
                SetProperty(ref _inProgressNOCsCount, value);
            }
        }

        private bool _isProcessorFlow;
        public bool IsProcessorFlow
        {
            get
            {
                return _isProcessorFlow ;
            }
            set
            {
                SetProperty(ref _isProcessorFlow, value);
            }
        }

        private bool _isReviewerOrOfficer;
        public bool IsReviewerOrOfficer
        {
            get
            {
                return _isReviewerOrOfficer;
            }
            set
            {
                SetProperty(ref _isReviewerOrOfficer, value);
            }
        }

        private string _notificationCount;
        public string NotificationCount
        {
            get
            {
                return _notificationCount;
            }
            set
            {
                SetProperty(ref _notificationCount, value);
            }
        }
        private string _ncompletedNOCsCount;
        public string CompletedNOCsCount
        {
            get
            {
                return _ncompletedNOCsCount;
            }
            set
            {
                SetProperty(ref _ncompletedNOCsCount, value);
            }
        }

       

        private string _myNocApplicationCount;
        public string MyNocApplicationCount
        {
            get
            {
                return _myNocApplicationCount;
            }
            set
            {
                SetProperty(ref _myNocApplicationCount, value);
            }
        }
        private string _newNocApplicationCount;
        public string NewNocApplicationCount
        {
            get
            {
                return _newNocApplicationCount;
            }
            set
            {
                SetProperty(ref _newNocApplicationCount, value);
            }
        }

        private string _repliedNOCsCount;
        public string RepliedNOCsCount
        {
            get
            {
                return _repliedNOCsCount;
            }
            set
            {
                SetProperty(ref _repliedNOCsCount, value);
            }
        }
        private string _nocApplicationforRevalidationInTenDaysCount;
        public string NocApplicationforRevalidationInTenDaysCount
        {
            get
            {
                return _nocApplicationforRevalidationInTenDaysCount;
            }
            set
            {
                SetProperty(ref _nocApplicationforRevalidationInTenDaysCount, value);
            }
        }

        private string _ownedApplicationCount;
        public string OwnedApplicationCount
        {
            get
            {
                return _ownedApplicationCount;
            }
            set
            {
                SetProperty(ref _ownedApplicationCount, value);
            }
        }

        private string _commentedApplicationCount;
        public string CommentedApplicationCount
        {
            get
            {
                return _commentedApplicationCount;
            }
            set
            {
                SetProperty(ref _commentedApplicationCount, value);
            }
        }
       
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
          IsProcessorFlow= Session.Instance.CurrentUserType != UserTypes.Applicant;

            IsReviewerOrOfficer = Session.Instance.CurrentUserType == UserTypes.Reviewer || Session.Instance.CurrentUserType == UserTypes.Officer;
        }

        private ICommand navigateToNotificationPageCommand;

        public ICommand NavigateToNotificationPageCommand
        {
            get
            {
                if (navigateToNotificationPageCommand == null)
                {
                    navigateToNotificationPageCommand = new Command(ShowNotificationsExecute);
                }

                return navigateToNotificationPageCommand;
            }
        }
        
        private ICommand performLogOutCommand;

        public ICommand PerformLogOutCommand
        {
            get
            {
                if (performLogOutCommand == null)
                {
                    performLogOutCommand = new Command(PerformLogOutExecute);
                }

                return performLogOutCommand;
            }
        }

        private async void PerformLogOutExecute(object obj)
        {
            IsBusy = true;
           if(!await logOutFromMSAL())
            {
                await Application.Current.MainPage.DisplayToastAsync("There is some problem with logout", 10000);
            }
            else
            {
                Preferences.Clear();
                await NavigationService.NavigateAsync("/LoginPage");
            }
           
            IsBusy = false;
        }

        private async Task< bool> logOutFromMSAL()
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

        private ICommand performDashboardCommand;

        public ICommand PerformDashboardCommand
        {
            get
            {
                if (performDashboardCommand == null)
                {
                    performDashboardCommand = new Command(performDashboardCommandExecute);
                }

                return performDashboardCommand;
            }
        }
        /// <summary>
        /// Navigates DashBoard to App{PowerBI}
        /// </summary>
        /// <param name="obj"></param>
        private async void performDashboardCommandExecute(object obj)
        {
            //try
            //{
            //    string url = string.Empty;
            //    string location = RegionInfo.CurrentRegion.Name.ToLower();
            //    if (Device.RuntimePlatform == Device.Android)
            //    {
            //        //await Launcher.OpenAsync("https://play.google.com/store/apps/details?id=com.microsoft.powerbim&hl=en-IN");
            //        url = "https://play.google.com/store/apps/details?id=com.microsoft.powerbim&hl=en-IN";
            //    }
            //    else
            //    {
            //        url = "https://apps.apple.com/" + location + "/app/microsoft-power-bi/id929738808";
            //    }

            //    await Browser.OpenAsync(url, BrowserLaunchMode.External);

            //}
            //catch (Exception ex)
            //{

            //}

            //try
            //{
            //    //https://stackoverflow.com/questions/63594273/xamarin-forms-how-to-open-an-app-from-another-app
            //    DependencyService.Register<IAppHandler>();
            //    //await DependencyService.Get<IAppHandler>().LaunchApp("com.microsoft.powerbim");
            //    //await DependencyService.Get<IAppHandler>().LaunchApp("com.deloitte.dnmobile.parking");
            //    await DependencyService.Get<IAppHandler>().LaunchApp("com.linkedin.android");
            //}
            //catch (Exception ex)
            //{

            //}

           OpenPowerBIDashboard();

        }

        private async void OpenPowerBIDashboard()
        {
            try
            {

                //string linkedInProfileUrl = "https://www.linkedin.com/in/sureshchouhan2009";
               // string linkedInProfileUrl = "https://play.google.com/store/apps/details?id=com.microsoft.powerbim&pcampaignid=web_share";
               // string linkedInProfileUrl = "https://app.powerbi.com/Redirect?action=OpenDashboard";
                string powerBIUrl = "https://app.powerbi.com/Redirect?action=OpenApp";

                // Attempt to open Power BI app
                //await Launcher.OpenAsync("mspowerbi://");
                await Launcher.OpenAsync(new Uri(powerBIUrl));
            }
            catch (Exception ex)
            {
                // Power BI app is not installed or couldn't be opened
                // Open Play Store (Android) or App Store (iOS) to install the app
                if (Device.RuntimePlatform == Device.Android)
                {

                    Device.OpenUri(new Uri("market://details?id=com.microsoft.powerbim"));
                }
                else
                {
                    // For iOS, use:
                    Device.OpenUri(new Uri("itms://itunes.apple.com/us/app/microsoft-power-bi/id929738808"));
                }
              
            }
        }

        private ICommand navigateToMyNocApplications;

        public ICommand NavigateToMyNocApplications
        {
            get
            {
                if (navigateToMyNocApplications == null)
                {
                    navigateToMyNocApplications = new Command(NavigatoApplicationsListPage);
                }

                return navigateToMyNocApplications;
            }
        }



        private async void NavigatoApplicationsListPage(object obj)
        {
            
            IsBusy = true;
            try
            {
                int inputValue = int.Parse(obj.ToString());
                Session.Instance.ApplicationsOrTransactionsList.Clear();
                Session.Instance.ApplicationListPageTitle = determineApplicationListPageTitle(inputValue);
                Session.Instance.ApplicationsOrTransactionsList = await ApiService.Instance.ApplicantGetTransactionList(inputValue);// send two for first option
                await NavigationService.NavigateAsync("ApplicationsListPage");
            
                //checking for New application
                if (inputValue == 10)
                {
                    Session.Instance.IsNewNocApplicationFlow = true;
                    
                }
                else
                {
                    Session.Instance.IsNewNocApplicationFlow = false;
                }

                //checking for InProgress Nocs Flow
                if (inputValue == 2)
                {
                    Session.Instance.IsInProgressNocsFlow = true;
                    
                }
                else
                {
                    Session.Instance.IsInProgressNocsFlow = false;
                }
                //checking for owned application
                if (inputValue == 5)
                {
                    Session.Instance.IsOwnedApplicationFlow = true;
                }
                else
                {
                    Session.Instance.IsOwnedApplicationFlow = false ;
                }


                //checking for CommentedApplicationFlow 
                if (inputValue == 1)
                {
                    Session.Instance.IsCommentedApplicationFlow = true;
                }
                else
                {
                    Session.Instance.IsCommentedApplicationFlow = false;
                }

                //checking for RepliedNocApplicationFlow 
                if (inputValue == 9)
                {
                    Session.Instance.IsRepliedNocApplicationFlow = true;
                }
                else
                {
                    Session.Instance.IsRepliedNocApplicationFlow = false;
                }
                //checking for Completed Application 
                if (inputValue == 11)
                {
                    Session.Instance.IsCompletedApplicationFlow = true;
                }
                else
                {
                    Session.Instance.IsCompletedApplicationFlow = false;
                }
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private string determineApplicationListPageTitle(int inputValue)
        {
            if (inputValue == 1)
            {
                return "Commented NOCs";
            }
            //else if(inputValue==2)
            //{
            //    return "My NOCs";
            //}
            else if (inputValue == 2)
            {
                return "In Progress NOCs";
            }
            //else if (inputValue == 3)
            //{
            //    return "Commented NOCs";
            //}
            else if (inputValue == 4)
            {
                return "NOCs for Revalidation in two weeks";
            }
            else if (inputValue == 5)
            {
                return "Owned NOCs";
            }
            //else if (inputValue == 6)
            //{
            //  //  return "NOCs for Revalidation in 10 Days";
            //    return "NOCs for Revalidation in two weeks";
            //}
            //else if (inputValue == 7)
            //{
            //    return "Commented NOCs";
            //}
            else if (inputValue == 9)
            {
                return "Comment Reply";
            }else if (inputValue == 10)
            {
                return "New NOC Applications";
                
            }
            else if (inputValue == 11)
            {
                return "Completed NOCs";

            }
            else
            {
                return "Transactions";
            }

        }

        private async void ShowNotificationsExecute(object obj)
        {
            try
            {
                IsBusy = true;
                Session.Instance.NotificationsModelList.Clear();
                Session.Instance.NotificationsModelList = await ApiService.Instance.GetNotificationsList();
                await NavigationService.NavigateAsync("NotificationsPage");
                IsBusy = false;
            }
            catch (Exception ex)
            {

                
            }


        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsBusy = true;
            try
            {
                Session.Instance.MenuItemsCountModelData = await ApiService.Instance.GetSearchCountApiCall();
                NotificationCount = Session.Instance.MenuItemsCountModelData.NotificationCount ?? "00";
                MyNocApplicationCount = Session.Instance.MenuItemsCountModelData.MyNOCApplicationsCount ?? "00";
                NewNocApplicationCount = Session.Instance.MenuItemsCountModelData.NewNOCApplicationsCount??"00";
                RepliedNOCsCount= Session.Instance.MenuItemsCountModelData.CommentReplyCount ?? "00";
                CommentedApplicationCount = Session.Instance.MenuItemsCountModelData.CommentedApplicationsCount??"00";
                OwnedApplicationCount = Session.Instance.MenuItemsCountModelData.OwnedApplicationsCount ?? "00";
                CompletedNOCsCount = Session.Instance.MenuItemsCountModelData.CompletedApplication ?? "00";
                InProgressNOCsCount= Session.Instance.MenuItemsCountModelData.InProgressApplicationsCount ?? "00";
                //revalidation in two weeks instead 10  days
                NocApplicationforRevalidationInTenDaysCount = string.IsNullOrWhiteSpace(Session.Instance.MenuItemsCountModelData.ForRevalidationInTwoWeeksCount) ?
                    "00" : Session.Instance.MenuItemsCountModelData.ForRevalidationInTwoWeeksCount;
            }
            catch (Exception ex)
            {

                
            }
            IsBusy = false;
        }



    }
}
