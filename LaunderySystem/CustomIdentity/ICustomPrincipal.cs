using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LaunderySystem.CustomIdentity
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Adress { get; set; }
        string LaunderyAdress { get; set; }
        string Role { get; set; }
    }
}
