using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();


            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    loginButton.CornerRadius = 30;
                    break;
                case Device.Android:
                    loginButton.CornerRadius = 40;
                    break;
                default:

                    loginButton.CornerRadius = 40;
                    break;
            }
        }
    }
}