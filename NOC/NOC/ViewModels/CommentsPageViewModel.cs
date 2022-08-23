using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NOC.Enums;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.ViewModels
{
public class CommentsPageViewModel : ViewModelBase
{
        

    public CommentsPageViewModel(INavigationService navigationService) : base(navigationService)
    {
        PickerSource = new List<string>
        {
            "Replied","Not Replied"

        };

            IsToApplicantSelected = true;
            CurrentCommentsDate = DateTime.Now;
            CurrentUserTypeValue = getUsertypeStringValue();
            IsProcessorUser = getUsertypeStringValue() != "Applicant";

    }

        private string getUsertypeStringValue()
        {
            if (Session.Instance.CurrentUserType == UserTypes.Officer)
            {
                return "Officer";
            }
            else if (Session.Instance.CurrentUserType == UserTypes.Reviewer)
            {
                return "Reviewer";
            }
            else if (Session.Instance.CurrentUserType == UserTypes.Stackholder)
            {
                return "Stackholder";
            }
            else
            {
                return "Applicant";
            }
        }

        private string _currentUserTypeValue;
        public string CurrentUserTypeValue
        {
            get
            {
                return _currentUserTypeValue;
            }
            set
            {
                SetProperty(ref _currentUserTypeValue, value);
            }
        }

         private DateTime _currentCommentsDate;
        public DateTime CurrentCommentsDate
        {
            get
            {
                return _currentCommentsDate;
            }
            set
            {
                SetProperty(ref _currentCommentsDate, value);
            }
        }


        private int currentCommentType;
        public int CurrentCommentType
        {
            get
            {
                return currentCommentType;
            }
            set
            {
                SetProperty(ref currentCommentType, value);
            }
        }

        private bool _isNewCommentViewVisible;
        public bool IsNewCommentViewVisible
        {
            get
            {
                return _isNewCommentViewVisible;
            }
            set
            {
                SetProperty(ref _isNewCommentViewVisible, value);
            }
        }


        private ICommand addNewComment;

        public ICommand AddNewComment
        {
            get
            {
                if (addNewComment == null)
                {
                    addNewComment = new Command(AddNewCommentCommandExecute);
                }

                return addNewComment;
            }
        }

        private void AddNewCommentCommandExecute(object obj)
        {
            CurrentCommentType = Convert.ToInt32(obj);
            IsNewCommentViewVisible = true;
            if (CurrentCommentType == 1)
            {
                IsToApplicantSelected = true;
                IsToInternalSelected = false;
            }
            else
            {
                IsToApplicantSelected = false;
                IsToInternalSelected = true;
            }
        }

        private List<Attchtypeandfilepath> attachmentList= new List<Attchtypeandfilepath>();
    public List<Attchtypeandfilepath> AttachmentList
    {
        get
        {
            return attachmentList;
        }
        set
        {
            SetProperty(ref attachmentList, value);
        }
    }


        private ICommand saveNewCommentCommand;

        public ICommand SaveNewCommentCommand
        {
            get
            {
                if (saveNewCommentCommand == null)
                {
                    saveNewCommentCommand = new Command(SaveNewCommentCommandExecute);
                }

                return saveNewCommentCommand;
            }
        }

        private async void SaveNewCommentCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {
                 //save applicat comment
                if (CurrentCommentType == 1)
                {
                    SaveNewCommentFromApplicantModel ApplicantRequestModel = new SaveNewCommentFromApplicantModel();
                    ApplicantRequestModel.CommentType = currentCommentType;
                    ApplicantRequestModel.Comment = NewCommentText;
                    ApplicantRequestModel.UserID = Session.Instance.CurrentUserID;
                    ApplicantRequestModel.TransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionID;
                    ApplicantRequestModel.CommentsDate = DateTime.Now;

                    string commentID = await ApiService.Instance.SaveNewCommentCommonforApplicantAndInternal(ApplicantRequestModel);
                    
                    if (commentID != "" && AttachmentList.Count > 0)
                    {
                        MediaAttachmentModel AttModel = new MediaAttachmentModel();

                        foreach(var listitem in AttachmentList)
                        {
                            listitem.commentID = int.Parse(commentID);
                        }

                        AttModel.attchtypeandfilepath = AttachmentList;


                       
                        AttModel.attachments = new Attachments
                        {
                            TransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionID, //trasactionID,
                            UserID = Session.Instance.CurrentUserID,
                    };

                        AttModel.RandomID = "";
                        AttModel.TransactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;


                        var attacmentSaveResponse = await ApiService.Instance.SaveCommentAttachmentToDB(AttModel);

                        await Application.Current.MainPage.DisplayToastAsync(attacmentSaveResponse);
                    
                    if (commentID != "")
                    {
                        NewCommentText = "";
                        IsNewCommentViewVisible = false;
                        await getLatestComments();
                        CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == currentCommentType));
                        AttachmentList.Clear();
                        await Application.Current.MainPage.DisplayToastAsync("Saved successfully");// after successful call clear already posted attachments from List object

                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync("Failed please try again later");
                    }



                    }

                }
                else
                {
                    SaveNewCommentFromApplicantModel InternalCommentRequestModel = new SaveNewCommentFromApplicantModel();
                    InternalCommentRequestModel.CommentType = currentCommentType;
                    InternalCommentRequestModel.Comment = NewCommentText;
                    InternalCommentRequestModel.UserID = Session.Instance.CurrentUserID;
                    InternalCommentRequestModel.TransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionID;
                    InternalCommentRequestModel.CommentsDate = DateTime.Now;
                   string responsecommentID = await ApiService.Instance.SaveNewCommentCommonforApplicantAndInternal(InternalCommentRequestModel);

                    if (responsecommentID != "" && AttachmentList.Count > 0)
                    {
                        MediaAttachmentModel AttModel = new MediaAttachmentModel();

                        foreach (var listitem in AttachmentList)
                        {
                            listitem.commentID = int.Parse(responsecommentID);
                        }

                        AttModel.attchtypeandfilepath = AttachmentList;



                        AttModel.attachments = new Attachments
                        {
                            TransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionID, //trasactionID,
                            UserID = Session.Instance.CurrentUserID,
                        };

                        AttModel.RandomID = "";
                        AttModel.TransactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;


                        var attacmentSaveResponse = await ApiService.Instance.SaveCommentAttachmentToDB(AttModel);

                        await Application.Current.MainPage.DisplayToastAsync(attacmentSaveResponse);

                        if (responsecommentID != "")
                        {
                            NewCommentText = "";
                            IsNewCommentViewVisible = false;
                            await getLatestComments();
                            CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == currentCommentType));
                            AttachmentList.Clear();
                            await Application.Current.MainPage.DisplayToastAsync("Saved successfully");// after successful call clear already posted attachments from List object

                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayToastAsync("Failed please try again later");
                        }



                    }



                    //if (response != "")
                    //{
                    //    NewCommentText = "";
                    //    IsNewCommentViewVisible = false;
                    //   await getLatestComments();
                    //    CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == currentCommentType));

                    //    await Application.Current.MainPage.DisplayToastAsync("Saved successfully");
                    //}
                }
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private ICommand _submitNewCommentsForApplicatOnlyCommand;

        public ICommand SubmitNewCommentsForApplicatOnlyCommand
        {
            get
            {
                if (_submitNewCommentsForApplicatOnlyCommand == null)
                {
                    _submitNewCommentsForApplicatOnlyCommand = new Command(SubmitNewCommentsForApplicatOnlyCommandExecute);
                }

                return _submitNewCommentsForApplicatOnlyCommand;
            }
        }

        private async void SubmitNewCommentsForApplicatOnlyCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {
                SubmitApplicantCommentsModel submitCommentsModel = new SubmitApplicantCommentsModel();
                submitCommentsModel.transactionid= Session.Instance.CurrentTransaction.Transaction.TransactionNumber;//AUH-20220728-1001
                submitCommentsModel.userID= Session.Instance.CurrentUserID;
                submitCommentsModel.transid = Session.Instance.CurrentTransaction.Transaction.TransactionID;//3978
                var response=  await ApiService.Instance.SubmitNewCommentCommonforApplicantOnly(submitCommentsModel);
                await getLatestComments();
                CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == currentCommentType));
                await Application.Current.MainPage.DisplayToastAsync("Submitted successfully");
            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private string newCommentText;
        public string NewCommentText
        {
            get
            {
                return newCommentText;
            }
            set
            {
                SetProperty(ref newCommentText, value);
            }
        }


        private string selectedFilter;
    public string SelectedFilter
    {
        get
        {
            return selectedFilter;
        }
        set
        {
            SetProperty(ref selectedFilter, value);
        }
    }

        private bool isApplicantUser;
        public bool IsApplicantUser
        {
            get
            {
                return isApplicantUser;
            }
            set
            {
                SetProperty(ref isApplicantUser, value);
            }
        }

        private bool _isProcessorUser;
        public bool IsProcessorUser
        {
            get
            {
                return _isProcessorUser;
            }
            set
            {
                SetProperty(ref _isProcessorUser, value);
            }
        }



        private bool isToApplicantSelected;
        public bool IsToApplicantSelected
        {
            get
            {
                return isToApplicantSelected;
            }
            set
            {
                SetProperty(ref isToApplicantSelected, value);
            }
        }


        private bool isToInternalSelected;
        public bool IsToInternalSelected
        {
            get
            {
                return isToInternalSelected;
            }
            set
            {
                SetProperty(ref isToInternalSelected, value);
            }
        }
        private ICommand toInternalTapped;

        public ICommand ToInternalTapped
        {
            get
            {
                if (toInternalTapped == null)
                {
                    toInternalTapped = new Command(ToInternalTappedCommandExecute);
                }

                return toInternalTapped;
            }
        }

        private void ToInternalTappedCommandExecute(object obj)
        {
            int inputValue=  Convert.ToInt32( obj);
            CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == inputValue));

            if (inputValue == 2)
            {
                IsToInternalSelected = true;
                IsToApplicantSelected = false;
            }
            else
            {
               
                IsToInternalSelected = false;
                IsToApplicantSelected = true;
            }
           
        }

        private ICommand pickerIndexChangedCommand;

    public ICommand PickerIndexChangedCommand
    {
        get
        {
            if (pickerIndexChangedCommand == null)
            {
                pickerIndexChangedCommand = new Command(PickerIndexChangedCommandExecute);
            }

            return pickerIndexChangedCommand;
        }
    }

    private void PickerIndexChangedCommandExecute(object obj)
    {
        if(selectedFilter== "Replied")
        {

        }
        else
        {

        }
    }

    private ICommand accendingTappedCommand;

    public ICommand AccendingTappedCommand
    {
        get
        {
            if (accendingTappedCommand == null)
            {
                accendingTappedCommand = new Command(AccendingTappedCommandExecute);
            }

            return accendingTappedCommand;
        }
    }

    private void AccendingTappedCommandExecute(object obj)
    {

        try
        {

            var tempList = Session.Instance.CurerentTransactionCommentsList.OrderBy(x => x.Comments.CommentsDate).ToList();

            CommentsList.Clear();
            CommentsList = new ObservableCollection<CommentsModel>(tempList);

        }
        catch (Exception ex)
        {

        }

    }

    private ICommand decendingTappedCommand;

    public ICommand DecendingTappedCommand
    {
        get
        {
            if (decendingTappedCommand == null)
            {
                decendingTappedCommand = new Command(DecendingTappedCommandExecute);
            }

            return decendingTappedCommand;
        }
    }

    private void DecendingTappedCommandExecute(object obj)
    {

        try
        {

            var tempList = Session.Instance.CurerentTransactionCommentsList.OrderByDescending(x => x.Comments.CommentsDate).ToList();

            CommentsList.Clear();
            CommentsList = new ObservableCollection<CommentsModel>(tempList);

        }
        catch (Exception ex)
        {

        }

    }

    private ICommand addReplyCommand;

    public ICommand AddReplyCommand
    {
        get
        {
            if (addReplyCommand == null)
            {
                addReplyCommand = new Command(AddReplyCommandExecute);
            }

            return addReplyCommand;
        }
    }
 private ICommand _commentPageAttachmentShow;

    public ICommand CommentPageAttachmentShow
        {
        get
        {
            if (_commentPageAttachmentShow == null)
            {
                    _commentPageAttachmentShow = new Command(CommentPageAttachmentShowExecute);
            }

            return _commentPageAttachmentShow;
        }
    }

        private async void CommentPageAttachmentShowExecute(object obj)
        {
            IsBusy = true;
           
            try
            {

                var currentAttachment = obj as AttachmentModel;
                await Launcher.OpenAsync(currentAttachment.UrlPath);

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;
        }

        private void AddReplyCommandExecute(object obj)
    {
        try
        {
            var currentComment = obj as CommentsModel;
            int index = CommentsList.IndexOf(currentComment);

            var tempList = Session.Instance.CurerentTransactionCommentsList;
            tempList[index].IsReplyViewVisible = !currentComment.IsReplyViewVisible;
            CommentsList.Clear();
            CommentsList = new ObservableCollection<CommentsModel>(tempList);
        }
        catch (Exception ex)
        {

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

    private List<String> pickerSource = new List<string>();
    public List<String> PickerSource
    {
        get
        {
               
            return pickerSource;
        }
        set
        {
            SetProperty(ref pickerSource, value);
        }
    }

    private ObservableCollection<CommentsModel> commentsList = new ObservableCollection<CommentsModel>();
    public ObservableCollection<CommentsModel> CommentsList
    {
        get
        {
                
            return commentsList;
        }
        set
        {
            SetProperty(ref commentsList, value);
        }
    }
        
            private ICommand sendReplyToExistingCommand;

    public ICommand SendReplyToExistingCommand
    {
        get
        {
            if (sendReplyToExistingCommand == null)
            {
                sendReplyToExistingCommand = new Command(SendReplyToExistingCommandExecute);
            }

            return sendReplyToExistingCommand;
        }
    }
    private string messageText;
    public string MessageText
    {
        get
        {
            return messageText;
        }
        set
        {
            SetProperty(ref messageText, value);
        }
    }
    private async void SendReplyToExistingCommandExecute(object obj)
    {
        try
        {

            var currentComment = obj as CommentsModel;
            var trasactionID= Session.Instance.CurrentTransaction.Transaction.TransactionID;
            CommentReplyModel model = new CommentReplyModel();
            if (!String.IsNullOrEmpty(currentComment.ReplyMessageText))
            {
                model.Comment = currentComment.ReplyMessageText;
                model.CommentsDate = DateTime.Now;
                model.CommentType = 1;
                model.ParentCommentID = currentComment.Comments.CommentsID;
                model.TransactionID = trasactionID;
                model.UserID = currentComment.Comments.UserID;
                var response=  await ApiService.Instance.PostReplyComment(model);
                if (response && AttachmentList.Count>0)
                {
                    MediaAttachmentModel AttModel = new MediaAttachmentModel();
                    AttModel.attchtypeandfilepath = AttachmentList;
                    AttModel.attachments = new Attachments
                    {
                        TransactionID = trasactionID,
                        UserID = currentComment.Comments.UserID
                    };

                    AttModel.RandomID = "7569924447";
                    AttModel.TransactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;


                    var attacmentSaveResponse= await ApiService.Instance.SaveCommentAttachmentToDB(AttModel);

                    await Application.Current.MainPage.DisplayToastAsync(attacmentSaveResponse);
                }
                if (response)
                {

                    // currentComment.ReplyMessageText = "";
                         await  getLatestComments();
                        await Application.Current.MainPage.DisplayToastAsync("Reply Added successfully");
                        AttachmentList.Clear();// after successful call clear already posted attachments from List object
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Failed please try again later");
                }
                   
            }
            else
            {
                await Application.Current.MainPage.DisplayToastAsync("Enter Message");
            }
        }
        catch (Exception ex)
        {

        }
           
    }
       
    private ICommand addAttachmentForReplyCommentCommand;

    public ICommand AddAttachmentForReplyCommentCommand
    {
        get
        {
            if (addAttachmentForReplyCommentCommand == null)
            {
                addAttachmentForReplyCommentCommand = new Command(AddAttachmentForReplyCommentCommandExecute);
            }

            return addAttachmentForReplyCommentCommand;
        }
    }

      

    private async void AddAttachmentForReplyCommentCommandExecute(object obj)
    {
        try
        {
            var currentComment = obj as CommentsModel;
            var options = new PickOptions
            {
                PickerTitle = "Please select a file",
            };
            var result = await FilePicker.PickAsync();
            if (result != null)
            {
                var byteArray = await GeneralUtility.getByteArrayFromFile(result);
                string base64String = Convert.ToBase64String(byteArray);
                IsBusy = true;
                string serverFilePath = await ApiService.Instance.SaveCommentAttachment(new NewAttachmentModel
                {
                    strFile=base64String,
                    strFilename=result.FileName,
                    transactionid=TransactonDetail.Transaction.TransactionID
                });
                IsBusy = false;
                if (!string.IsNullOrEmpty(serverFilePath))
                {
                    AttachmentList.Add(new Attchtypeandfilepath
                    {
                        filepath = serverFilePath,
                        commentID = currentComment?.Comments?.CommentsID??0,
                        Attachmenttype = 3
                    });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync("Failed please try again later");
                    }
            }
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }
    }

    public override async void OnNavigatedTo(INavigationParameters parameters)
    {
        IsBusy = true;
        base.OnNavigatedTo(parameters);
        await getLatestComments();
        IsBusy = false;
    }

        

    private async Task<bool> getLatestComments()
    {
        var transactionDetails = Session.Instance.CurrentTransaction;
        Session.Instance.CurerentTransactionCommentsList = await ApiService.Instance.GetTransactionComents(transactionDetails.Transaction.TransactionNumber);
        //CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList);
        CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList.Where(e => e.Comments.CommentType == 1));

            return commentsList.Count > 0;
    }
}

}
