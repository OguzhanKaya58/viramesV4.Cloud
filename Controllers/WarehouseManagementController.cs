using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viramesV4.Cloud.Helpers;
using viramesV4.Object.BusinessLogicLayer.Master;
using viramesV4.Object.BusinessLogicLayer.System;
using viramesV4.Object.Factory;
using viramesV4.Object.HelperLayer;

namespace viramesV4.Cloud.Controllers
{
    [ViramesAuthorization]
    public class WarehouseManagementController : Controller
    {
        #region warehouseDefinitions
        // GET: WarehouseManagement
        public ActionResult warehouseDefinitions()
        {
            ViewBag.Isactive = 16;
            List<Warehouse> wareHouseDefinitionList = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList();
            return View(wareHouseDefinitionList);
        }
        [HttpGet]
        public ActionResult newWarehouseDefinition()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Warehouse warehouse = new Warehouse();
            return View(warehouse);
        }
        [HttpPost]
        public ActionResult newWarehouseDefinition(Warehouse warehouse)
        {
            warehouse.Save();
            return RedirectToAction("warehouseDefinitions");
        }
        [HttpGet]
        public ActionResult detailWarehouseDefinition(int ID)
        {
            Warehouse warehouse = virames<Warehouse>
                            .Initialize(new Warehouse()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(warehouse);
        }
        [HttpPost]
        public ActionResult detailMaterialDefinition(Warehouse warehouse)
        {
            warehouse.Save();
            return RedirectToAction("warehouseDefinitions");
        }
        [HttpGet]
        public ActionResult editWarehouseDefinition(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));

            Warehouse warehouse = virames<Warehouse>
                             .Initialize(new Warehouse()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Warehouse = warehouse;
            return View(warehouse);
        }
        [HttpPost]
        public ActionResult editWarehouseDefinition(Warehouse warehouse)
        {
            warehouse.Save();
            return RedirectToAction("warehouseDefinitions");
        }
        #endregion
        #region materialWarehouseInformations
        public ActionResult materialWarehouseInformations()
        {

            ViewBag.Isactive = 17;
            List<Material> materialWarehouseInformationsList = virames<Material>.Initialize(new List<Material>()).GetList();
            return View(materialWarehouseInformationsList);
        }
        [HttpGet]
        public ActionResult detailWarehouseInformation(int ID)
        {
            Material material = virames<Material>
                            .Initialize(new Material()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(material);
        }
        [HttpPost]
        public ActionResult detailWarehouseInformation(Material material)
        {
            material.Save();
            return RedirectToAction("warehouseInformations");
        }
        [HttpGet]
        public ActionResult editWarehouseInformation(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.MaterialClass = virames<MaterialClass>.Initialize(new List<MaterialClass>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.DefaultWarehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName + " | " + x.Center + " | " + x.Default + " | " + x.Quality + " | " + x.Status
            });
            ViewBag.ShelfLocation = virames<ShelfLocation>.Initialize(new List<ShelfLocation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.LocationOfShelf + " | "
            });
            ViewBag.StorageCondition = virames<StorageConditionSet>.Initialize(new List<StorageConditionSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
           
            Material material = virames<Material>
                             .Initialize(new Material()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Material = material;
            return View(material);
        }
        [HttpPost]
        public ActionResult editWarehouseInformation(Material material)
        {
            material.Save();
            return RedirectToAction("materialWarehouseInformations");
        }
        #endregion
        #region warehouseParameters
        public ActionResult warehouseParameters()
        {
            ViewBag.Isactive = 18;
            List<WarehouseLevel> warehouseParametersList = virames<WarehouseLevel>.Initialize(new List<WarehouseLevel>()).GetList();
            return View(warehouseParametersList);
        }
        [HttpGet]
        public ActionResult detailWarehouseParameter(int ID)
        {
            WarehouseLevel material = virames<WarehouseLevel>
                            .Initialize(new WarehouseLevel()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(material);
        }
        [HttpPost]
        public ActionResult detailWarehouseParameter(WarehouseLevel warehouseLevel)
        {
            warehouseLevel.Save();
            return RedirectToAction("warehouseParameters");
        }
        [HttpGet]
        public ActionResult editWarehouseParameter(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.MainUnit + " | " + x.SpeCode + " | " + x.TraceType
            });
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName + " | " + x.Center + " | " + x.Default + " | " + x.Quality 
            });
           
           
            WarehouseLevel warehouseLevel = virames<WarehouseLevel>
                             .Initialize(new WarehouseLevel()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.WarehouseLevel = warehouseLevel;
            return View(warehouseLevel);
        }
        [HttpPost]
        public ActionResult editWarehouseParameter(WarehouseLevel warehouseLevel)
        {
            warehouseLevel.Save();
            return RedirectToAction("warehouseParameters");
        }
        [HttpGet]
        public ActionResult newWarehouseParameter()
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.MainUnit + " | " + x.SpeCode + " | " + x.TraceType
            });
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName + " | " + x.Center + " | " + x.Default + " | " + x.Quality
            });
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            WarehouseLevel warehouseLevel = new WarehouseLevel();
            return View(warehouseLevel);
        }
        [HttpPost]
        public ActionResult newWarehouseParameter(WarehouseLevel warehouseLevel)
        {
            warehouseLevel.Save();
            return RedirectToAction("warehouseParameters");
        }
        [HttpGet]
        public ActionResult deleteWarehouseParameter(int ID)
        {
            WarehouseLevel warehouseLevel = virames<WarehouseLevel>
                           .Initialize(new WarehouseLevel()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(warehouseLevel);

        }
        [HttpPost]
        public ActionResult deleteWarehouseParameter(WarehouseLevel warehouseLevel)
        {
            warehouseLevel.Delete();
            return RedirectToAction("warehouseParameters");
        }
        #endregion

        #region shelfLocationDefinitions
        public ActionResult shelfLocationDefinitions()
        {
            ViewBag.Isactive = 19;
            List<ShelfLocation> shelfLocationDefinitionsList = virames<ShelfLocation>.Initialize(new List<ShelfLocation>()).GetList();
            return View(shelfLocationDefinitionsList);
        }
        [HttpGet]
        public ActionResult detailShelfLocation(int ID)
        {
            ShelfLocation shelfLocation = virames<ShelfLocation>
                            .Initialize(new ShelfLocation()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(shelfLocation);
        }
        [HttpPost]
        public ActionResult detailShelfLocation(ShelfLocation shelfLocation)
        {
            shelfLocation.Save();
            return RedirectToAction("shelfLocationDefinitions");
        }
        [HttpGet]
        public ActionResult editShelfLocation(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
         
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName + " | " + x.Center + " | "  + x.Quality 
            });
            ViewBag.StorageConditionSet = virames<StorageConditionSet>.Initialize(new List<StorageConditionSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
          

            ShelfLocation shelfLocation = virames<ShelfLocation>
                             .Initialize(new ShelfLocation()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.ShelfLocation = shelfLocation;
            return View(shelfLocation);
        }
        [HttpPost]
        public ActionResult editShelfLocation(ShelfLocation shelfLocation)
        {
            shelfLocation.Save();
            return RedirectToAction("shelfLocationDefinitions");
        }
        [HttpGet]
        public ActionResult newShelfLocation()
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));

            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName + " | " + x.Center + " | " + x.Quality
            });
            ViewBag.StorageConditionSet = virames<StorageConditionSet>.Initialize(new List<StorageConditionSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ShelfLocation shelfLocation = new ShelfLocation();
            return View(shelfLocation);
        }
        [HttpPost]
        public ActionResult newShelfLocation(ShelfLocation shelfLocation)
        {
            shelfLocation.Save();
            return RedirectToAction("shelfLocationDefinitions");
        }
        [HttpGet]
        public ActionResult deleteShelfLocation(int ID)
        {
            ShelfLocation shelfLocation = virames<ShelfLocation>
                           .Initialize(new ShelfLocation()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(shelfLocation);

        }
        [HttpPost]
        public ActionResult deleteShelfLocation(ShelfLocation shelfLocation)
        {
            shelfLocation.Delete();
            return RedirectToAction("shelfLocationDefinitions");
        }
        #endregion
        public ActionResult storageConditionSet()
        {
            ViewBag.Isactive = 20;
            List<StorageConditionSet> storageConditionSetList = virames<StorageConditionSet>.Initialize(new List<StorageConditionSet>()).GetList();
            return View(storageConditionSetList);
        }
    }
}