using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class NotificationsPageViewModel : ViewModelBase
    {
        private ObservableCollection<NotificationsModel> notifications = new ObservableCollection<NotificationsModel>();
        public ObservableCollection<NotificationsModel> Notifications
        {
            get { return notifications; }
            set { SetProperty(ref notifications, value); }
        }
       
        public NotificationsPageViewModel(INavigationService navigationService) : base(navigationService)
        {

            Notifications = new ObservableCollection<NotificationsModel>(Session.Instance.NotificationsModelList);
        }


        private ICommand navigateNotificationPageToTrasactionDetailsCommand;

        public ICommand NavigateNotificationPageToTrasactionDetailsCommand
        {
            get
            {
                if (navigateNotificationPageToTrasactionDetailsCommand == null)
                {
                    navigateNotificationPageToTrasactionDetailsCommand = new Command(NavigatoTransctionDetailsPage);
                }

                return navigateNotificationPageToTrasactionDetailsCommand;
            }
        }


        private async void NavigatoTransctionDetailsPage(object obj)
        {

            IsBusy = true;
            try
            {
               
                NotificationsModel selectedTransaction = (NotificationsModel)obj;
                var result =await ApiService.Instance.ChangeReadStatusForNotifications(selectedTransaction.NotificationID);
                // string SplittedStrings=   selectedTransaction.Message.Split(' ').FirstOrDefault(sp=>sp.Length==17);

                if (!string.IsNullOrEmpty(selectedTransaction.TransactionNumber))
                {
                    Session.Instance.CurrentTransaction = await ApiService.Instance.GetTransactionDetails(selectedTransaction.TransactionNumber);
                    await NavigationService.NavigateAsync("TransactionInfoPage");
                }
               

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

    }
}
