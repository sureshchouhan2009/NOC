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
    public class ApplicationsListPageViewModel : ViewModelBase
    {
        public ApplicationsListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ApplicationListPageTitle = Session.Instance.ApplicationListPageTitle;
            TransactionsList = new ObservableCollection<TransactionModel>(Session.Instance.ApplicationsOrTransactionsList);
        }
        private ObservableCollection<TransactionModel> transactionsList = new ObservableCollection<TransactionModel>();
        public ObservableCollection<TransactionModel> TransactionsList
        {
            get { return transactionsList; }
            set { SetProperty(ref transactionsList, value); }
        }

        private string _applicationListPageTitle;
        public string ApplicationListPageTitle
        {
            get { return _applicationListPageTitle; }
            set { SetProperty(ref _applicationListPageTitle, value); }
        }

        private String _searchText;
        public String SearchText
        {
            get
            {


                return _searchText;

            }
            set { SetProperty(ref _searchText, value); }
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
        private ICommand _searchTextChangedCommand;
        public ICommand SearchTextChangedCommand
        {
            get
            {
                if (_searchTextChangedCommand == null)
                {
                    _searchTextChangedCommand = new Command<object>(searchTextChangedCommandExecute);
                }

                return _searchTextChangedCommand;
            }
        }
        private void searchTextChangedCommandExecute(object obj)
        {
            try
            {
                if (!String.IsNullOrEmpty(SearchText))
                {
                    var fList = Session.Instance.ApplicationsOrTransactionsList.Where(e =>
                    e.ApplicationNumber.ToLower().Contains(SearchText.ToLower()) ||

                    e.STATUS.ToLower().Contains(SearchText.ToLower())).ToList();
                    TransactionsList =
                    new ObservableCollection<TransactionModel>(fList);
                }
                else
                {
                    TransactionsList = new ObservableCollection<TransactionModel>(Session.Instance.ApplicationsOrTransactionsList);
                }
            }
            catch (Exception ex)
            {


            }
        }
        private async void NavigatoTransctionDetailsPage(object obj)
        {

            IsBusy = true;
            try
            {
                TransactionModel selectedTransaction = (TransactionModel)obj;
                if (Session.Instance.CurrentUserType == Enums.UserTypes.Officer)
                {
                    var argum = selectedTransaction.ER_OUTCOME_CODE;
                    if (argum == "ER_OFFREV_APPROVE" || argum == "ER_OFFREV_REV_REPLIED" || argum == "ER_OWNERSHIPTRANSFER_APPROVE_OFFREV" || argum == "ER_APP_OFFREV_REPLIED")
                    {
                      
                        Session.Instance.IsOfficerequalToReviewer = true;
                        // var officerSthcmntIDData = await ApiService.Instance.checkStackholderdetails1(selectedTransaction.TransactionID.ToString(), Session.Instance.CurrentUserID, selectedTransaction.WorkFlow);
                        var officerSthcmntIDData = await ApiService.Instance.checkStackholderdetails1(selectedTransaction.TransactionID.ToString(), Session.Instance.CurrentUserID, "Officer2");
                        Session.Instance.SthcmntID = officerSthcmntIDData.Stakeholder_Comments.SthcmntID;
                        Session.Instance.CurrentTransactionWorkFlow = selectedTransaction.WorkFlow;
                    }
                    else
                    {
                        Session.Instance.IsOfficerequalToReviewer = false;
                        var officerSthcmntIDData = await ApiService.Instance.checkStackholderdetails1(selectedTransaction.TransactionID.ToString(), Session.Instance.CurrentUserID, "Operations");
                        Session.Instance.SthcmntID = officerSthcmntIDData?.Stakeholder_Comments?.SthcmntID??0;
                        Session.Instance.CurrentTransactionWorkFlow = selectedTransaction.WorkFlow;
                    }
                }
                else if (Session.Instance.CurrentUserType == Enums.UserTypes.Stackholder)
                {
                  var stackholder1 = await ApiService.Instance.checkStackholderdetails1(selectedTransaction.TransactionID.ToString(), Session.Instance.CurrentUserID, selectedTransaction.WorkFlow);
                 // var stackholder1 = await ApiService.Instance.checkStackholderdetails1("15823", Session.Instance.CurrentUserID, "UnderConstruction");
                  var stackholder2 = await ApiService.Instance.checkStackholderdetails2(Session.Instance.CurrentUserID);
                    if(stackholder1!=null&& stackholder2 != null)
                    {

                        Session.Instance.IsStackholderequalToReviewer = stackholder1.Stakeholder_Comments?.UserSolutionRole == stackholder2.SolutionRoleID ? true : false;
                        if (Session.Instance.IsStackholderequalToReviewer)
                        {
                            Session.Instance.SthcmntID = stackholder1?.Stakeholder_Comments?.SthcmntID??0;

                            Session.Instance.CurrentTransactionWorkFlow = selectedTransaction.WorkFlow;
                        }
                    }
                    else
                    {
                        Session.Instance.IsStackholderequalToReviewer = false;
                        Session.Instance.SthcmntID = stackholder1.Stakeholder_Comments?.SthcmntID??0;
                        Session.Instance.CurrentTransactionWorkFlow = selectedTransaction.WorkFlow;
                    }
                   
                }

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
