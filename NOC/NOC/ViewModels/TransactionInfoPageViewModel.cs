using NOC.Interfaces;
using NOC.Models;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        private ICommand navigateToMapCommand;

        public ICommand NavigateToMapCommand
        {
            get
            {
                if (navigateToMapCommand == null)
                {
                    navigateToMapCommand = new Command(NavigateToMapView);
                }

                return navigateToMapCommand;
            }
        }

        private async void NavigateToMapView(object obj)
        {

           await NavigationService.NavigateAsync("MapPage");
            //var source = new HtmlWebViewSource();
            //source.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            //var browser = new WebView
            //{
            //   // Source = "https://dotnet.microsoft.com/apps/xamarin"


            //    Source = source
            //};
        }

    }
}
