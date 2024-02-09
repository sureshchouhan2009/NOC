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

        private bool _isApproved;
        public bool IsApproved
        {
            get
            {
                return _isApproved;
            }
            set
            {
                SetProperty(ref _isApproved, value);
            }
        }
        private bool _isApprovedWithCondition;
        public bool IsApprovedWithCondition
        {
            get
            {
                return _isApprovedWithCondition;
            }
            set
            {
                SetProperty(ref _isApprovedWithCondition, value);
            }
        }

        private bool _isRejected;
        public bool IsRejected
        {
            get
            {
                return _isRejected;
            }
            set
            {
                SetProperty(ref _isRejected, value);
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
                StackholderConditionsList = new ObservableCollection<StackHolderAndOfficerSpecifcConditions>(await ApiService.Instance.GetStackholderResponseCondition(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString(), Session.Instance.CurrentTransactionWorkFlow));
                var data = await ApiService.Instance.GetStackholderResponsePageData(Session.Instance.SthcmntID.ToString());
                StackholderAttachmentsModelList = new ObservableCollection<StakeHolderAttachment>(data.StakeHolderAttachments);//376

                switch (data.Stakeholdercomments?.Decision?.DecisionID??0)
                {
                    case 1:
                        IsApproved = true;
                        break;
                    case 2:
                        IsApprovedWithCondition = true;
                        break;
                    case 3:
                        IsRejected = true;
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            IsBusy = false;
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

                if (AIds.Count > 0)
                {
                    string responseUrl = await ApiService.Instance.GenericPostApiCall(Urls.DownloadMultipleAttachments, AIds);
                    string Url = JsonConvert.DeserializeObject<string>(responseUrl);
                    if (!string.IsNullOrEmpty(Url))
                    {
                        await Launcher.OpenAsync(Url);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayToastAsync(Url);
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayToastAsync("Please select attachment");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayToastAsync(ex.ToString());
            }
            IsBusy = false;



            #region Old Code
             //if (StackholderAttachmentsModelList.Any(i => i.IsSelected))
                 //{
                 //    IsBusy = true;
                 //    foreach (var item in StackholderAttachmentsModelList)
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
            #endregion
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
