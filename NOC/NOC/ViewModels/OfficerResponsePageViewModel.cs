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
    public class OfficerResponsePageViewModel:ViewModelBase
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
        private bool _isOfficerResponseSelected;
        public bool IsOfficerResponseSelected
        {
            get
            {
                return _isOfficerResponseSelected;
            }
            set
            {
                SetProperty(ref _isOfficerResponseSelected, value);
            }
        }



        public OfficerResponsePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Transaction Info";
            IsOfficerResponseSelected = true;
            IsConditionSelected = false;
        }
        private ICommand _officerResponseTappedCommand;

        public ICommand OfficerResponseTappedCommand
        {
            get
            {
                if (_officerResponseTappedCommand == null)
                {
                    _officerResponseTappedCommand = new Command(OfficerResponseTappedCommandExecute);
                }

                return _officerResponseTappedCommand;
            }
        }

        private void OfficerResponseTappedCommandExecute(object obj)
        {
            IsOfficerResponseSelected = true;
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

            IsOfficerResponseSelected = false;
            IsConditionSelected = true;
        }
        private ObservableCollection<StackHolderAndOfficerSpecifcConditions> _officerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>();

        public ObservableCollection<StackHolderAndOfficerSpecifcConditions> OfficerConditionsList
        {
            get
            {

                return _officerConditionsList;
            }
            set
            {
                SetProperty(ref _officerConditionsList, value);
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
                OfficerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>( await ApiService.Instance.GetOffficerResponseCondition(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString()));
                // OfficerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>( await ApiService.Instance.GetOffficerResponseCondition("15837"));

                //thhis is for review desition tab data
                var data = await ApiService.Instance.GetStackholderResponsePageData(Session.Instance.SthcmntID.ToString());//"2287"
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
