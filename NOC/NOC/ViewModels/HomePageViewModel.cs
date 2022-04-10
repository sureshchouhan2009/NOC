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
        private MenuItemsCountModel _menuItemsCountModelData;
        public MenuItemsCountModel MenuItemsCountModelData
        {
            get
            {
                return _menuItemsCountModelData;
            }
            set
            {
                SetProperty(ref _menuItemsCountModelData, value);
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
            IsBusy = true;

            MenuItemsCountModel model= await ApiService.Instance.GetSearchCountApiCall();
            base.OnNavigatedTo(parameters);

            IsBusy = false;
        }



    }
}
