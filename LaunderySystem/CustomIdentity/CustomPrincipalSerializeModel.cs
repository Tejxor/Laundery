using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunderySystem.CustomIdentity
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string LaunderyAdress { get; set; }
        public string Role { get; set; }
    }
}