using Newtonsoft.Json;
using NOC.Enums;
using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IsCameraVisible=checkCameraOptionVisibility();
            IsReviewer = Session.Instance.CurrentUserType == UserTypes.Reviewer || Session.Instance.IsOfficerequalToReviewer||Session.Instance.IsStackholderequalToReviewer;
            IsNewApplication = Session.Instance.IsNewNocApplicationFlow;
            IsOwnedApplication = Session.Instance.IsOwnedApplicationFlow || Session.Instance.IsRepliedNocApplicationFlow;    
        }

       

        private bool checkCameraOptionVisibility()
        {
            bool isCamera = false;
            //try
            //{
               
            //    if (Session.Instance.IsCompletedApplicationFlow || Session.Instance.CurrentUserType == UserTypes.Reviewer)
            //    {
            //         isCamera = false;
            //    }
            //    else if (Session.Instance.CurrentUserType == UserTypes.Applicant)
            //    {
            //         isCamera = false;
            //    }
            //    else if (Session.Instance.CurrentUserType == UserTypes.Stackholder || Session.Instance.CurrentUserType == UserTypes.Officer)
            //    {
            //        if (Session.Instance.IsOwnedApplicationFlow || Session.Instance.IsRepliedNocApplicationFlow)
            //        {
            //             isCamera = true;
            //        }
            //        else
            //        {
            //             isCamera = false;
            //        }
            //    }
            //    else
            //    {
            //         isCamera = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //     isCamera = false;
            //}
            return isCamera;

        }

        private List<AttachmentModel> _attachmentList= new List<AttachmentModel>();
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

       


        private bool _isCameraVisible;
        public bool IsCameraVisible
        {
            get
            {
                
                return _isCameraVisible;
            }
            set
            {
                SetProperty(ref _isCameraVisible, value);
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
            if(Session.Instance.CurrentUserType == UserTypes.Reviewer)
            {
                await NavigationService.NavigateAsync("TrasactionAacceptancePage");
            }
            else if (Session.Instance.IsOfficerequalToReviewer)
            {
                await NavigationService.NavigateAsync("OfficerResponsePage");
                
            }
            else if(Session.Instance.IsStackholderequalToReviewer)
            {
                await NavigationService.NavigateAsync("StackholderResponsePage");
            }
            //else
            //{
            //    await NavigationService.NavigateAsync("TrasactionAacceptancePage");
            //}

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
            IsBusy = true;
            try
            {


                OwnNocPostModel objectionOptionPostModel = new OwnNocPostModel();
                objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                objectionOptionPostModel.userID = Session.Instance.CurrentUserID;//"faa81574-c437-4d58-85e4-f115f1e22d12"; //TransactonDetail.Transaction.UserID;
                if (Session.Instance.CurrentUserType==UserTypes.Stackholder)
                {
                    objectionOptionPostModel.workflow = Session.Instance.CurrentTransactionWorkFlow;
                }
               
                   
                var result = await ApiService.Instance.PostOwnNoc(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);
                await NavigationService.NavigateAsync("app:///HomePage");

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
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
                if (SelectedEligibleUserforTransferNOcs != null)
                {
                    IsBusy = true;
                    TransferNocRequestModel transferNocModel = new TransferNocRequestModel();
                    transferNocModel.transNumber = TransactonDetail.Transaction.TransactionNumber;
                    transferNocModel.transferUserId = SelectedEligibleUserforTransferNOcs.UserId;//TransactonDetail.Transaction.UserID;
                    transferNocModel.Type = "Transfer";
                    transferNocModel.REPLYSEQID = Session.Instance.reply_Seq_ID;
                    var result = await ApiService.Instance.PostTransferNocApiCall(transferNocModel);
                    await Application.Current.MainPage.DisplayToastAsync(result);
                    await NavigationService.NavigateAsync("app:///HomePage");
                    IsBusy = false;
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please select an user to whom you want to transfer NOC");
                }
                
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
        }

        private async void NavigateToCommentsPage(object obj)
        {
            //await NavigationService.NavigateAsync("CommentsPage");
            await NavigationService.NavigateAsync("NewAddCommentPage");
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
                       await getLatestAttachments();
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
        private EligibletranferNocsUserModel _selectedEligibleUserforTransferNOcs;
        public EligibletranferNocsUserModel SelectedEligibleUserforTransferNOcs
        {
            get
            {
                return _selectedEligibleUserforTransferNOcs;
            }
            set
            {
                SetProperty(ref _selectedEligibleUserforTransferNOcs, value);
            }
        }

        private List<EligibletranferNocsUserModel> _EligibleUsersForTransferList;
        public List<EligibletranferNocsUserModel> EligibleUsersForTransferList
        {
            get
            {

                return _EligibleUsersForTransferList;
            }
            set
            {
                SetProperty(ref _EligibleUsersForTransferList, value);
            }
        }


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
             IsBusy = true;
             base.OnNavigatedTo(parameters);
            var response= await getLatestAttachments();
            EligibleUsersForTransferList= await ApiService.Instance.GeteleigibleTransferNocsUsersList();
             IsBusy = false;
        }

        public async Task<bool> getLatestAttachments()
        {
            try
            {

                var Attachments = await ApiService.Instance.GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString());
                if (Attachments?.Count > 0)
                {
                    AttachmentList = Attachments.Where(e => e.CommentsID == 0).ToList();
                }

                return AttachmentList.Count > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }






        private ICommand downloadTransactionDetailsPDFCommand;
        public ICommand DownloadTransactionDetailsPDFCommand
        {
            get
            {
                if (downloadTransactionDetailsPDFCommand == null)
                {
                    downloadTransactionDetailsPDFCommand = new Command(downloadTransactionDetailsPDF);
                }

                return downloadTransactionDetailsPDFCommand;
            }
        }

        private async void downloadTransactionDetailsPDF(object obj)
        {
            string currentTransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionNumber.ToString();
            string PDFURL = await ApiService.Instance.DownloadTransactionDetailsAsPDF(currentTransactionID);
            if (!string.IsNullOrEmpty(PDFURL))
            {
              await  Launcher.OpenAsync(PDFURL);

                //byte[] base64EncodedBytes = System.Convert.FromBase64String(base64str);
                //IPdfFileDownloader downloader = DependencyService.Get<IPdfFileDownloader>();
                //downloader.downloadLocalyStoredPdfFile(currentTransactionID + ".pdf", base64EncodedBytes);
            }
            else
            {
                await Application.Current.MainPage.DisplayToastAsync("Unable to download file from server");
            }
           
        }

       
    }
}
