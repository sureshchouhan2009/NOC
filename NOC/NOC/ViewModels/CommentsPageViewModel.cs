using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
                    getLatestComments();
                        await Application.Current.MainPage.DisplayToastAsync("Reply Added successfully");
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
                PickerTitle = "Please select a comic file",
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
                        commentID = currentComment.Comments.CommentsID,
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
        CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList);
        return commentsList.Count > 0;
    }
}

}
