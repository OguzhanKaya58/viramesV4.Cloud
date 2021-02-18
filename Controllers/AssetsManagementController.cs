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
    public class AssetsManagementController : Controller
    {
        #region Master Records

        #region asset
        [HttpGet]
        public ActionResult Asset()
        {
            ViewBag.Isactive = 56;
            List<Asset> assetList = virames<Asset>
                             .Initialize(new List<Asset>())
                             .GetList();
            return View(assetList);
        }
        [HttpGet]
        public ActionResult NewAsset()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.AssetType = new SelectList(Enum.GetValues(typeof(AssetType)));
            ViewBag.SpeCode = virames<SpeCode>
                          .Initialize(new List<SpeCode>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = "" + x.SpecialCode
                          });
            Asset asset = new Asset();
            return View(asset);
        }
        [HttpPost]
        public ActionResult NewAsset(Asset asset)
        {
            asset.Save();
            return RedirectToAction("Asset");
        }
        [HttpGet]
        public ActionResult EditAsset(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.AssetType = new SelectList(Enum.GetValues(typeof(AssetType)));
            ViewBag.SpeCode = virames<SpeCode>
                          .Initialize(new List<SpeCode>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = "" + x.SpecialCode
                          });
            Asset asset = virames<Asset>
                             .Initialize(new Asset()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(asset);
        }
        [HttpPost]
        public ActionResult EditAsset(Asset asset)
        {
            asset.Save();
            return RedirectToAction("Asset");
        }
        [HttpGet]
        public ActionResult DetailAsset(int ID)
        {
            Asset asset = virames<Asset>
                            .Initialize(new Asset()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(asset);
        }
        [HttpPost]
        public ActionResult DetailAsset(Asset asset)
        {
            asset.Save();
            return RedirectToAction("Asset");
        }
        [HttpGet]
        public ActionResult DeleteAsset(int ID)
        {


            Asset asset = virames<Asset>
                           .Initialize(new Asset()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(asset);

        }
        [HttpPost]
        public ActionResult DeleteAsset(Asset asset)
        {
            RealEstate realEstate = virames<RealEstate>
                           .Initialize(new RealEstate()).Where(x => x.AssetID == asset.ID)
                           .Take();
            if (realEstate != null)
                realEstate.Delete();
            Workstation workstation = virames<Workstation>
                          .Initialize(new Workstation()).Where(x => x.AssetID == asset.ID)
                          .Take();
            if (workstation != null)
                workstation.Delete();
            Equipment equipment = virames<Equipment>
                         .Initialize(new Equipment()).Where(x => x.AssetID == asset.ID)
                         .Take();
            if (equipment != null)
                equipment.Delete();
            Vehicle vehicle = virames<Vehicle>
                           .Initialize(new Vehicle()).Where(x => x.AssetID == asset.ID)
                           .Take();
            if (vehicle != null)
                vehicle.Delete();

            asset.Delete();
            return RedirectToAction("Asset");
        }
        #endregion

        #region realEstate
        [HttpGet]
        public ActionResult RealEstate()
        {
            ViewBag.Isactive = 57;
            List<RealEstate> RealEstateLists = virames<RealEstate>
                             .Initialize(new List<RealEstate>())
                             .GetList();
            return View(RealEstateLists);
        }
        [HttpGet]
        public ActionResult EditRealEstate(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            RealEstate realEstate = virames<RealEstate>
                             .Initialize(new RealEstate()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(realEstate);
        }
        [HttpPost]
        public ActionResult EditRealEstate(RealEstate realEstate)
        {
            realEstate.Save();
            return RedirectToAction("RealEstate");
        }
        [HttpGet]
        public ActionResult DetailRealEstate(int ID)
        {
            RealEstate realEstate = virames<RealEstate>
                            .Initialize(new RealEstate()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(realEstate);
        }
        [HttpPost]
        public ActionResult DetailRealEstate(RealEstate realEstate)
        {
            realEstate.Save();
            return RedirectToAction("RealEstate");
        }
        #endregion
    
        #region vehicle
        [HttpGet]
        public ActionResult Vehicle()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.Isactive = 58;
            List<Vehicle> VehicleLists = virames<Vehicle>
                             .Initialize(new List<Vehicle>())
                             .GetList();
            return View(VehicleLists);
        }
        [HttpGet]
        public ActionResult EditVehicle(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Vehicle vehicle = virames<Vehicle>
                             .Initialize(new Vehicle()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(vehicle);
        }
        [HttpPost]
        public ActionResult EditVehicle(Vehicle vehicle)
        {
            vehicle.Save();
            return RedirectToAction("Vehicle");
        }
        [HttpGet]
        public ActionResult DetailVehicle(int ID)
        {
            Vehicle vehicle = virames<Vehicle>
                            .Initialize(new Vehicle()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(vehicle);
        }
        [HttpPost]
        public ActionResult DetailVehicle(Vehicle vehicle)
        {
            vehicle.Save();
            return RedirectToAction("Vehicle");
        }
        #endregion

        #region equipment
        [HttpGet]
        public ActionResult Equipment()
        {
            ViewBag.Isactive = 59;
            List<Equipment> equipmentLists = virames<Equipment>
                             .Initialize(new List<Equipment>())
                             .GetList();
            return View(equipmentLists);
        }
        [HttpGet]
        public ActionResult EditEquipment(int ID)
        {
            ViewBag.equipmentType = new SelectList(Enum.GetValues(typeof(EquipmentType)));
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Equipment equipment = virames<Equipment>
                             .Initialize(new Equipment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(equipment);
        }
        [HttpPost]
        public ActionResult EditEquipment(Equipment equipment)
        {
            equipment.Save();
            return RedirectToAction("Equipment");
        }
        [HttpGet]
        public ActionResult DetailEquipment(int ID)
        {
            Equipment equipment = virames<Equipment>
                            .Initialize(new Equipment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(equipment);
        }
        [HttpPost]
        public ActionResult DetailEquipment(Equipment equipment)
        {
            equipment.Save();
            return RedirectToAction("Equipment");
        }
        #endregion

        #endregion

        #region Transactions

        #region periodicMaintenanceForAsset
        [HttpGet]
        public ActionResult PeriodicMaintenanceForAsset()
        {
            ViewBag.Isactive = 60;
            List<PeriodicMaintenanceForAsset> periodicMaintenanceForAssetsLists = virames<PeriodicMaintenanceForAsset>
                           .Initialize(new List<PeriodicMaintenanceForAsset>())
                           .GetList();
            return View(periodicMaintenanceForAssetsLists);
        }
        [HttpGet]
        public ActionResult NewPeriodicMaintenanceForAsset()
        {
            ViewBag.Asset = virames<Asset>.Initialize(new List<Asset>()).Where(x => x.Status == RecordStatus.Active && x.AssetType != AssetType.Workstation).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Definition + " | " + x.AssetType
            });
            ViewBag.Employee = virames<Employee>
                          .Initialize(new List<Employee>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Name + " | " + x.Title
                          });
            PeriodicMaintenanceForAsset periodicMaintenanceForAsset = new PeriodicMaintenanceForAsset();
            return View(periodicMaintenanceForAsset);
        }
        [HttpPost]
        public ActionResult NewPeriodicMaintenanceForAsset(PeriodicMaintenanceForAsset periodicMaintenanceForAsset)
        {
            periodicMaintenanceForAsset.Save();
            return RedirectToAction("PeriodicMaintenanceForAsset");
        }
        [HttpGet]
        public ActionResult EditPeriodicMaintenanceForAsset(int ID)
        {
            ViewBag.Asset = virames<Asset>.Initialize(new List<Asset>()).Where(x => x.Status == RecordStatus.Active && x.AssetType != AssetType.Workstation).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Definition + " | " + x.AssetType
            });
            ViewBag.Employee = virames<Employee>
                          .Initialize(new List<Employee>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Name + " | " + x.Title
                          });
            PeriodicMaintenanceForAsset periodicMaintenanceForAsset = virames<PeriodicMaintenanceForAsset>
                             .Initialize(new PeriodicMaintenanceForAsset()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(periodicMaintenanceForAsset);
        }
        [HttpPost]
        public ActionResult EditPeriodicMaintenanceForAsset(PeriodicMaintenanceForAsset periodicMaintenanceForAsset)
        {
            periodicMaintenanceForAsset.Save();
            return RedirectToAction("PeriodicMaintenanceForAsset");
        }
        [HttpGet]
        public ActionResult DetailPeriodicMaintenanceForAsset(int ID)
        {
            PeriodicMaintenanceForAsset periodicMaintenanceForAsset = virames<PeriodicMaintenanceForAsset>
                            .Initialize(new PeriodicMaintenanceForAsset()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(periodicMaintenanceForAsset);
        }
        [HttpPost]
        public ActionResult DetailPeriodicMaintenanceForAsset(PeriodicMaintenanceForAsset periodicMaintenanceForAsset)
        {
            periodicMaintenanceForAsset.Save();
            return RedirectToAction("PeriodicMaintenanceForAsset");
        }
        [HttpGet]
        public ActionResult DeletePeriodicMaintenanceForAsset(int ID)
        {


            PeriodicMaintenanceForAsset periodicMaintenanceForAsset = virames<PeriodicMaintenanceForAsset>
                           .Initialize(new PeriodicMaintenanceForAsset()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(periodicMaintenanceForAsset);

        }
        [HttpPost]
        public ActionResult DeletePeriodicMaintenanceForAsset(PeriodicMaintenanceForAsset periodicMaintenanceForAsset)
        {

            periodicMaintenanceForAsset.Delete();
            return RedirectToAction("PeriodicMaintenanceForAsset");
        }
        #endregion

        #endregion

        #region Definitions
        #region speCodeForAsset
        [HttpGet]
        public ActionResult SpeCodeForAsset()
        {
            ViewBag.Isactive = 61;
            List<SpeCode> speCodeList = virames<SpeCode>
                             .Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.Asset)
                             .GetList();
            return View(speCodeList);
        }
        [HttpGet]
        public ActionResult NewSpeCodeForAsset()
        {

            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            SpeCode speCode = new SpeCode();
            speCode.SpeCodeType = SpeCodeType.Asset;

            return View(speCode);
        }
        [HttpPost]
        public ActionResult NewSpeCodeForAsset(SpeCode speCode)
        {

            speCode.Save();
            return RedirectToAction("SpeCodeForAsset");
        }
        [HttpGet]
        public ActionResult EditSpeCodeForAsset(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            SpeCode speCode = virames<SpeCode>
                             .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            speCode.SpeCodeType = SpeCodeType.Asset;
            return View(speCode);
        }
        [HttpPost]
        public ActionResult EditSpeCodeForAsset(SpeCode speCode)
        {
            speCode.Save();
            return RedirectToAction("SpeCodeForAsset");
        }
        [HttpGet]
        public ActionResult DetailSpeCodeForAsset(int ID)
        {
            SpeCode speCode = virames<SpeCode>
                            .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(speCode);
        }
        [HttpPost]
        public ActionResult DetailSpeCodeForAsset(SpeCode speCode)
        {
            speCode.Save();
            return RedirectToAction("SpeCodeForAsset");
        }
        [HttpGet]
        public ActionResult DeleteSpeCodeForAsset(int ID)
        {


            SpeCode speCode = virames<SpeCode>
                           .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(speCode);

        }
        [HttpPost]
        public ActionResult DeleteSpeCodeForAsset(SpeCode speCode)
        {


            speCode.Delete();
            return RedirectToAction("SpeCodeForAsset");
        }
        #endregion
        #endregion
    }
}