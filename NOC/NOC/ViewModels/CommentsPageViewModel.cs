using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
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


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            var transactionDetails = Session.Instance.CurrentTransaction;
            //CommentsList = new ObservableCollection<CommentsModel>( await ApiService.Instance.GetTransactionComents(transactionDetails.Transaction.TransactionNumber));
            Session.Instance.CurerentTransactionCommentsList =  await ApiService.Instance.GetTransactionComents("RKT-20220330-1004");
            CommentsList = new ObservableCollection<CommentsModel>(Session.Instance.CurerentTransactionCommentsList);
            IsBusy = false;
        }

    }
}
