using NOC.Models;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NOC.ViewModels
{
    public class ApplicationsListPageViewModel : ViewModelBase
    {
        public ApplicationsListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TransactionsList = new ObservableCollection<TransactionModel>( Session.Instance.ApplicationsOrTransactionsList);
        }
        private ObservableCollection<TransactionModel> transactionsList = new ObservableCollection<TransactionModel>();
        public ObservableCollection<TransactionModel> TransactionsList
        {
            get { return transactionsList; }
            set { SetProperty(ref transactionsList, value); }
        }

       
    }
}
