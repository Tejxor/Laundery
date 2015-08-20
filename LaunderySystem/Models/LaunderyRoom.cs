using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class LaunderyRoom
    {
        public int Id { get; set; }


        [Display(Name = "Laundery Adress")]
        public string Adress { get; set; }

        [Display(Name = "Numbers of Launderyrooms")]
        public int NumbersOfGroups { get; set; }
    }
}