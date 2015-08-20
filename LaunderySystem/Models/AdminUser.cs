using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{//test
    public class AdminUser
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int roleId { get; set; }

        [ForeignKey("userId")]
        public virtual UserProfile UserProfile { get; set; }
        [ForeignKey("roleId")]
        public virtual Role Role { get; set; }

    }
}