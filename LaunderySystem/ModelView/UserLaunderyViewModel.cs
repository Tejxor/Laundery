using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaunderySystem.Models;

namespace LaunderySystem.ModelView
{
    public class UserLaunderyViewModel
    {
        public UserProfile userProfile { get; set; }
        public LaunderyRoom launderyRoom { get; set; }
    }
}