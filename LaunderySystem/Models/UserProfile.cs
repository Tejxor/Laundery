using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int LaundId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string PassWord { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string TelefonNumber { get; set; }

        public string Adress { get; set; }

        [ForeignKey("LaundId")]
        public virtual LaunderyRoom LaunderyRoom { get; set; }

    }
}