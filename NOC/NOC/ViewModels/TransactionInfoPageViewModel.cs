using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class TransactionInfoPageViewModel : ViewModelBase
    {
        public TransactionInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
        }

        private List<AttachmentModel> _attachmentList;
        public List<AttachmentModel> AttachmentList
        {
            get
            {
               
                return _attachmentList;
            }
            set
            {
                SetProperty(ref _attachmentList, value);
            }
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

        private ICommand downloadCommand;

        public ICommand DownloadCommand
        {
            get
            {
                if (downloadCommand == null)
                {
                    downloadCommand = new Command(DownloadCommandExecute);
                }

                return downloadCommand;
            }
        }

        private async void DownloadCommandExecute(object obj)
        {
            try
            {

                var currentAttachment = obj as AttachmentModel;
                await Launcher.OpenAsync(currentAttachment.UrlPath);

            }
            catch (Exception ex)
            {

            }
        }

        private ICommand navigateToComments;

        public ICommand NavigateToComments
        {
            get
            {
                if (navigateToComments == null)
                {
                    navigateToComments = new Command(NavigateToCommentsPage);
                }

                return navigateToComments;
            }
        }

        private async void NavigateToCommentsPage(object obj)
        {
            await NavigationService.NavigateAsync("CommentsPage");
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

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
           
            AttachmentList =await ApiService.Instance.GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString());
            IsBusy = false;
        }

    }
}
