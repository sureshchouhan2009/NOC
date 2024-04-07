using System;
using NOC.Service;

namespace NOC.Constants
{
    public static class Constant
    {
        /// <summary>
        /// The base URI for the Datasync service.
        /// </summary>
        //  public static string ServiceUri = "https://demo-datasync-quickstart.azurewebsites.net";

        /// <summary>
        /// The application (client) ID for the native app within Azure Active Directory
        /// </summary>
       // public static string ApplicationId = "d0c5284a-d006-4950-bdd4-1598d14219d6";//Dev

      //public static string ApplicationId = Urls.CurrentEnvironment=="Dev"? "d0c5284a-d006-4950-bdd4-1598d14219d6" : "9dee503f-f818-4f44-8eae-2a59ea1a3c1b";
        public const string ApplicationId = Urls.CurrentEnvironment=="Dev"? "42359128-3045-423f-a496-c994fc580130" : "9dee503f-f818-4f44-8eae-2a59ea1a3c1b";

        public static string TenantID = Urls.CurrentEnvironment == "Dev" ? "d8fe2380-bb19-4228-a83f-c9e0b75ccd43" : "d6046f1b-45b7-4bea-b72c-e12fd5ff8374";
        /// <summary>
        /// The list of scopes to request
        /// </summary>
        public static string[] Scopes = new[]
        {
            "api://ernocwebapi/ernocwebapi.read",
            "api://ernocwebapi/ernocwebapi.write",
        };

        /// <summary>
        /// The list of scopes to request
        /// </summary>
        //public static string[] Scopes = new[]
        //{
        //    "api://c81f8d46-d18d-4b36-8cf7-23f0b5a4397/ernocwebapi/ernocwebapi.read",
        //    "api://c81f8d46-d18d-4b36-8cf7-23f0b5a4397/ernocwebapi/ernocwebapi.write",
        //};


        // "api://8cce3678-ddac-4e1d-b811-34c07574fa3f/access_as_user_mobileapp_new"
    }
}
    

