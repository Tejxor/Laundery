using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class LaunderyContext:DbContext
    {

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<LaunderyRoom> LaunderyRoom { get; set; }
        public DbSet<ReservationLaunderyRoom> ReservationLaunderyRoom { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<EmailSettingModel> EmailSetting { get; set; }

        
    }
}