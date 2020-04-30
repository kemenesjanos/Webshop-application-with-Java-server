using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Logic;
using Webshop.Repository;
using Webshop.Web.Models;

namespace Webshop.Web.Controllers
{
    public class LocationsController : Controller
    {
        ILogic logic;
        IMapper mapper;
        LocationsViewModel vm;

        RepositoryHelper repoHelper;

        public LocationsController()
        {
            this.repoHelper = new RepositoryHelper(new LocRepository(), new SaleRepository(), new UserRepository());
            logic = new Logic.Logic(repoHelper);
            mapper = MapperFactory.CreateMapper();
            vm = new LocationsViewModel();
            vm.EditedLocation = new Location();
            var Locations = logic.GetAllLocations();
            vm.ListOfLocations = mapper.Map<IEnumerable<Data.Loc>, List<Models.Location>>(Locations);
        }

        private Location GetLocationModel(decimal id)
        {
            Webshop.Data.Loc oneLocation = logic.GetLocById(id);
            return mapper.Map<Data.Loc, Models.Location>(oneLocation);
        }

        // GET: Locations
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("LocationIndex", vm);
        }

        // GET: Locations/Details/5
        public ActionResult Details(decimal id)
        {
            return View("LocationDetails", GetLocationModel(id));
        }

        public ActionResult Remove(decimal id)
        {
            TempData["editResult"] = "Delete FAIL";
            if (logic.DeleteLocation(id))
            {
                TempData["editResult"] = "Delete OK";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(decimal id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedLocation = GetLocationModel(id);
            return View("LocationIndex", vm);
        }

        [HttpPost]
        public ActionResult Edit(Location loc, string editAction)
        {
            if (ModelState.IsValid && loc != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.InsertLocationData(loc.ID, loc.Country, loc.Street, (decimal)loc.House_Number, (decimal)loc.Zip_Code);
                }
                else
                {
                    bool success = logic.UpdateLocation(loc.ID,
                        new Data.Loc()
                        {
                            Country = loc.Country,
                            Zip_Code = loc.Zip_Code,
                            Street = loc.Street,
                            House_Number = loc.House_Number,
                            ID = loc.ID,
                        });
                    if (!success)
                    {
                        TempData["editResult"] = "Edit Fail";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedLocation = loc;
                return View("LocationIndex", vm);
            }
        }
    }
}
