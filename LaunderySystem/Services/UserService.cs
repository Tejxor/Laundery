using LaunderySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace LaunderySystem.Services
{
    public class UserService : BaseService
    {
        public UserService(LaunderyContext db)
        {
            this.db = db;
        }

        public UserProfile GetUserProfile(int? id)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
            return db.UserProfile.AsNoTracking().First(c => c.Id == id);
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public UserProfile GetUserProfile(string email)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                return (from u in db.UserProfile
                        where u.Email==email
                        select u).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public UserProfile GetUserProfile(string username, string password)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                return (from u in db.UserProfile
                           where u.UserName == username && u.PassWord == password
                           select u).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public List<UserProfile> GetUserProfiles()
        {
            return db.UserProfile.ToList();
        }

        public void CreateUserProfil(UserProfile userprofile)
        {
            db.UserProfile.Add(userprofile);
            db.SaveChanges();
        }

        public void SaveUserProfil(UserProfile userprofile)
        {
            db.Entry(userprofile).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteUserProfil(int? id)
        {
            UserProfile user = db.UserProfile.Find(id);
            db.UserProfile.Remove(user);
            db.SaveChanges();
        }


    }
}