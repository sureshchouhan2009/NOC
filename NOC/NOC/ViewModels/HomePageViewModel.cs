using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
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

        private async void ShowNotificationsExecute(object obj)
        {
            IsBusy = true;
            Session.Instance.NotificationsModelList.Clear();
            Session.Instance.NotificationsModelList =  await ApiService.Instance.GetNotificationsList();
           await NavigationService.NavigateAsync("NotificationsPage");
            IsBusy = false;


        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsBusy = true;
            try
            {
                Session.Instance.MenuItemsCountModelData = await ApiService.Instance.GetSearchCountApiCall();
                NotificationCount = Session.Instance.MenuItemsCountModelData.NotificationCount;
                MyNocApplicationCount = Session.Instance.MenuItemsCountModelData.MyNOCApplicationsCount;
                CommentedApplicationCount = Session.Instance.MenuItemsCountModelData.CommentedApplicationsCount;
                NocApplicationforRevalidationInTenDaysCount = string.IsNullOrWhiteSpace(Session.Instance.MenuItemsCountModelData.OwnedApplicationsPendingTenDayCount) ?
                    "00" : Session.Instance.MenuItemsCountModelData.OwnedApplicationsPendingTenDayCount;
            }
            catch (Exception ex)
            {

                
            }
            IsBusy = false;
        }



    }
}
