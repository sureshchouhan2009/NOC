using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
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

        private bool _isNoObjectionSaveAndObjectionButtonEnable;
        public bool IsNoObjectionSaveAndObjectionButtonEnable
        {
            get
            {
                return CalculateConditionForDisablingObjectionSaveAndNoObjectionButton() ;
            }
            set
            {
                SetProperty(ref _isNoObjectionSaveAndObjectionButtonEnable, value);
            }
        }

        //For enable and disable the acytion Buttons
        private bool CalculateConditionForDisablingObjectionSaveAndNoObjectionButton()
        {
            if (IsCompletedApplicationFlow)
            {
                return false;
            }
            else if(Session.Instance.IsNewNocApplicationFlow)
            {
                return false;
            }
            else if (Session.Instance.IsCommentedApplicationFlow)
            {
                return false;
            }
            else if (Session.Instance.IsOwnedApplicationFlow)
            {
                return true;
            }
            else if (IsRepliedNocApplicationFlow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _isRepliedNocApplicationFlow;
        public bool IsRepliedNocApplicationFlow
        {
            get
            {
                return Session.Instance.IsRepliedNocApplicationFlow;
            }
            set
            {
                SetProperty(ref _isRepliedNocApplicationFlow, value);
            }
        }

        private bool _isCompletedApplicationFlow;
        public bool IsCompletedApplicationFlow
        {
            get
            {
                return Session.Instance.IsCompletedApplicationFlow;
            }
            set
            {
                SetProperty(ref _isCompletedApplicationFlow, value);
            }
        }

        private bool _isCommentedApplicationFlow;
        public bool IsCommentedApplicationFlow
        {
            get
            {
                return Session.Instance.IsCommentedApplicationFlow;
            }
            set
            {
                SetProperty(ref _isCommentedApplicationFlow, value);
            }
        }

        private bool _isConditionSelected;
        public bool IsConditionSelected
        {
            get
            {
                return _isConditionSelected;
            }
            set
            {
                SetProperty(ref _isConditionSelected, value);
            }
        }
        private bool _isReviewerDecisionSelected;
        public bool IsReviewerDecisionSelected
        {
            get
            {
                return _isReviewerDecisionSelected;
            }
            set
            {
                SetProperty(ref _isReviewerDecisionSelected, value);
            }
        }


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

        private int _unitValue;
        public int UnitValue
        {
            get
            {



                return _unitValue;
            }
            set
            {
                SetProperty(ref _unitValue, value);
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
                //check here if the application is completed than CalculatedValidTillDate will be calculated based on Transaction details

                if (Session.Instance.IsCompletedApplicationFlow)
                {
                    CalculatedValidTillDate = Session.Instance.CurrentTransaction.Transaction.ValidUntil.ToString("dd/MMM/yyyy");

                    var validityDifference = DateTime.Now-Session.Instance.CurrentTransaction.Transaction.LastModificationDate;

                    if (Session.Instance.CurrentTransaction.Transaction.Unit == 0)
                    {
                        DurationValuetext = validityDifference.Days.ToString();
                        ValidityPickerSelectedItem = DDSourceList[0];
                    }
                    else if (Session.Instance.CurrentTransaction.Transaction.Unit == 1)
                    {
                        var Valuetext = validityDifference.Days / 7;
                        DurationValuetext = Valuetext.ToString();
                        ValidityPickerSelectedItem = DDSourceList[1];
                    }
                    else
                    {
                        var dateSpan = DateTimeSpan.CompareDates(DateTime.Now, Session.Instance.CurrentTransaction.Transaction.LastModificationDate);
                        DurationValuetext= dateSpan.Months.ToString();
                        ValidityPickerSelectedItem = DDSourceList[2];
                    }

                }
                else
                {
                    UnitValue = 0;

                    if (validityPickerSelectedItem == "Months")
                    {
                        UnitValue = 2;
                        int monthCount = int.Parse(durationValuetext);
                        CalculatedValidTillDate = DateTime.Now.AddMonths(monthCount).ToString("dd/MMM/yyyy");
                    }
                    else if (validityPickerSelectedItem == "Weeks")
                    {
                        UnitValue = 1;
                        int DaysCount = int.Parse(durationValuetext);

                        int WeeksCount = DaysCount / 7;
                        CalculatedValidTillDate = DateTime.Now.AddDays(WeeksCount * 7).ToString("dd/MMM/yyyy");
                    }
                    else
                    {
                        UnitValue = 0;
                        int daysCount = int.Parse(durationValuetext);
                        CalculatedValidTillDate = DateTime.Now.AddDays(daysCount).ToString("dd/MMM/yyyy");
                    }
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
            IsReviewerDecisionSelected = true;
            IsConditionSelected = false;


            IsReviewerConditionFlow = true;
            IsStackholderCommentsFlow = true;
            IsStackHolderSelected = false;
            IsReviewerSelected = true;
            Title = "Transaction Info";
            DDSourceList.Add("Days");
            DDSourceList.Add("Weeks");
            DDSourceList.Add("Months");
           
            DurationValuetext = "6";
            ValidityPickerSelectedItem = DDSourceList[2];
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
            IsBusy = true;
            try
            {
                //if(DateTime.Parse(CalculatedValidTillDate) > DateTime.Now.Date.AddDays(7))    // as discussed there isno lower linit//12-10-2023
                //{
                    #region Phase 2 Implementation for agregate Attachments //Submit Button equavallent  to No Objection

                    List<String> AttachmentIds = new List<string>();
                    foreach (var attachment in OfficerResponseAttachmentsInReviewerResponseList)
                    {
                        AttachmentIds.Add(attachment.IsCheckedForAgreeget ? attachment.AttachmentID.ToString() : "a" + attachment.AttachmentID.ToString());
                    }
                    string responseData = await ApiService.Instance.GenericPostApiCall(Urls.AgreGateSubmitInReviewerResponse, AttachmentIds);

                    #endregion


                    ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                    objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                    objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                    objectionOptionPostModel.expirydate = CalculatedValidTillDate; //DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy"); //here changes need to be add as expiry date need to pass as calculated validity date
            
                    objectionOptionPostModel.unit = UnitValue;



                    var result = await ApiService.Instance.PostNoObjection(objectionOptionPostModel);
                    await Application.Current.MainPage.DisplayToastAsync(result);
                    await NavigationService.NavigateAsync("app:///HomePage");
                //}
                //else
                //{
                //    await Application.Current.MainPage.DisplayToastAsync("Please enter a validity Duration");
                //}


            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
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
                            AttachmentList.Add(new CommentsRelatedAttachmentModel
                            {
                                
                                uploadfilename= result.FileName,
                                FormatedUplodedDate=DateTime.Now.ToString("dd/MMM/yyyy"),
                                TransactionID = TransactonDetail.Transaction.TransactionID,
                                AttachmentTypeCode = DoccumentTypeSelectedItem.AttachmentTypeCode
                            }) ;
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

        //private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        //{
        //    IsBusy = true;
        //    var currentModel=  obj as CommentsRelatedAttachmentModel;
        //    IDownloader downloader = DependencyService.Get<IDownloader>();
        //    downloader.OnFileDownloaded += OnFileDownloaded;
        //    downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
        //    IsBusy = false;
        //}

        private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        {
            IsBusy = true;
            string AllAttachmentUrl = "";
            try
            {
                List<int> AIds = new List<int>();
                foreach (var item in OfficerResponseAttachmentsInReviewerResponseList)
                {
                    if (item.IsSelected)
                    {
                        AIds.Add(item.AttachmentID);
                    }

                }

                string responseUrlJson = await ApiService.Instance.GenericPostApiCall(Urls.DownloadMultipleAttachments, AIds);
                 AllAttachmentUrl= JsonConvert.DeserializeObject<string>(responseUrlJson);
                if (!string.IsNullOrEmpty(AllAttachmentUrl))
                {
                    await Launcher.OpenAsync(AllAttachmentUrl);
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayToastAsync(AllAttachmentUrl);
            }
            IsBusy = false;


            //if (OfficerResponseAttachmentsInReviewerResponseList.Any(i => i.IsSelected))
            //{
            //    IsBusy = true;
            //    foreach (var item in OfficerResponseAttachmentsInReviewerResponseList)
            //    {
            //        if (item.IsSelected)
            //        {
            //            IDownloader downloader = DependencyService.Get<IDownloader>();
            //            downloader.OnFileDownloaded += OnFileDownloaded;
            //            downloader.DownloadFile(item.UrlPath, "XF_Downloads");
            //        }

            //    }
            //    IsBusy = false;
            //}
            //else
            //{
            //    await Application.Current.MainPage.DisplayToastAsync("Please select any attachment");
            //}
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
              Application.Current.MainPage.  DisplayAlert("Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Downloader", "Error while saving the file", "Close");
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



        //private async void RaiseObjectionCommandExecute(object obj)
        //{
        //    try
        //    {
        //        IsBusy = true;


        //        ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
        //        objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
        //        objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
        //        objectionOptionPostModel.expirydate = CalculatedValidTillDate;
        //        var result = await ApiService.Instance.PostObjection(objectionOptionPostModel);
        //        await Application.Current.MainPage.DisplayToastAsync(result);
        //        await NavigationService.NavigateAsync("app:///HomePage");
        //        IsBusy = false;

        //    }
        //    catch (Exception ex)
        //    {
        //        IsBusy = false;
        //    }

        //}

        private async void RaiseObjectionCommandExecute(object obj)
        {
            try
            {
               


                //ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                //objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                //objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                //objectionOptionPostModel.expirydate = CalculatedValidTillDate;
                //var result = await ApiService.Instance.PostObjection(objectionOptionPostModel);
                //await Application.Current.MainPage.DisplayToastAsync(result);
                //await NavigationService.NavigateAsync("app:///HomePage");



                if(!string.IsNullOrEmpty(SpecificMessageText))
                {
                    IsBusy = true;
                    SentBackApplicationModel sentBackApplicationModel = new SentBackApplicationModel();
                    sentBackApplicationModel.sentiduserid = TransactonDetail.Transaction.UserID;
                    sentBackApplicationModel.StakeHoldersCodeDisplay = SpecificMessageText;
                    sentBackApplicationModel.sentbacktranID = TransactonDetail.Transaction.TransactionID;
                    sentBackApplicationModel.stepcode = 110021;
                    var result=  await ApiService.Instance.GenericPostApiCall(Urls.SentbackAPICallInReviewerResponse, sentBackApplicationModel);
                    IsBusy = false;
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Comment is required");
                }
              

               

            }
            catch (Exception ex)
            {
                IsBusy = false;
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

        private string _selectedStackholderName;
        public string SelectedStackholderName
        {
            get
            {
                return _selectedStackholderName;
            }

            set
            {
                SetProperty(ref _selectedStackholderName, value);
            }
        }

        private void ShowSelectedStackholderresponseExecute(object obj)
        {
          var  currentStackholder = obj as StackholderModel;
            SelectedStackholderName = currentStackholder.ERGroup;
          SelectedStackholderResponse =  AllstackHolderResponseList.FirstOrDefault(e => e.StakeholderID == currentStackholder.ERStakeHoldersID);
          getLatestAttachmentsForStackHolder(SelectedStackholderResponse?.TransactionID.ToString(), SelectedStackholderResponse?.UserSolutionRole.ToString());
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

        private ObservableCollection<CommentsRelatedAttachmentModel> _StackholderAttachmentsModelList=new ObservableCollection<CommentsRelatedAttachmentModel>();
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
                        saveCommentModel.unit = UnitValue;
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
                        updateExisitingCommentModel.unit = UnitValue;
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
            IsReviewerDecisionSelected = true;
            IsConditionSelected = false;
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
            IsReviewerDecisionSelected = false;
            IsConditionSelected = true;
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
            IsReviewerSelected = false;
            IsStackHolderSelected = true;
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
            IsReviewerSelected = true;
            IsStackHolderSelected = false;
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




        private bool _isStackHolderSelected;
        public bool IsStackHolderSelected
        {
            get
            {
                return _isStackHolderSelected;
            }
            set
            {
                SetProperty(ref _isStackHolderSelected, value);
            }
        }
        private bool _isReviewerSelected;
        public bool IsReviewerSelected
        {
            get
            {
                return _isReviewerSelected;
            }
            set
            {
                SetProperty(ref _isReviewerSelected, value);
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
            IsDeleteButtonVisible = false;
            ReviewerSpecificComment = "";
            SelectedReviewerSpecificComment = null;
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

        private ObservableCollection<SystemAndUserSpCondition> _reviewerAllConditonsList=new ObservableCollection<SystemAndUserSpCondition>();

        public ObservableCollection<SystemAndUserSpCondition> ReviewerAllConditonsList
        {
            get
            {

                return _reviewerAllConditonsList;
            }
            set
            {
                SetProperty(ref _reviewerAllConditonsList, value);
            }
        }


        private ObservableCollection<StackholderConditionInReviewerPageModel> _stackHolderCommentsList=new ObservableCollection<StackholderConditionInReviewerPageModel>();

        public ObservableCollection<StackholderConditionInReviewerPageModel> StackHolderCommentsList
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
                    _saveCommand = new Command(SaveOrUpdateCommandExecute);
                }

                return _saveCommand;
            }
        }

        private async void SaveOrUpdateCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {
                if (SelectedReviewerSpecificComment!=null)
                {
                    //update
                    UpdateReviewerSpecificComment specificComment = new UpdateReviewerSpecificComment();
                    specificComment.CONDITIONS = ReviewerSpecificComment;
                    specificComment.TRA_SPECCOND_ID = SelectedReviewerSpecificComment.TRA_SPECCOND_ID;
                    string result = await ApiService.Instance.UpdateReviewerSpecificComment(specificComment);
                   
                    ReviewerSpecificComment = "";
                    IsReviewerAddCommentButtonVisible = true;
                    IsDeleteButtonVisible = false;
                    SelectedReviewerSpecificComment = new SystemAndUserSpCondition();
                   await GetAndFillConditionSpecificPart(TransactonDetail.Transaction.TransactionID.ToString());
                    await Application.Current.MainPage.DisplayToastAsync("Updated successfully");
                }
                else
                {
                    //Save
                    PostReviewerSpecificComment saveCondition = new PostReviewerSpecificComment();
                    saveCondition.CONDITIONS = ReviewerSpecificComment;
                    saveCondition.TRANSACTIONID = TransactonDetail.Transaction.TransactionID;
                    string result = await ApiService.Instance.PostreviewerSpecificComment(saveCondition);
                    ReviewerSpecificComment = "";
                    IsReviewerAddCommentButtonVisible = true;
                    IsDeleteButtonVisible = false;
                    await GetAndFillConditionSpecificPart(TransactonDetail.Transaction.TransactionID.ToString());
                    await Application.Current.MainPage.DisplayToastAsync("Saved successfully");
                }

              
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

        private bool _isDeleteButtonVisible;
        public bool IsDeleteButtonVisible
        {
            get
            {
                return _isDeleteButtonVisible;
            }
            set
            {
                SetProperty(ref _isDeleteButtonVisible, value);
            }
        }


         private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new Command(DeleteCommandExecute);
                }

                return _deleteCommand;
            }
        }

      
        private void CancelCommandExecute(object obj)
        {
            IsReviewerAddCommentButtonVisible = true;
            IsDeleteButtonVisible = false;
            ReviewerSpecificComment = "";
            SelectedReviewerSpecificComment = null;
        }


        private async void DeleteCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {
                if (SelectedReviewerSpecificComment != null)
                {
                    //delete
                    var response=   await ApiService.Instance.deleteReviewerSpecificCustomCondition(SelectedReviewerSpecificComment.TRA_SPECCOND_ID.ToString());
                    ReviewerSpecificComment = "";
                    IsReviewerAddCommentButtonVisible = true;
                    SelectedReviewerSpecificComment = null;
                    IsDeleteButtonVisible = false;
                    await GetAndFillConditionSpecificPart(TransactonDetail.Transaction.TransactionID.ToString());
                    await Application.Current.MainPage.DisplayToastAsync(response.ToString());
                }
                else
                {
                    IsReviewerAddCommentButtonVisible = true;
                    IsDeleteButtonVisible = false;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayToastAsync(ex.ToString());
            }
            IsBusy = false;
        }


        private ICommand _selectUserConditionCommand;

        public ICommand SelectUserConditionCommand
        {
            get
            {
                if (_selectUserConditionCommand == null)
                {
                    _selectUserConditionCommand = new Command(SelectUserConditionCommandExecute);
                }

                return _selectUserConditionCommand;
            }
        }

        private void SelectUserConditionCommandExecute(object obj)
        {
            SelectedReviewerSpecificComment= obj as SystemAndUserSpCondition;
            if (SelectedReviewerSpecificComment.COMMENTTYPE == "User")
            {
                IsReviewerAddCommentButtonVisible = false;
                IsDeleteButtonVisible = true;
                ReviewerSpecificComment = SelectedReviewerSpecificComment.CONDITIONS;
            }
            
        }





        private SystemAndUserSpCondition _selectedReviewerSpecificComment;
        public SystemAndUserSpCondition SelectedReviewerSpecificComment
        {
            get
            {
                return _selectedReviewerSpecificComment;
            }
            set
            {
                SetProperty(ref _selectedReviewerSpecificComment, value);
            }
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
                if (StackHolderList.Count > 0)
                {
                    SelectedStackholderName = StackHolderList.FirstOrDefault().ERGroup;
                }
               
                AllstackHolderResponseList = new ObservableCollection<AllStackholderResponse>(await ApiService.Instance.GetAllStackHolderResponseData(transactionID));//319
                if (StackHolderList.Count > 0)
                {
                    SelectedStackholderResponse = AllstackHolderResponseList.FirstOrDefault(x => x.StakeholderID == StackHolderList.FirstOrDefault()?.ERStakeHoldersID);
                }
                ExistingComment = await ApiService.Instance.GetReviewerSpecificComment(transactionID);//319
                SpecificMessageText = ExistingComment?.Comment??"";
                getLatestAttachmentsForStackHolder(SelectedStackholderResponse?.TransactionID.ToString(), SelectedStackholderResponse?.UserSolutionRole.ToString());

                getLatestAttachmentsForReviewerComments(ExistingComment?.SthcmntID??0);


               bool success= await GetAndFillConditionSpecificPart(transactionID);


                //Phase 2 Changes

             bool successStatus= await  GetAllDetails(transactionID);



            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private async Task<bool> GetAllDetails(string transactionID)
        {
            string officerResponseDetails = await ApiService.Instance.GenericGetApiCall(Urls.OfficerResponseDetails + transactionID);
            OfficerResponseDetails = JsonConvert.DeserializeObject<OfficerResponseDetailsModel>(officerResponseDetails);

            string officerResponseAttachments = await ApiService.Instance.GenericGetApiCall(Urls.OfficerResponseBlockAttachments + transactionID);
            OfficerResponseAttachmentsInReviewerResponseList =new ObservableCollection<OfficerResponseAttachmentsInReviewerResponse>( JsonConvert.DeserializeObject<List<OfficerResponseAttachmentsInReviewerResponse>>(officerResponseAttachments));

            var res = GetAndFillConditionSpecificPart(transactionID);


            return true;
        }

        private async Task<bool> GetAndFillConditionSpecificPart(string transactionID)
        {
            //StackHolderCommentsList = new ObservableCollection<StackholderConditionInReviewerPageModel>(await ApiService.Instance.StackHolderCommentsForCondition(transactionID));//319
            //ReviewerAllConditonsList = new ObservableCollection<SystemAndUserSpCondition>(await ApiService.Instance.GetReviewerConditons(TransactonDetail.Transaction.TransactionNumber));

            //return StackHolderCommentsList.Count > 0;


            //New
            var conditions = await ApiService.Instance.GetReviewerConditions(transactionID);
            StackHolderAndOfficerSpecifcConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>(conditions);
            return StackHolderAndOfficerSpecifcConditionsList.Count > 0;
        }


       

        public async void getLatestAttachmentsForStackHolder(String transactionID,string userSolutionRole)
        {
            IsBusy = true;
            try
            {
                 // StackholderAttachmentsModelList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(SthcmntID.ToString()));//376
                StackholderAttachmentsModelList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(transactionID, userSolutionRole, true));//376

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        public async void getLatestAttachmentsForReviewerComments(int SthcmntID)
        {
            IsBusy = true;
            try
            {

                AttachmentList = new ObservableCollection<CommentsRelatedAttachmentModel>(await ApiService.Instance.GetCommentsRelatedAttachment(ExistingComment?.TransactionID.ToString(), ExistingComment?.UserSolutionRole.ToString(), false));

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }


        //Phase 2 Properties

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                ObservableCollection<OfficerResponseAttachmentsInReviewerResponse> _StackholderAttachmentsModelList = new ObservableCollection<OfficerResponseAttachmentsInReviewerResponse>();
                foreach (var item in OfficerResponseAttachmentsInReviewerResponseList)
                {
                    item.IsSelected = isChecked;
                    _StackholderAttachmentsModelList.Add(item);
                }
                OfficerResponseAttachmentsInReviewerResponseList.Clear();
                OfficerResponseAttachmentsInReviewerResponseList = _StackholderAttachmentsModelList;
                return isChecked;
            }
            set
            {
                SetProperty(ref isChecked, value);
            }
        }

        private bool isCheckedForAgreeget;
        public bool IsCheckedForAgreeget
        {
            get
            {
                ObservableCollection<OfficerResponseAttachmentsInReviewerResponse> _StackholderAttachmentsModelList = new ObservableCollection<OfficerResponseAttachmentsInReviewerResponse>();
                foreach (var item in OfficerResponseAttachmentsInReviewerResponseList)
                {
                    item.IsCheckedForAgreeget = isCheckedForAgreeget;
                    _StackholderAttachmentsModelList.Add(item);
                }
                OfficerResponseAttachmentsInReviewerResponseList.Clear();
                OfficerResponseAttachmentsInReviewerResponseList = _StackholderAttachmentsModelList;
                return isCheckedForAgreeget;
            }
            set
            {
                SetProperty(ref isCheckedForAgreeget, value);
            }
        }
         private bool _isCheckedForConditionAgreeget;
        public bool IsCheckedForConditionAgreeget
        {
            get
            {
                ObservableCollection<StackHolderAndOfficerSpecifcConditions> TempStackHolderAndOfficerSpecifcConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>();
                foreach (var item in StackHolderAndOfficerSpecifcConditionsList)
                {
                    item.IsCheckedForConditionAgreeget = _isCheckedForConditionAgreeget;
                    TempStackHolderAndOfficerSpecifcConditionsList.Add(item);
                }
                StackHolderAndOfficerSpecifcConditionsList.Clear();
                StackHolderAndOfficerSpecifcConditionsList = TempStackHolderAndOfficerSpecifcConditionsList;
                return _isCheckedForConditionAgreeget;
            }
            set
            {
                SetProperty(ref _isCheckedForConditionAgreeget, value);
            }
        }

        private OfficerResponseDetailsModel _officerResponseDetails;
        public OfficerResponseDetailsModel OfficerResponseDetails
        {
            get
            {
                return _officerResponseDetails;
            }
            set
            {
                SetProperty(ref _officerResponseDetails, value);
            }
        }
        

        private ObservableCollection<OfficerResponseAttachmentsInReviewerResponse> _officerResponseAttachmentsInReviewerResponseList = new ObservableCollection<OfficerResponseAttachmentsInReviewerResponse>();

        public ObservableCollection<OfficerResponseAttachmentsInReviewerResponse> OfficerResponseAttachmentsInReviewerResponseList
        {
            get
            {

                return _officerResponseAttachmentsInReviewerResponseList;
            }
            set
            {
                SetProperty(ref _officerResponseAttachmentsInReviewerResponseList, value);
            }
        }



         private ObservableCollection<StackHolderAndOfficerSpecifcConditions> _stackHolderAndOfficerSpecifcConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>();

        public ObservableCollection<StackHolderAndOfficerSpecifcConditions> StackHolderAndOfficerSpecifcConditionsList
        {
            get
            {

                return _stackHolderAndOfficerSpecifcConditionsList;
            }
            set
            {
                SetProperty(ref _stackHolderAndOfficerSpecifcConditionsList, value);
            }
        }


        private ICommand _aggregateCondtionCommand;

        public ICommand AggregateCondtionCommand
        {
            get
            {
                if (_aggregateCondtionCommand == null)
                {
                    _aggregateCondtionCommand = new Command(AggregateCondtionCommandExecute);
                }

                return _aggregateCondtionCommand;
            }
        }

        private async void AggregateCondtionCommandExecute(object obj)
        {
            #region Phase 2 Implementation for agregate Conditions 

            List<String> conditiionIDs = new List<string>();
            foreach (var con in StackHolderAndOfficerSpecifcConditionsList)
            {
                conditiionIDs.Add(con.IsCheckedForConditionAgreeget ? con.TRA_SPECCOND_ID.ToString() : "a" + con.TRA_SPECCOND_ID.ToString());
            }
            string responseData = await ApiService.Instance.GenericPostApiCall(Urls.AgreGateReviewerConditions, conditiionIDs);
            if(!string.IsNullOrEmpty(responseData))
            {
                await Application.Current.MainPage.DisplayToastAsync("Conditions Aggregated successfuly");
            }
            else
            {
                await Application.Current.MainPage.DisplayToastAsync("responseData");
            }
            #endregion
        }

    }
}
