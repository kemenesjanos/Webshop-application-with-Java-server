using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Webshop.>
            });
            return config.CreateMapper();
        }
    }
}