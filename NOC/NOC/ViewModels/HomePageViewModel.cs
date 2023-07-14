using NOC.Enums;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
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
            Preferences.Clear();
            await NavigationService.NavigateAsync("/LoginPage");
            IsBusy = false;
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

        private async void performDashboardCommandExecute(object obj)
        {
            try
            {

                await Launcher.OpenAsync("https://play.google.com/store/apps/details?id=com.microsoft.powerbim&hl=en-IN");
                //await Launcher.OpenAsync("https://apps.apple.com/in/app/microsoft-power-bi/id929738808#:~:text=and%20Apple%C2%A0Watch.-,Microsoft,-Power%20BI");
            }
            catch (Exception ex)
            {

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
            else if(inputValue==2)
            {
                return "My NOCs";
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
