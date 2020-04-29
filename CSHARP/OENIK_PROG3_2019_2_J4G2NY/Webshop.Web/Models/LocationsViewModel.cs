using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Web.Models
{
    public class LocationsViewModel
    {
        public Location EditedLocation { get; set; }
        public List<Location> ListOfLocations { get; set; }
    }
}