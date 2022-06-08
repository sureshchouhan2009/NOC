using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NOC.Interfaces;
using NOC.Models;
using NOC.Models.ReviwerSpecific;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
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
                objectionOptionPostModel.expirydate = DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                var result = await ApiService.Instance.PostNoObjection(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);

            }
            catch (Exception ex)
            {

            }

        }
        
        private ICommand _downloadCommentsAttachmentsCommand;

        public ICommand DownloadCommentsAttachmentsCommand
        {
            get
            {
                if (_downloadCommentsAttachmentsCommand == null)
                {
                    _downloadCommentsAttachmentsCommand = new Command(DownloadCommentsAttachmentsCommandExecute);
                }

                return _downloadCommentsAttachmentsCommand;
            }
        }
        //UploadAttachmentCommand

        private ICommand _uploadAttachmentCommand;

        public ICommand UploadAttachmentCommand
        {
            get
            {
                if (_uploadAttachmentCommand == null)
                {
                    _uploadAttachmentCommand = new Command(UploadAttachmentCommandExecute);
                }

                return _uploadAttachmentCommand;
            }
        }

        private async void UploadAttachmentCommandExecute(object obj)
        {
            
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
                    IsBusy = true;
                    string attacmentSaveResponse = await ApiService.Instance.SaveCommentAttachment(requestModel);
                    await Application.Current.MainPage.DisplayToastAsync(attacmentSaveResponse);
                    IsBusy = false;

                    if (!string.IsNullOrEmpty(attacmentSaveResponse))
                    {

                        Session.Instance.SavedFilePathForReviewerPage = attacmentSaveResponse;


                        #region OldCode
                        //MediaAttachmentModel ActualAttachmentRequest = new MediaAttachmentModel();

                        //List<Attchtypeandfilepath> filePathList = new List<Attchtypeandfilepath>();
                        //filePathList.Add(new Attchtypeandfilepath
                        //{
                        //    Attachmenttype = 5,
                        //    commentID = 0,
                        //    filepath = attacmentSaveResponse
                        //});

                        //ActualAttachmentRequest.attchtypeandfilepath = filePathList;
                        //ActualAttachmentRequest.attachments = new Attachments
                        //{
                        //    TransactionID = TransactonDetail.Transaction.TransactionID,
                        //    UserID = TransactonDetail.Transaction.UserID
                        //};

                        //ActualAttachmentRequest.RandomID = "7569924447";
                        //ActualAttachmentRequest.TransactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;

                        //string FinalResponse = await ApiService.Instance.SaveCommentAttachmentToDB(ActualAttachmentRequest);
                        //getLatestAttachments();
                        //await Application.Current.MainPage.DisplayToastAsync(FinalResponse);
                        #endregion
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
            
        }

        private void DownloadCommentsAttachmentsCommandExecute(object obj)
        {
          var currentModel=  obj as CommentsRelatedAttachmentModel;
            IDownloader downloader = DependencyService.Get<IDownloader>();

            downloader.OnFileDownloaded += OnFileDownloaded;

            //downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
            downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
        
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
              Application.Current.MainPage.  DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("XF Downloader", "Error while saving the file", "Close");
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
                objectionOptionPostModel.expirydate = null;
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

        private ObservableCollection<CommentsRelatedAttachmentModel> _attachmentList;
        public ObservableCollection<CommentsRelatedAttachmentModel> AttachmentList
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

        private ICommand _showSelectedStackholderresponse;

        public ICommand ShowSelectedStackholderresponse
        {
            get
            {
                if (_showSelectedStackholderresponse == null)
                {
                    _showSelectedStackholderresponse = new Command(ShowSelectedStackholderresponseExecute);
                }

                return _showSelectedStackholderresponse;
            }
        }

        private void ShowSelectedStackholderresponseExecute(object obj)
        {
          var  currentStackholder = obj as StackholderModel;
          SelectedStackholderResponse =  AllstackHolderResponseList.FirstOrDefault(e => e.StakeholderID == currentStackholder.ERStakeHoldersID);


        }
        private AllStackholderResponse _selectedStackholderResponse;
        public AllStackholderResponse SelectedStackholderResponse
        {
            get
            {
                return _selectedStackholderResponse;
            }
            set
            {
                SetProperty(ref _selectedStackholderResponse, value);
            }
        }

        private ObservableCollection<StackholderAttachmentsModel> _StackholderAttachmentsModelList;
        public ObservableCollection<StackholderAttachmentsModel> StackholderAttachmentsModelList
        {
            get
            {
                return _StackholderAttachmentsModelList;
            }
            set
            {
                SetProperty(ref _StackholderAttachmentsModelList, value);
            }
        }

        private ObservableCollection<AllStackholderResponse> _allstackHolderResponseList = new ObservableCollection<AllStackholderResponse>();
        public ObservableCollection<AllStackholderResponse> AllstackHolderResponseList
        {
            get
            {

                return _allstackHolderResponseList;
            }
            set
            {
                SetProperty(ref _allstackHolderResponseList, value);
            }
        }

        private ICommand _saveCommentAndAttachmentCommand;

        public ICommand SaveCommentAndAttachmentCommand
        {
            get
            {
                if (_saveCommentAndAttachmentCommand == null)
                {
                    _saveCommentAndAttachmentCommand = new Command(SaveCommentAndAttachmentCommandExecute);
                }

                return _saveCommentAndAttachmentCommand;
            }
        }

        private ReviewerSpecificCommentModel _existingComment;
        public ReviewerSpecificCommentModel ExistingComment
        {
            get
            {
                return _existingComment;
            }
            set
            {
                SetProperty(ref _existingComment, value);
            }
        }

        private async void SaveCommentAndAttachmentCommandExecute(object obj)
        {
            String CommentId = "";
            try
            {

                if (ExistingComment == null)
                {
                    //new Save
                    PostCommentModel saveCommentModel = new PostCommentModel();
                    Models.ReviwerSpecific.Comments NewComments = new Models.ReviwerSpecific.Comments();
                    NewComments.Comment = SpecificMessageText;
                    NewComments.Decision = 1;
                    NewComments.DecisionID = 1;
                    NewComments.StakeholderID = 1;
                    NewComments.TransactionID = TransactonDetail.Transaction.TransactionID;
                    NewComments.CreatedBy = TransactonDetail.Transaction.CreatedBy;
                    NewComments.CreationDate = DateTime.Now;
                    NewComments.DecisionDate = DateTime.Now;
                    NewComments.UserID = TransactonDetail.Transaction.UserID;
                    saveCommentModel.comments = NewComments;
                    saveCommentModel.expirydate = DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                    saveCommentModel.isAvaliable = true;
                    CommentId = await ApiService.Instance.SaveNewCommentFromReviewer(saveCommentModel);
                }
                else
                {
                    //update existing
                    UpdateExisitingCommentModel updateExisitingCommentModel = new UpdateExisitingCommentModel();
                    updateExisitingCommentModel.expirydate = DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                    updateExisitingCommentModel.text = SpecificMessageText;
                    updateExisitingCommentModel.transactionid = TransactonDetail.Transaction.TransactionID;
                    updateExisitingCommentModel.id = ExistingComment.SthcmntID.ToString();
                    updateExisitingCommentModel.radiovalue = 1;
                    CommentId = await ApiService.Instance.UpdateExisitingCommentFromReviewer(updateExisitingCommentModel);
                }
                if (!string.IsNullOrEmpty(CommentId) && Session.Instance.SavedFilePathForReviewerPage != "")
                {
                    ReviewerAttachmentUploadModel uploadModel = new ReviewerAttachmentUploadModel();
                    uploadModel.attachments = new Models.ReviwerSpecific.Attachments { TransactionID = TransactonDetail.Transaction.TransactionID };
                    uploadModel.attchtypeandfilepath.Add(new Attchtypeandfilepath
                    {
                        Attachmenttype = 5,
                        commentID = int.Parse(CommentId),
                        filepath = Session.Instance.SavedFilePathForReviewerPage
                    });
                    uploadModel.RandomID = "1";
                    uploadModel.TransactionNumber = TransactonDetail.Transaction.TransactionNumber;
                    bool success = await ApiService.Instance.UploadFileAgainstReviewerComment(uploadModel);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            var transactionID = TransactonDetail.Transaction.TransactionID.ToString();//correct
            StackHolderList = new ObservableCollection<StackholderModel>( await ApiService.Instance.GetStackHolderList("319"));//319
            AllstackHolderResponseList= new ObservableCollection<AllStackholderResponse>(await ApiService.Instance.GetAllStackHolderResponseData("319"));//319
            SelectedStackholderResponse = AllstackHolderResponseList.FirstOrDefault(x => x.StakeholderID == StackHolderList.FirstOrDefault().ERStakeHoldersID);
            ExistingComment = await ApiService.Instance.GetReviewerSpecificComment("319");
            SpecificMessageText = ExistingComment.Comment;

            getLatestAttachments();
            IsBusy = false;
        }


        public async void getLatestAttachments()
        {
            IsBusy = true;
            // AttachmentList = new ObservableCollection<AttachmentModel>( await ApiService.Instance.GetCommentsRelatedAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString()));
            AttachmentList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment("376"));

            IsBusy = false;
        }
    }
}
