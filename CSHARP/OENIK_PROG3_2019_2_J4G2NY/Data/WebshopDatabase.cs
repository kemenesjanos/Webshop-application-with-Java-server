using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Data
{
    
    public static class WebshopDatabase
    {
        public static WebshopDBEntities1 WebshopDB { get; }

        static WebshopDatabase()
        {
            WebshopDB = new WebshopDBEntities();
        }

    }
}
