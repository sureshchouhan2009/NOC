using NOC.Models;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.ViewModels
{
    public class TransactionInfoPageViewModel : ViewModelBase
    {
        public TransactionInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
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
    }
}
