using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webshop.Logic;
using Webshop.Repository;
using Webshop.Web.Models;

namespace Webshop.Web.Controllers
{
    public class LocationsApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }
        ILogic logic;
        IMapper mapper;
        RepositoryHelper repoHelper;
        public LocationsApiController()
        {
            this.repoHelper = new RepositoryHelper(new LocRepository(), new SaleRepository(), new UserRepository());
            logic = new Logic.Logic(repoHelper);
            mapper = MapperFactory.CreateMapper();
           
        }

        // GET api/LocationsApi
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Location> GetAll()
        {
            var locations = logic.GetAllLocations();
            return mapper.Map<IEnumerable<Data.Loc>, List<Models.Location>>(locations);
        }

        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneLocation(decimal id)
        {
            bool success = logic.DeleteLocation(id);
            return new ApiResult() { OperationResult = success };
        }

        [ActionName("add")]
        [HttpPost]
        public ApiResult AddOneLocation(Location location)
        {
            logic.InsertLocationData(location.ID, location.Country, location.Street, (decimal)location.House_Number, (decimal)location.Zip_Code);
            return new ApiResult() { OperationResult = true };
        }

        [ActionName("mod")]
        [HttpPost]
        public ApiResult ModOneLocation(Location location)
        {
            bool success = logic.UpdateLocation(location.ID, new Data.Loc()
            {
                Country = location.Country,
                ID = location.ID,
                Street = location.Street,
                Zip_Code = location.Zip_Code,
                House_Number = 20
            });
            return new ApiResult() { OperationResult = success };
        }
    }
}
