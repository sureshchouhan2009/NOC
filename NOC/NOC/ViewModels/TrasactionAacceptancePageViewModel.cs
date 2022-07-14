﻿using System;
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
            IsReviewerDecisionSelected = true;
            IsConditionSelected = false;


            IsReviewerConditionFlow = true;
            IsStackholderCommentsFlow = true;
            IsStackHolderSelected = true;
            IsReviewerSelected = false;
            Title = "Transaction Info";
            DDSourceList.Add("Days");
            DDSourceList.Add("Months");
            DDSourceList.Add("Years");
            DurationValuetext = "6";
            ValidityPickerSelectedItem = DDSourceList[1];
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
                if(DateTime.Parse(CalculatedValidTillDate) > DateTime.Now.Date.AddDays(7))
                {
                    ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                    objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                    objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                    objectionOptionPostModel.expirydate = DateTime.Now.AddDays(180).ToString("dd/MMM/yyyy");
                    var result = await ApiService.Instance.PostNoObjection(objectionOptionPostModel);
                    await Application.Current.MainPage.DisplayToastAsync(result);
                    await NavigationService.NavigateAsync("app:///HomePage");
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please enter a validity Duration");
                }


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

        private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        {
            IsBusy = true;
            var currentModel=  obj as CommentsRelatedAttachmentModel;
            IDownloader downloader = DependencyService.Get<IDownloader>();
            downloader.OnFileDownloaded += OnFileDownloaded;
            downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
            IsBusy = false;
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
                IsBusy = true;
                ObjectionOptionPostModel objectionOptionPostModel = new ObjectionOptionPostModel();
                objectionOptionPostModel.transactionid = TransactonDetail.Transaction.TransactionNumber;
                objectionOptionPostModel.userID = TransactonDetail.Transaction.UserID;
                objectionOptionPostModel.expirydate = CalculatedValidTillDate;
                var result = await ApiService.Instance.PostObjection(objectionOptionPostModel);
                await Application.Current.MainPage.DisplayToastAsync(result);
                await NavigationService.NavigateAsync("app:///HomePage");
                IsBusy =false;

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
            StackHolderCommentsList = new ObservableCollection<StackholderConditionInReviewerPageModel>(await ApiService.Instance.StackHolderCommentsForCondition(transactionID));//319
            ReviewerAllConditonsList = new ObservableCollection<SystemAndUserSpCondition>(await ApiService.Instance.GetReviewerConditons(TransactonDetail.Transaction.TransactionNumber));

            return StackHolderCommentsList.Count > 0;
        }


       

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
