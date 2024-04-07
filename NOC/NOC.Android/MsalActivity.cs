using System;
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;
using NOC.Constants;

namespace NOC.Droid
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
         Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
         DataHost = "auth",
        DataScheme = "msal"+Constant.ApplicationId)]

        // DataScheme = "msal9dee503f-f818-4f44-8eae-2a59ea1a3c1b")]

    public class MsalActivity : BrowserTabActivity
    {
    }
}
