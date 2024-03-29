
using NOC.Enums;
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
       
        public static NOC.Interfaces.IPlatform PlatformService { get; set; }

        public App(NOC.Interfaces.IPlatform platformService)
        {
            PlatformService = platformService;
            //InitializeComponent();
        }

        //public App(IPlatformInitializer initializer) : base(initializer)

        //{
        //}




        private bool CheckIfLoggedIn()
        {
            // this one check if needed this data
            #region Get looged in person details
            Preferences.Get("UserName", "");
            Preferences.Get("Password", "");
            
            if(Preferences.Get("UserType", "")== "Officer")
            {
                Session.Instance.CurrentUserType = UserTypes.Officer;
            }
            else if(Preferences.Get("UserType", "") == "Reviewer")
            {
                Session.Instance.CurrentUserType = UserTypes.Reviewer;
            }
            else if (Preferences.Get("UserType", "") == "Stackholder")
            {
                Session.Instance.CurrentUserType = UserTypes.Stackholder;
            }
            else
            {
                Session.Instance.CurrentUserType = UserTypes.Applicant;
            }
           
            #endregion
            return Preferences.Get("IsLoggedIN", false);
        }
        //protected override async void OnInitialized()
        //{
        //    try
        //    {

        //        InitializeComponent();
        //        if (CheckIfLoggedIn())
        //        {
        //            Session.Instance.Token = Preferences.Get("Token", "");
        //            Session.Instance.CurrentUserID = Preferences.Get("CurrentUserID", "");
        //            // also need to check for User Type and accordingly navigate

        //            if (Session.Instance.Token != "" && Session.Instance.CurrentUserID != "")
        //            {

        //                await NavigationService.NavigateAsync("/MainPage");

        //            }
        //            else
        //            {
        //                await NavigationService.NavigateAsync("/MainPage");
        //            }

        //        }
        //        else
        //        {
        //            await NavigationService.NavigateAsync("/MainPage");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}


        protected override async void OnInitialized()
        {
            try
            {
                InitializeComponent();
                if (CheckIfLoggedIn())
                {
                    Session.Instance.Token = Preferences.Get("Token", "");
                    Session.Instance.CurrentUserID = Preferences.Get("CurrentUserID", "");
                    // also need to check for User Type and accordingly navigate

                    if (Session.Instance.Token != "" && Session.Instance.CurrentUserID != "")
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
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<CommentsPage, CommentsPageViewModel>();
            containerRegistry.RegisterForNavigation<TrasactionAacceptancePage, TrasactionAacceptancePageViewModel>();
            containerRegistry.RegisterForNavigation<NewAddCommentPage, NewAddCommentPageViewModel>();
            containerRegistry.RegisterForNavigation<StackholderResponsePage, StackholderResponsePageViewModel>();
            containerRegistry.RegisterForNavigation<OfficerResponsePage, OfficerResponsePageViewModel>();


        }
    }
}
