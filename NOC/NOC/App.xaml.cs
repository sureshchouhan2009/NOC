using NOC.Service;
using NOC.Utility;
using NOC.ViewModels;
using NOC.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace NOC
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }
        private bool CheckIfLoggedIn()
        {
            // this one check if needed this data
            #region Get looged in person details
            Preferences.Get("UserName", "");
            Preferences.Get("Password", "");
            #endregion
            return Preferences.Get("IsLoggedIN", false);
        }
        protected override async void OnInitialized()
        {
            try
            {

                InitializeComponent();
                if (CheckIfLoggedIn())
                {
                    Session.Instance.Token = Preferences.Get("Token", "");
                    // also need to check for User Type and accordingly navigate

                    if (Session.Instance.Token != "")
                    {
                       
                        await NavigationService.NavigateAsync("/HomePage");
                       
                    }
                    else
                    {
                        await NavigationService.NavigateAsync("/LoginPage");
                    }

                }
                else
                {
                    await NavigationService.NavigateAsync("/LoginPage");
                }
            }
            catch (Exception ex)
            {

               
            }
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationsPage, NotificationsPageViewModel>();
            containerRegistry.RegisterForNavigation<ApplicationsListPage, ApplicationsListPageViewModel>();
            containerRegistry.RegisterForNavigation<TransactionInfoPage, TransactionInfoPageViewModel>();
        }
    }
}
