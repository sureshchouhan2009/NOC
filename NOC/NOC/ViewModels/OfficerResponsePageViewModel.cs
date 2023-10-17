using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using NOC.Interfaces;
using NOC.Models;
using NOC.Service;
using NOC.Utility;
using Prism.Navigation;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
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
        private ObservableCollection<StackHolderAndResponseDisplayModel> _stackholderDisplayList = new ObservableCollection<StackHolderAndResponseDisplayModel>();
        public ObservableCollection<StackHolderAndResponseDisplayModel> StackholderDisplayList
        {
            get
            {
                return _stackholderDisplayList;
            }
            set
            {
                SetProperty(ref _stackholderDisplayList, value);
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
                var applicationNumber = Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString();

                OfficerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>( await ApiService.Instance.GetOffficerResponseCondition(applicationNumber));
                // OfficerConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>( await ApiService.Instance.GetOffficerResponseCondition("15837"));

                //middle part data fetching for Stackholders List

                //fetchAndConstructStackholderAndDecisionList(applicationNumber);
                fetchAndConstructStackholderAndDecisionList("15842");

            

                //thhis is for review desition tab data
                var data = await ApiService.Instance.GetStackholderResponsePageData(Session.Instance.SthcmntID.ToString());//"2287"
                StackholderAttachmentsModelList = new ObservableCollection<StakeHolderAttachment>(data.StakeHolderAttachments);//376

            }
            catch (Exception ex)
            {
            }
            IsBusy = false;
        }

        private async void fetchAndConstructStackholderAndDecisionList(string applicationNumber)
        {
            try
            {
                List<StackHolderListModel> StackHoldersList = new List<StackHolderListModel>();
                string ResponseSTK = await ApiService.Instance.GenericGetApiCall(Urls.getOfficerResponsepageStackholderList + applicationNumber);
                StackHoldersList = JsonConvert.DeserializeObject<List<StackHolderListModel>>(ResponseSTK);

                string Response = await ApiService.Instance.GenericGetApiCall(Urls.getOfficerResponsepageStackholderListForFilter + applicationNumber);
                List<StackHolderFilterModel> StackHoldersListModelForFilter = JsonConvert.DeserializeObject<List<StackHolderFilterModel>>(Response);
                foreach (var stk in StackHoldersList)
                {
                    var matchedItem = StackHoldersListModelForFilter.FirstOrDefault(st => st.ERStakeHoldersID == stk.StakeholderID);
                    if (matchedItem != null)
                    {
                        StackholderDisplayList.Add(new StackHolderAndResponseDisplayModel { Decision = stk.Decision, ERStakeHoldersCode = matchedItem.ERStakeHoldersCode });
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        //private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        //{
        //    IsBusy = true;
        //    var currentModel = obj as StakeHolderAttachment;
        //    IDownloader downloader = DependencyService.Get<IDownloader>();
        //    downloader.OnFileDownloaded += OnFileDownloaded;
        //    downloader.DownloadFile(currentModel.UrlPath, "XF_Downloads");
        //    IsBusy = false;
        //}

        private async void DownloadCommentsAttachmentsCommandExecute(object obj)
        {
            IsBusy = true;
            try
            {


                List<int> AIds = new List<int>();
                foreach (var item in StackholderAttachmentsModelList)
                {
                    if (item.IsSelected)
                    {
                        AIds.Add(item.AttachmentID);
                    }

                }

                string responseUrl = await ApiService.Instance.GenericPostApiCall(Urls.DownloadMultipleAttachments, AIds);
                if (!string.IsNullOrEmpty(responseUrl))
                {
                    await Launcher.OpenAsync(responseUrl);
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync(responseUrl);
                }

            }
            catch (Exception ex)
            {

            }
            IsBusy = false;



            //IsBusy = true;
            //foreach(var item in StackholderAttachmentsModelList)
            //{
            //    if (item.IsSelected)
            //    {
            //        IDownloader downloader = DependencyService.Get<IDownloader>();
            //        downloader.OnFileDownloaded += OnFileDownloaded;
            //        downloader.DownloadFile(item.UrlPath, "XF_Downloads");
            //    }

            //}


            //IsBusy = false;
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

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                ObservableCollection<StakeHolderAttachment> _StackholderAttachmentsModelList = new ObservableCollection<StakeHolderAttachment>();
                foreach (var item in StackholderAttachmentsModelList)
                {
                    item.IsSelected = isChecked;
                    _StackholderAttachmentsModelList.Add(item);
                }
                StackholderAttachmentsModelList.Clear();
                StackholderAttachmentsModelList = _StackholderAttachmentsModelList;
                return isChecked;
            }
            set
            {
                SetProperty(ref isChecked, value);
            }
        }

    }
}
