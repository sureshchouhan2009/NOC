using System;
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace NOC.Droid
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
         Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
         DataHost = "auth",
         DataScheme = "msald0c5284a-d006-4950-bdd4-1598d14219d6")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
