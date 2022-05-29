using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class TrasactionAacceptancePageViewModel : ViewModelBase
    {
        public TrasactionAacceptancePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
        }

        private ICommand noObjectionCommand;

        public ICommand NoObjectionCommand
        {
            get
            {
                if (noObjectionCommand == null)
                {
                    noObjectionCommand = new Command(NoObjectionCommandExecute);
                }

                return noObjectionCommand;
            }
        }

        private async void NoObjectionCommandExecute(object obj)
        {
            try
            {

                ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                var result = await ApiService.Instance.PostNoObjection(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);

            }
            catch (Exception ex)
            {

            }

        }

        private ICommand raiseObjectionCommand;

        public ICommand RaiseObjectionCommand
        {
            get
            {
                if (raiseObjectionCommand == null)
                {
                    raiseObjectionCommand = new Command(RaiseObjectionCommandExecute);
                }

                return raiseObjectionCommand;
            }
        }

        private async void RaiseObjectionCommandExecute(object obj)
        {
            try
            {

                ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                var result = await ApiService.Instance.PostObjection(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);

            }
            catch (Exception ex)
            {

            }

        }

        private string _specificMessageText;

        public string SpecificMessageText
        {
            get
            {
                return _specificMessageText;
            }
            set
            {
                SetProperty(ref _specificMessageText, value);
            }
        }

        private ObservableCollection<StackholderModel> _stackHolderList = new ObservableCollection<StackholderModel>();
        public ObservableCollection<StackholderModel> StackHolderList
        {
            get
            {

                return _stackHolderList;
            }
            set
            {
                SetProperty(ref _stackHolderList, value);
            }
        }

        private ObservableCollection<AttachmentModel> _attachmentList;
        public ObservableCollection<AttachmentModel> AttachmentList
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


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            var transactionID = TransactonDetail.Transaction.TransactionID.ToString();//correct
            StackHolderList = new ObservableCollection<StackholderModel>( await ApiService.Instance.GetStackHolderList("319"));//319
            getLatestAttachments();
            IsBusy = false;
        }


        public async void getLatestAttachments()
        {
            IsBusy = true;
            AttachmentList = new ObservableCollection<AttachmentModel>( await ApiService.Instance.GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString()));
            IsBusy = false;
        }
    }
}
