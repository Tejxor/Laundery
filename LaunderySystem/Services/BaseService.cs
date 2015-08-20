using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaunderySystem.Models;

namespace LaunderySystem.Services
{
    public class BaseService
    {
        #region Declaration
        public LaunderyContext db { get; set; }
        public BaseService()
        {
            //LogHelper.LogInfo("Init");
        }
        #endregion

        ~BaseService()
        {
            //db.Dispose();
            //db = null;
            //LogHelper.LogInfo("Disposed here ...................... !");

        }
    }
}