using System;
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace NOC.Droid
{
    [Activity]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msalc81f8d46-d18d-4b36-8cf7-23f0b5a4397e")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
