using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        private List<AttachmentsTypesResourceModel> _doccumentTypes = new List<AttachmentsTypesResourceModel>();
        public List<AttachmentsTypesResourceModel> DoccumentTypes
        {
            get
            {

                return _doccumentTypes;
            }
            set
            {
                SetProperty(ref _doccumentTypes, value);
            }

        }

        private AttachmentsTypesResourceModel _doccumentTypeSelectedItem;
        public AttachmentsTypesResourceModel DoccumentTypeSelectedItem
        {
            get
            {
                return _doccumentTypeSelectedItem;
            }
            set
            {
                SetProperty(ref _doccumentTypeSelectedItem, value);
            }
        }
        private string _DurationValuetext;
        public string DurationValuetext
        {
            get
            {
                
                   
                
                return _DurationValuetext;
            }
            set
            {
                SetProperty(ref _DurationValuetext, value);
            }
        }

        private string _ValidityPickerSelectedItem;
        public string ValidityPickerSelectedItem
        {
            get
            {
                CalculateAndPrepareValidTillDate(_ValidityPickerSelectedItem, DurationValuetext);
                return _ValidityPickerSelectedItem;
            }
            set
            {
                SetProperty(ref _ValidityPickerSelectedItem, value);
            }
        }

        private void CalculateAndPrepareValidTillDate(string validityPickerSelectedItem, string durationValuetext)
        {
            try
            {

                if (validityPickerSelectedItem == "Months")
                {
                    int monthCount = int.Parse(durationValuetext);
                    CalculatedValidTillDate = DateTime.Now.AddMonths(monthCount).ToString("dd/MMM/yyyy");
                }
                else if (validityPickerSelectedItem == "Years")
                {
                    int YearCount = int.Parse(durationValuetext);
                    CalculatedValidTillDate = DateTime.Now.AddYears(YearCount).ToString("dd/MMM/yyyy");
                }
                else
                {
                    int daysCount = int.Parse(durationValuetext);
                    CalculatedValidTillDate = DateTime.Now.AddDays(daysCount).ToString("dd/MMM/yyyy");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string _CalculatedValidTillDate;
        public string CalculatedValidTillDate
        {
            get
            {
                return _CalculatedValidTillDate;
            }
            set
            {
                SetProperty(ref _CalculatedValidTillDate, value);
            }
        }
        private ICommand _validityCountChangedEventCommand;

        public ICommand ValidityCountChangedEventCommand
        {
            get
            {
                if (_validityCountChangedEventCommand == null)
                {
                    _validityCountChangedEventCommand = new Command(ValidityCountChangedEventCommandExecute);
                }

                return _validityCountChangedEventCommand;
            }
        }

        private void ValidityCountChangedEventCommandExecute(object obj)
        {
            CalculateAndPrepareValidTillDate(_ValidityPickerSelectedItem, DurationValuetext);
        }

        public TrasactionAacceptancePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsReviewerConditionFlow = true;
            IsStackholderCommentsFlow = true;
            Title = "Transaction Info";
            DDSourceList.Add("Days");
            DDSourceList.Add("Months");
            DDSourceList.Add("Years");
            DurationValuetext = "180";
            ValidityPickerSelectedItem = DDSourceList.FirstOrDefault();
            IsReviewerAddCommentButtonVisible = true;

          
            
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
                if(!string.IsNullOrEmpty(DoccumentTypeSelectedItem.AttachmentTypeCode))
                {
                    NewAttachmentModel requestModel = new NewAttachmentModel();
                    var options = new PickOptions
                    {
                        PickerTitle = "Please select a file",
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
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("please select the attachment type.");
                }

                

            }
            catch (Exception ex)
            {
                // The user cancelledcanceled or something went wrong
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
          getLatestAttachmentsForStackHolder(SelectedStackholderResponse?.SthcmntID ?? 0);
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

        private ObservableCollection<CommentsRelatedAttachmentModel> _StackholderAttachmentsModelList;
        public ObservableCollection<CommentsRelatedAttachmentModel> StackholderAttachmentsModelList
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
            IsBusy = true;
            String CommentId = "";
            try
            {
                if (!string.IsNullOrEmpty(CalculatedValidTillDate))
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
                        saveCommentModel.expirydate = CalculatedValidTillDate; //DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                        saveCommentModel.isAvaliable = true;
                        CommentId = await ApiService.Instance.SaveNewCommentFromReviewer(saveCommentModel);
                        await Application.Current.MainPage.DisplayToastAsync("Comment saved successfully");
                    }
                    else
                    {
                        //update existing
                        UpdateExisitingCommentModel updateExisitingCommentModel = new UpdateExisitingCommentModel();
                        updateExisitingCommentModel.expirydate = CalculatedValidTillDate;// DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                        updateExisitingCommentModel.text = SpecificMessageText;
                        updateExisitingCommentModel.transactionid = TransactonDetail.Transaction.TransactionID;
                        updateExisitingCommentModel.id = ExistingComment.SthcmntID.ToString();
                        updateExisitingCommentModel.radiovalue = 1;
                        CommentId = await ApiService.Instance.UpdateExisitingCommentFromReviewer(updateExisitingCommentModel);
                        await Application.Current.MainPage.DisplayToastAsync("Comment updated successfully");
                    }

                    //here actualy we are saving the attachment to DB
                    if (!string.IsNullOrEmpty(CommentId) && Session.Instance.SavedFilePathForReviewerPage != "")
                    {
                        ReviewerAttachmentUploadModel uploadModel = new ReviewerAttachmentUploadModel();
                        uploadModel.attachments = new Models.ReviwerSpecific.Attachments { TransactionID = TransactonDetail.Transaction.TransactionID };
                        uploadModel.attchtypeandfilepath.Add(new Attchtypeandfilepath
                        {
                            Attachmenttype = DoccumentTypeSelectedItem.AttachmentTypeID,
                            commentID = int.Parse(CommentId),
                            filepath = Session.Instance.SavedFilePathForReviewerPage
                        });
                        uploadModel.RandomID = "1";
                        uploadModel.TransactionNumber = TransactonDetail.Transaction.TransactionNumber;
                        string successMessage = await ApiService.Instance.UploadFileAgainstReviewerComment(uploadModel);
                        await Application.Current.MainPage.DisplayToastAsync(successMessage);
                        Session.Instance.SavedFilePathForReviewerPage = "";
                        DoccumentTypeSelectedItem = new AttachmentsTypesResourceModel();
                    }

                    //check here  latest comment and latest attachment update in UI

                 var updatedUI=  await CheckAndUpdateTheLatestCommentsAndAttachment();
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please enter the valid validity duration.");
                }
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private async Task<bool> CheckAndUpdateTheLatestCommentsAndAttachment()
        {
            try
            {
                var transactionID = TransactonDetail.Transaction.TransactionID.ToString();//correct
                ExistingComment = await ApiService.Instance.GetReviewerSpecificComment(transactionID);//319
                SpecificMessageText = ExistingComment.Comment;
                getLatestAttachmentsForReviewerComments(ExistingComment?.SthcmntID ?? 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        private bool _isReviewerConditionFlow;
        public bool IsReviewerConditionFlow
        {
            get
            {
                return _isReviewerConditionFlow;
            }
            set
            {
                SetProperty(ref _isReviewerConditionFlow, value);
            }
        }
       

        private ICommand _reviewDecisionTappedCommand;

        public ICommand ReviewDecisionTappedCommand
        {
            get
            {
                if (_reviewDecisionTappedCommand == null)
                {
                    _reviewDecisionTappedCommand = new Command(ReviewDecisionTappedCommandExecute);
                }

                return _reviewDecisionTappedCommand;
            }
        }

        private void ReviewDecisionTappedCommandExecute(object obj)
        {
            IsReviewerConditionFlow = true;
        }

        private ICommand _decisionTappedCommand;

        public ICommand DecisionTappedCommand
        {
            get
            {
                if (_decisionTappedCommand == null)
                {
                    _decisionTappedCommand = new Command(DecisionTappedCommandExecute);
                }

                return _decisionTappedCommand;
            }
        }

        private void DecisionTappedCommandExecute(object obj)
        {
            IsReviewerConditionFlow = false;
        }

        private List<string> _dDSourceList= new List<string>();
        public List<string> DDSourceList
        {
            get
            {

                return _dDSourceList;
            }
            set
            {
                SetProperty(ref _dDSourceList, value);
            }

        }


        private ICommand _stackholdersTappedCommand;

        public ICommand StackholdersTappedCommand
        {
            get
            {
                if (_stackholdersTappedCommand == null)
                {
                    _stackholdersTappedCommand = new Command(StackholdersTappedCommandExecute);
                }

                return _stackholdersTappedCommand;
            }
        }

        private void StackholdersTappedCommandExecute(object obj)
        {
            IsStackholderCommentsFlow = true;
        }

        private ICommand _reviewerTappedCommand;

        public ICommand ReviewerTappedCommand
        {
            get
            {
                if (_reviewerTappedCommand == null)
                {
                    _reviewerTappedCommand = new Command(ReviewerTappedCommandExecute);
                }

                return _reviewerTappedCommand;
            }
        }

        private void ReviewerTappedCommandExecute(object obj)
        {
            IsStackholderCommentsFlow = false;
        }

        private bool _isStackholderCommentsFlow;
        public bool IsStackholderCommentsFlow
        {
            get
            {
                return _isStackholderCommentsFlow;
            }
            set
            {
                SetProperty(ref _isStackholderCommentsFlow, value);
            }
        }

        private bool _isOwnedFlow;
        public bool IsOwnedFlow
        {
            get
            {
                return Session.Instance.IsOwnedApplicationFlow;
            }
            set
            {
                SetProperty(ref _isOwnedFlow, value);
            }
        }


        private bool _isReviewerAddCommentButtonVisible;
        public bool IsReviewerAddCommentButtonVisible
        {
            get
            {
                return _isReviewerAddCommentButtonVisible;
            }
            set
            {
                SetProperty(ref _isReviewerAddCommentButtonVisible, value);
            }
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new Command(AddCommandExecute);
                }

                return _addCommand;
            }
        }

        private void AddCommandExecute(object obj)
        {
            IsReviewerAddCommentButtonVisible = false;
        }

        private string _reviewerSpecificComment;
        public string ReviewerSpecificComment
        {
            get
            {
                return _reviewerSpecificComment;
            }
            set
            {
                SetProperty(ref _reviewerSpecificComment, value);
            }
        }

        private ObservableCollection<StackholderCommentsInReviewerPageModel> _stackHolderCommentsList;

        public ObservableCollection<StackholderCommentsInReviewerPageModel> StackHolderCommentsList
        {
            get
            {

                return _stackHolderCommentsList;
            }
            set
            {
                SetProperty(ref _stackHolderCommentsList, value);
            }
        }


        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(SaveCommandExecute);
                }

                return _saveCommand;
            }
        }

        private async void SaveCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {

                PostReviewerSpecificComment specificComment = new PostReviewerSpecificComment();
                specificComment.CONDITIONS = ReviewerSpecificComment;
                specificComment.TRANSACTIONID = TransactonDetail.Transaction.TransactionID;
                string result = await ApiService.Instance.PostreviewerSpecificComment(specificComment);
                await Application.Current.MainPage.DisplayToastAsync(result);
                ReviewerSpecificComment = "";
                IsReviewerAddCommentButtonVisible = true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayToastAsync(ex.ToString());
            }
            IsBusy = false;
        }

        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new Command(CancelCommandExecute);
                }

                return _cancelCommand;
            }
        }

        private void CancelCommandExecute(object obj)
        {
            IsReviewerAddCommentButtonVisible = true;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
           
            base.OnNavigatedTo(parameters);
            try
            {

                var transactionID = TransactonDetail.Transaction.TransactionID.ToString();//correct
                DoccumentTypes = await ApiService.Instance.GetAttachmentsTypesForDD();
                StackHolderList = new ObservableCollection<StackholderModel>(await ApiService.Instance.GetStackHolderList(transactionID));//319
                AllstackHolderResponseList = new ObservableCollection<AllStackholderResponse>(await ApiService.Instance.GetAllStackHolderResponseData(transactionID));//319
                if (StackHolderList.Count > 0)
                {
                    SelectedStackholderResponse = AllstackHolderResponseList.FirstOrDefault(x => x.StakeholderID == StackHolderList.FirstOrDefault()?.ERStakeHoldersID);
                }
                ExistingComment = await ApiService.Instance.GetReviewerSpecificComment(transactionID);//319
                SpecificMessageText = ExistingComment?.Comment??"";
                getLatestAttachmentsForStackHolder(SelectedStackholderResponse?.SthcmntID??0);

                getLatestAttachmentsForReviewerComments(ExistingComment?.SthcmntID??0);


               bool success= await GetAndFillConditionSpecificPart(transactionID);
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private async Task<bool> GetAndFillConditionSpecificPart(string transactionID)
        {
            StackHolderCommentsList = new ObservableCollection<StackholderCommentsInReviewerPageModel>(await ApiService.Instance.StackHolderCommentsForCondition("319"));

            return StackHolderCommentsList.Count > 0;
        }


        //public async void getLatestAttachments()
        //{
        //    IsBusy = true;
        //    AttachmentList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(ExistingComment?.SthcmntID.ToString()));
        //    StackholderAttachmentsModelList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(SelectedStackholderResponse.SthcmntID.ToString()));//376
        //    //StackholderAttachmentsModelList = AttachmentList;
        //    IsBusy = false;
        //}

        public async void getLatestAttachmentsForStackHolder(int SthcmntID)
        {
            IsBusy = true;
            StackholderAttachmentsModelList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(SthcmntID.ToString()));//376
            IsBusy = false;
        }

        public async void getLatestAttachmentsForReviewerComments(int SthcmntID)
        {
            IsBusy = true;
            AttachmentList = new ObservableCollection<CommentsRelatedAttachmentModel>( await ApiService.Instance.GetCommentsRelatedAttachment(ExistingComment?.SthcmntID.ToString()));
            
            IsBusy = false;
        }
    }
}
