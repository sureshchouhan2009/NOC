using System;
namespace NOC.Constants
{
    public static class B2CConstants
    {
        // // Azure AD B2C Coordinates
        // public static string Tenant = "login.microsoftonline.com";
        //// public static string Tenant = "fabrikamb2c.onmicrosoft.com";
        // public static string AzureADB2CHostname = "login.microsoftonline.com/";
        //// public static string AzureADB2CHostname = "fabrikamb2c.b2clogin.com";
        // public static string ClientID = "d5d7b63f-8fca-4c01-852a-5bb9a1bc54f0";
        //// public static string ClientID = "e5737214-6372-472c-a85a-68e8fbe6cf3c";
        // public static string PolicySignUpSignIn = "b2c_1_susi";
        // public static string PolicyEditProfile = "b2c_1_edit_profile";
        // public static string PolicyResetPassword = "b2c_1_reset";

        //// public static string[] Scopes = { "https://fabrikamb2c.onmicrosoft.com/helloapi/demo.read" };
        // public static string[] Scopes = { "User.Read" };

        // public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        // public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        // public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        // public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        // public static string IOSKeyChainGroup = "com.microsoft.adalcache";




        // Azure AD B2C Coordinates
        public static string Tenant = "d8fe2380-bb19-4228-a83f-c9e0b75ccd43";
        public static string AzureADB2CHostname = "portal.gpceast.com/noc/login";
        public static string ClientID = "c81f8d46-d18d-4b36-8cf7-23f0b5a4397e";
        public static string PolicySignUpSignIn = "b2c_1_susi";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] Scopes = { "https://graph.microsoft.com/.default" };

        public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup = "com.microsoft.adalcache";
    }
}
    

