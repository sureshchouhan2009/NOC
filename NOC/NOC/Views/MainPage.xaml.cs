
using System;
using NOC.Service;

namespace NOC.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var userContext = await B2CAuthenticationService.Instance.SignInAsync();
          
        }

       
    }
}
