using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;


namespace LaunderySystem.CustomIdentity
{
    //more information
    //http://stackoverflow.com/questions/1064271/asp-net-mvc-set-custom-namespace    
 
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string LaunderyAdress { get; set; }
        public string Role { get; set; }
    }
}