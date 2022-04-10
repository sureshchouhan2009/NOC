using NOC.Models;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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


    }
}
