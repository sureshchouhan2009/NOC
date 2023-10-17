using System;
using System.Collections.Generic;

namespace NOC.Models
{

    public class Authorizedrole
    {
        public int Roles { get; set; }
        public string RoleName { get; set; }
        public string AuthorizedName { get; set; }
        public int solutionroleid { get; set; }
    }

    public class UserAuthorizationModel
    {
        public string roles { get; set; }
        public string username { get; set; }
        public List<Authorizedrole> authorizedrole { get; set; }
        public string message { get; set; }
        public string ActiveRole { get; set; }
    }






    //public class Authorizedrole
    //{
    //    public int Roles { get; set; }
    //    public string RoleName { get; set; }
    //    public string AuthorizedName { get; set; }
    //    public int solutionroleid { get; set; }
    //}

    //public class UserAuthorizationModel
    //{
    //    public string roles { get; set; }
    //    public string username { get; set; }
    //    public List<Authorizedrole> authorizedrole { get; set; }
    //    public string message { get; set; }
    //}
}
