using LaunderySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LaunderySystem.Services
{
    public class LaunderyService : BaseService
    {
        
        public LaunderyService(LaunderyContext db)
        {
            this.db = db;
        }

        public List<LaunderyRoom> GetLaunderyToList()
        {
            return db.LaunderyRoom.ToList();
        }

        public LaunderyRoom GetLaundery(int? id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.LaunderyRoom.AsNoTracking().First(c => c.Id == id);
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public void SaveLaundery(LaunderyRoom launderyRoom)
        {
            db.Entry(launderyRoom).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateLaundery(LaunderyRoom launderyRoom)
        {
            db.LaunderyRoom.Add(launderyRoom);
            db.SaveChanges();
        }
    }
}