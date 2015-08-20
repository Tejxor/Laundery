using LaunderySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunderySystem.Services
{
    public class AdminService : BaseService
    {
        public AdminService(LaunderyContext db)
        {
            this.db = db;
        }

        public List<AdminUser> GetAdmins()
        {
            return db.AdminUser.ToList();
        }

        public string GetAdmin(int? id)
        {
            try
            {
                AdminUser s = new AdminUser();
                Role r = new Role();
                db.Configuration.ProxyCreationEnabled = false;
                s=db.AdminUser.AsNoTracking().First(c => c.userId == id);
                r=db.Role.AsNoTracking().First(c => c.Id == s.roleId);
                return r.Name;
            }
            catch (Exception)
            {

                return null;
            }

        }

    }
}