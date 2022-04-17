using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
        
             private ICommand navigateToTrasactionDetailsCommand;

        public ICommand NavigateToTrasactionDetailsCommand
        {
            get
            {
                if (navigateToTrasactionDetailsCommand == null)
                {
                    navigateToTrasactionDetailsCommand = new Command(NavigatoTransctionDetailsPage);
                }

                return navigateToTrasactionDetailsCommand;
            }
        }



        private async void NavigatoTransctionDetailsPage(object obj)
        {

            IsBusy = true;
            try
            {
                TransactionModel selectedTransaction = (TransactionModel)obj;
                Session.Instance.CurrentTransaction = await ApiService.Instance.GetTransactionDetails(selectedTransaction.ApplicationNumber);
                await NavigationService.NavigateAsync("TransactionInfoPage");
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

    }
}
