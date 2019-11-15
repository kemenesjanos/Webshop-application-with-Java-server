using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Data
{
    public class DBHandler : IDisposable
    {
        private static DBHandler instance;

        public WebshopDBEntities webshopDBEntities { get; set; }

        public DBHandler()
        {
            this.webshopDBEntities = new WebshopDBEntities();
        }

        public static DBHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBHandler();
                }

                return instance;
            }
        }

        public void Dispose()
        {
            this.webshopDBEntities.Dispose();
        }
    }
}
