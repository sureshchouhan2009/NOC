using System;
using System.Collections.Generic;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;

namespace NOC.ViewModels
{
    public class CommentsPageViewModel : ViewModelBase
    {


        public CommentsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PickerSource = new List<string>
            {
                "Test1","Test2","test3"

            };
        }
        private TransactionDetailsModel _transactonDetail;
        public TransactionDetailsModel TransactonDetail
        {
            get
            {
                _transactonDetail = Session.Instance.CurrentTransaction;
                return _transactonDetail;
            }
            set
            {
                SetProperty(ref _transactonDetail, value);
            }
        }

        private List<String> pickerSource = new List<string>();
        public List<String> PickerSource
        {
            get
            {
               
                return pickerSource;
            }
            set
            {
                SetProperty(ref pickerSource, value);
            }
        }

        private List<CommentsModel> commentsList = new List<CommentsModel>();
        public List<CommentsModel> CommentsList
        {
            get
            {

                return commentsList;
            }
            set
            {
                SetProperty(ref commentsList, value);
            }
        }


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            var transactionDetails = Session.Instance.CurrentTransaction;

           
           // CommentsList = await ApiService.Instance.GetTransactionComents(transactionDetails.Transaction.TransactionNumber);

            CommentsList = await ApiService.Instance.GetTransactionComents("RKT-20220330-1004");

            IsBusy = false;
        }

    }
}
