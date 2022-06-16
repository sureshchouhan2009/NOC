﻿using Newtonsoft.Json;
using NOC.Enums;
using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class TransactionInfoPageViewModel : ViewModelBase
    {
        public TransactionInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
            IsReviewer = Session.Instance.CurrentUserType == UserTypes.Reviewer;
            IsNewApplication = Session.Instance.IsNewNocApplicationFlow;
            IsOwnedApplication = Session.Instance.IsOwnedApplicationFlow||Session.Instance.IsRepliedNocApplicationFlow;
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

       


        private bool _isNewApplication;
        public bool IsNewApplication
        {
            get
            {
                
                return _isNewApplication;
            }
            set
            {
                SetProperty(ref _isNewApplication, value);
            }
        }

        private bool _isOwnedApplication;
        public bool IsOwnedApplication
        {
            get
            {

                return _isOwnedApplication;
            }
            set
            {
                SetProperty(ref _isOwnedApplication, value);
            }
        }

        private bool _isReviewer;
        public bool IsReviewer
        {
            get
            {

                return _isReviewer;
            }
            set
            {
                SetProperty(ref _isReviewer, value);
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


        private ICommand _reviewerAcceptancePageNavigateCommand;

        public ICommand ReviewerAcceptancePageNavigateCommand
        {
            get
            {
                if (_reviewerAcceptancePageNavigateCommand == null)
                {
                    _reviewerAcceptancePageNavigateCommand = new Command(ReviewerAcceptancePageNavigateCommandExecute);
                }

                return _reviewerAcceptancePageNavigateCommand;
            }
        }

        private async void ReviewerAcceptancePageNavigateCommandExecute(object obj)
        {
            await NavigationService.NavigateAsync("TrasactionAacceptancePage");
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
        private ICommand ownNocCommand;

        public ICommand OwnNocCommand
        {
            get
            {
                if (ownNocCommand == null)
                {
                    ownNocCommand = new Command(OwnNocCommandExecuteAsync);
                }

                return ownNocCommand;
            }
        }

        private async void OwnNocCommandExecuteAsync(object obj)
        {
            try
            {

                ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;

                var str = JsonConvert.SerializeObject(objectionOptionPostModel);
                var result = await ApiService.Instance.PostOwnNoc(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);

            }
            catch (Exception ex)
            {

            }

        }
        private ICommand transferNocCommand;

        public ICommand TransferNocCommand
        {
            get
            {
                if (transferNocCommand == null)
                {
                    transferNocCommand = new Command(TransferNocCommandExecute);
                }

                return transferNocCommand;
            }
        }

        private async void TransferNocCommandExecute(object obj)
        {
            try
            {

                ObjectionOptionPostModel transferNocModel = new ObjectionOptionPostModel();
                transferNocModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                transferNocModel.userID = TransactonDetail.Transaction.UserID;
                var result = await ApiService.Instance.GetTransferNocApiCall(transferNocModel);
                await Application.Current.MainPage.DisplayToastAsync(result);

            }
            catch (Exception ex)
            {

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



        private ICommand addAttachmentCommand;

        public ICommand AddAttachmentCommand
        {
            get
            {
                if (addAttachmentCommand == null)
                {
                    addAttachmentCommand = new Command(AddAttachmentCommandExecute);
                }

                return addAttachmentCommand;
            }
        }



        private async void AddAttachmentCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {
                NewAttachmentModel requestModel = new NewAttachmentModel();
                var options = new PickOptions
                {
                    PickerTitle = "Please select a comic file",
                    // FileTypes = customFileType,
                };
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    var byteArray = await GeneralUtility.getByteArrayFromFile(result);

                        requestModel = new NewAttachmentModel
                        {
                            strFile = Convert.ToBase64String(byteArray),
                            strFilename = result.FileName,
                            transactionid = TransactonDetail.Transaction.TransactionID
                        };

                    string attacmentSaveResponse = await ApiService.Instance.SaveCommentAttachment(requestModel);

                    if (!string.IsNullOrEmpty(attacmentSaveResponse))
                    {
                        MediaAttachmentModel ActualAttachmentRequest = new MediaAttachmentModel();

                        List<Attchtypeandfilepath> filePathList = new List<Attchtypeandfilepath>();
                        filePathList.Add(new Attchtypeandfilepath
                        {
                            Attachmenttype = 5,
                            commentID = 0,
                            filepath = attacmentSaveResponse
                        });

                        ActualAttachmentRequest.attchtypeandfilepath = filePathList;
                        ActualAttachmentRequest.attachments = new Attachments
                        {
                            TransactionID = TransactonDetail.Transaction.TransactionID,
                            UserID = TransactonDetail.Transaction.UserID
                        };

                        ActualAttachmentRequest.RandomID = "7569924447";
                        ActualAttachmentRequest.TransactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;

                        string FinalResponse = await ApiService.Instance.SaveCommentAttachmentToDB(ActualAttachmentRequest);
                        getLatestAttachments();
                        await Application.Current.MainPage.DisplayToastAsync(FinalResponse);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync("Something went wrong Please try again.");
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("No selection");
                }
               
               

               


                
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
            IsBusy = false;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
           // IsBusy = true;
            base.OnNavigatedTo(parameters);
            getLatestAttachments();
             //AttachmentList =await ApiService.Instance.GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString());
            // IsBusy = false;
        }


        public async void getLatestAttachments()
        {
            IsBusy = true;
            AttachmentList = await ApiService.Instance.GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString());
            IsBusy = false;
        }

    }
}
