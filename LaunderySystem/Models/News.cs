using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Published")]
        public string DateAndTime { get; set; }

        [Display(Name = "Group")]
        public int? LaunderyGroup { get; set; }

        public virtual LaunderyRoom launderyRoom { get; set; }

    }
}