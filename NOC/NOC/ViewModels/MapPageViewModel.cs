using System;
using System.IO;
using System.Windows.Input;
using NOC.Interfaces;
using NOC.Models;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public MapPageViewModel(INavigationService navigationService ) : base(navigationService)
        {
            //try
            //{

            //    HtmlWebViewSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            //}
            //catch (Exception ex)
            //{

            //}
        }


        private HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource();

        public HtmlWebViewSource HtmlWebViewSource
        {
            get
            {
                return htmlWebViewSource;
            }
            set
            {
                SetProperty(ref htmlWebViewSource, value);
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
            //await NavigationService.NavigateAsync("CommentsPage");
            await NavigationService.NavigateAsync("NewAddCommentPage");
        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //var fileName = "index.html";
            //using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        HtmlWebViewSource.Html = await reader.ReadToEndAsync();

                   


            //    }
            //}
        }
    }
}
