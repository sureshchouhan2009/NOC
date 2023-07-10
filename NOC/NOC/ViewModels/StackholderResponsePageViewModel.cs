using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class StackholderResponsePageViewModel: ViewModelBase
    {
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
        private bool _isStackholderResponseSelected;
        public bool IsStackholderResponseSelected
        {
            get
            {
                return _isStackholderResponseSelected;
            }
            set
            {
                SetProperty(ref _isStackholderResponseSelected, value);
            }
        }

       

        public StackholderResponsePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
            IsStackholderResponseSelected = true;
            IsConditionSelected = false;
        }
        private ICommand _stackholderResponseTappedCommand;

        public ICommand StackholderResponseTappedCommand
        {
            get
            {
                if (_stackholderResponseTappedCommand == null)
                {
                    _stackholderResponseTappedCommand = new Command(StackholderResponseTappedCommandExecute);
                }

                return _stackholderResponseTappedCommand;
            }
        }

        private void StackholderResponseTappedCommandExecute(object obj)
        {
            IsStackholderResponseSelected = true;
            IsConditionSelected = false;
        }

        private ICommand _conditionTappedCommand;

        public ICommand ConditionTappedCommand
        {
            get
            {
                if (_conditionTappedCommand == null)
                {
                    _conditionTappedCommand = new Command(ConditionTappedCommandExecute);
                }

                return _conditionTappedCommand;
            }
        }

        private void ConditionTappedCommandExecute(object obj)
        {
           
            IsStackholderResponseSelected = false;
            IsConditionSelected = true;
        }




       

        private ObservableCollection<StackHolderAndOfficerSpecifcConditions> _stackholderConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>();

        public ObservableCollection<StackHolderAndOfficerSpecifcConditions> StackholderConditionsList
        {
            get
            {

                return _stackholderConditionsList;
            }
            set
            {
                SetProperty(ref _stackholderConditionsList, value);
            }
        }
        private ObservableCollection<StakeHolderAttachment> _StackholderAttachmentsModelList = new ObservableCollection<StakeHolderAttachment>();
        public ObservableCollection<StakeHolderAttachment> StackholderAttachmentsModelList
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

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            try
            {
                //OfficerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>( await ApiService.Instance.GetOffficerResponseCondition(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString()));
                StackholderConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>(await ApiService.Instance.GetStackholderResponseCondition(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString(), "Operations"));
                var data = await ApiService.Instance.GetStackholderResponsePageData(Session.Instance.SthcmntID.ToString());
                StackholderAttachmentsModelList = new ObservableCollection<StakeHolderAttachment>(data.StakeHolderAttachments);//376
            }
            catch (Exception ex)
            {
            }
            IsBusy = false;
        }
        private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        {
            IsBusy = true;
            var currentModel = obj as StakeHolderAttachment;
            IDownloader downloader = DependencyService.Get<IDownloader>();
            downloader.OnFileDownloaded += OnFileDownloaded;
            downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
            IsBusy = false;
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                Application.Current.MainPage.DisplayAlert("Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Downloader", "Error while saving the file", "Close");
            }
        }
    }
}
