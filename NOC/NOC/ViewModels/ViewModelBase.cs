using NOC.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOC.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
        private ICommand goBackCommand;

        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new Command(GoBackExecute);
                }

                return goBackCommand;
            }
        }

        private async void GoBackExecute(object obj)
        {
           await NavigationService.GoBackAsync();
        }

        private bool _isBusy = false;
        public virtual bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value)
                {
                    Loading.Instance.ShowLoadingDialog();
                }
                else
                {
                    Loading.Instance.HideLoadingDialog();
                }
                SetProperty(ref _isBusy, value);
            }
        }
    }
}
