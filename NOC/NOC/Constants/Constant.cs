using System;
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
        public static string ApplicationId = "d0c5284a-d006-4950-bdd4-1598d14219d6";

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
    

