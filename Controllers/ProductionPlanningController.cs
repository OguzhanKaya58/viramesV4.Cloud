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
    public class ProductionPlanningController : Controller
    {
        #region shiftDefinitions
        // GET: ProductionPlanning
        public ActionResult shiftDefinitions()
        {
            ViewBag.Isactive = 21;
            List<Shift> shiftDefinitionList = virames<Shift>.Initialize(new List<Shift>()).GetList();
            return View(shiftDefinitionList);
        }
        #region detail 
        [HttpGet]
        public ActionResult detailShiftDefinition(int ID)
        {

            Shift shiftDefinition = virames<Shift>
                            .Initialize(new Shift()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(shiftDefinition);
        }
        [HttpPost]
        public ActionResult detailShiftDefinition(Shift shiftDefinition)
        {
            shiftDefinition.Save();
            return RedirectToAction("shiftDefinitions");
        }
        #endregion
        #region new
        [HttpGet]
        public ActionResult newShiftDefinition()
        {

            Shift shiftDefinition = new Shift();
            return View(shiftDefinition);
        }
        [HttpPost]
        public ActionResult newShiftDefinition(Shift shiftDefinition)
        {
            shiftDefinition.Save();
            return RedirectToAction("shiftDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editShiftDefinition(int ID)
        {

            Shift shiftDefinition = virames<Shift>
                             .Initialize(new Shift()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.ShiftDefinition = shiftDefinition;
            return View(shiftDefinition);
        }
        [HttpPost]
        public ActionResult editShiftDefinition(Shift shiftDefinition)
        {
            shiftDefinition.Save();
            return RedirectToAction("shiftDefinitions");
        }
        #endregion
        #region delete
        [HttpGet]
        public ActionResult deleteShiftDefinition(int ID)
        {
            Shift shiftDefinition = virames<Shift>
                           .Initialize(new Shift()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(shiftDefinition);

        }
        [HttpPost]
        public ActionResult deleteShiftDefinition(Shift shiftDefinition)
        {
            shiftDefinition.Delete();
            return RedirectToAction("shiftDefinitions");
        }
        #endregion
        #endregion

        #region interruptionTypeDefinition
        public ActionResult interruptionTypeDefinition()
        {
            ViewBag.Isactive = 22;
            List<Interruption> interruptionTypeDefinitionList = virames<Interruption>.Initialize(new List<Interruption>()).GetList();
            return View(interruptionTypeDefinitionList);
        }
        #region new
        [HttpGet]
        public ActionResult newinterruptionTypeDefinition()
        {

            Interruption interruption = new Interruption();
            return View(interruption);
        }
        [HttpPost]
        public ActionResult newinterruptionTypeDefinition(Interruption interruption)
        {
            interruption.Save();
            return RedirectToAction("interruptionTypeDefinition");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailinterruptionTypeDefinition(int ID)
        {

            Interruption interruption = virames<Interruption>
                            .Initialize(new Interruption()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(interruption);
        }
        [HttpPost]
        public ActionResult detailinterruptionTypeDefinition(Interruption interruption)
        {
            interruption.Save();
            return RedirectToAction("interruptionTypeDefinition");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editinterruptionTypeDefinition(int ID)
        {

            Interruption interruption = virames<Interruption>
                             .Initialize(new Interruption()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Interruption = interruption;
            return View(interruption);
        }
        [HttpPost]
        public ActionResult editinterruptionTypeDefinition(Interruption interruption)
        {
            interruption.Save();
            return RedirectToAction("interruptionTypeDefinition");
        }
        #endregion
        #region delete
        [HttpGet]
        public ActionResult deleteinterruptionTypeDefinition(int ID)
        {
            Interruption interruption = virames<Interruption>
                           .Initialize(new Interruption()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(interruption);

        }
        [HttpPost]
        public ActionResult deleteinterruptionTypeDefinition(Interruption interruption)
        {
            interruption.Delete();
            return RedirectToAction("interruptionTypeDefinition");
        }
        #endregion
        #endregion

        #region bomDefinitions
        public ActionResult bomDefinitions()
        {
            ViewBag.Isactive = 23;
            List<BOM> bomList = virames<BOM>.Initialize(new List<BOM>()).GetList();
            return View(bomList);
        }
        #region new
        [HttpGet]
        public ActionResult newBOMDefinition()
        {
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.Workstation = virames<Workstation>.Initialize(new List<Workstation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.MaterialType + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.BOM).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " + x.SpeCodeType
            });

            BOM bom = new BOM();
            return View(bom);
        }
        [HttpPost]
        public ActionResult newBOMDefinition(BOM bom)
        {
          //  bom.Save();
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailBOMDefinition(int ID)
        {
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.Workstation = virames<Workstation>.Initialize(new List<Workstation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.MaterialType + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.BOM).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " + x.SpeCodeType
            });

            BOM bom = virames<BOM>
                            .Initialize(new BOM()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(bom);
        }
        [HttpPost]
        public ActionResult detailBOMDefinition(BOM bom)
        {
          //  bom.Save();
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editBOMDefinition(int ID)
        {

            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.Workstation = virames<Workstation>.Initialize(new List<Workstation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ID + " | " + x.MaterialType + " | " + x.Code + " | " + x.Definition
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.BOM).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " + x.SpeCodeType
            });

            BOM bom = virames<BOM>
                             .Initialize(new BOM()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.BOM = bom;
            return View(bom);
        }
        [HttpPost]
        public ActionResult editBOMDefinition(BOM bom)
        {
          //  bom.Save();
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #region delete
        [HttpGet]
        public ActionResult deleteBOMDefinition(int ID)
        {
            BOM bom = virames<BOM>
                           .Initialize(new BOM()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(bom);

        }
        [HttpPost]
        public ActionResult deleteBOMDefinition(BOM bom)
        {
            bom.Delete();
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #endregion

        #region holiday
        public ActionResult holiday()
        {
            ViewBag.Isactive = 24;
            List<Holiday> holidayList = virames<Holiday>.Initialize(new List<Holiday>()).GetList();
            return View(holidayList);
        }
        #region new
        [HttpGet]

        public ActionResult newHoliday()
        {

            Holiday holiday = new Holiday();
            return View(holiday);
        }
        [HttpPost]
        public ActionResult newHoliday(Holiday holiday)
        {
            holiday.Save();
            return RedirectToAction("holiday");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailHoliday(int ID)
        {


            Holiday holiday = virames<Holiday>
                            .Initialize(new Holiday()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(holiday);
        }
        [HttpPost]
        public ActionResult detailHoliday(Holiday holiday)
        {
            holiday.Save();
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editHoliday(int ID)
        {

            Holiday holiday = virames<Holiday>
                             .Initialize(new Holiday()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Holiday = holiday;
            return View(holiday);
        }
        [HttpPost]
        public ActionResult editHoliday(Holiday holiday)
        {
            holiday.Save();
            return RedirectToAction("holiday");
        }
        #endregion
        #region delete
        [HttpGet]
        public ActionResult deleteHoliday(int ID)
        {
            Holiday holiday = virames<Holiday>
                           .Initialize(new Holiday()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(holiday);

        }
        [HttpPost]
        public ActionResult deleteHoliday(Holiday holiday)
        {
            holiday.Delete();
            return RedirectToAction("holiday");
        }
        #endregion

        #endregion

        #region project
        public ActionResult project()
        {
            ViewBag.Isactive = 25;
            List<Project> projectList = virames<Project>.Initialize(new List<Project>()).GetList();
            return View(projectList);
        }
        #region new
        [HttpGet]
        public ActionResult newProject()
        {
         
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.Project).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " + x.SpeCodeType
            });

            Project project = new Project();
            return View(project);
        }
        [HttpPost]
        public ActionResult newProject(Project project)
        {
            project.Save();
            return RedirectToAction("project");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailProject(int ID)
        {
           

            Project project = virames<Project>
                            .Initialize(new Project()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(project);
        }
        [HttpPost]
        public ActionResult detailProject(Project project)
        {
            project.Save();
            return RedirectToAction("project");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editProject(int ID)
        {

           
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.Project).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " + x.SpeCodeType
            });

            Project project = virames<Project>
                             .Initialize(new Project()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Project = project;
            return View(project);
        }
        [HttpPost]
        public ActionResult editProject(Project project)
        {
            project.Save();
            return RedirectToAction("project");
        }
        #endregion
        #region delete
        [HttpGet]
        public ActionResult deleteProject(int ID)
        {
            Project project = virames<Project>
                           .Initialize(new Project()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(project);

        }
        [HttpPost]
        public ActionResult deleteProject(Project project)
        {
            project.Delete();
            return RedirectToAction("project");
        }
        #endregion
        #region detailProjectDocument
        [HttpGet]
        public ActionResult detailProjectDocument(int ID)
        {

            ViewBag.ReportModule = new SelectList(Enum.GetValues(typeof(ReportModules)));
            List<DocumentProjectAppointment> DocumentList = virames<DocumentProjectAppointment>.Initialize(new List<DocumentProjectAppointment>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
                     

            return View(DocumentList);
        }
        [HttpPost]
        public ActionResult detailProjectDocument(DocumentProjectAppointment project)
        {
           return RedirectToAction("project");
        }
        #endregion
        #endregion

        #region productionOrders
        public ActionResult productionOrders()
        {
            ViewBag.Isactive = 26;
            List<ProductOrder> productionOrderList = virames<ProductOrder>.Initialize(new List<ProductOrder>()).GetList();
            return View(productionOrderList);
        }
        #region new
        [HttpGet]
        public ActionResult newProductOrder()
        {
            //ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));

            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).Where(x=>x.Center==false && x.Quality==false).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text =  x.Code + " | " + x.Definition+ " | "+  x.StartDate + " | " +x.EndDate
            });
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).Where(x=>x.MaterialType.Producible ).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text =  x.MaterialType + " | " + x.Code + " | " + x.Definition+" | " + x.OnHand + " | "  + x.TraceType + " | " +x.Status
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.ProductOrder).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | " 
            });
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));

            ProductOrder productOrder = new ProductOrder();
            return View(productOrder);
        }
        [HttpPost]
        public ActionResult newProductOrder(ProductOrder productOrder)
        {
            productOrder.Save();
            return RedirectToAction("productionOrders");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailProductOrder(int ID)
        {
           
            ProductOrder productOrder = virames<ProductOrder>
                            .Initialize(new ProductOrder()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(productOrder);
        }
        [HttpPost]
        public ActionResult detailProductOrder(ProductOrder productOrder)
        {
           
            return RedirectToAction("bomDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editProductOrder(int ID)
        {


            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).Where(x => x.Center == false && x.Quality == false).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition + " | " + x.StartDate + " | " + x.EndDate
            });
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).Where(x => x.MaterialType.Producible).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.MaterialType + " | " + x.Code + " | " + x.Definition + " | " + x.OnHand + " | " + x.TraceType + " | " + x.Status
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.ProductOrder).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpecialCode + " | "
            });
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));

            ProductOrder productOrder = virames<ProductOrder>
                             .Initialize(new ProductOrder()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.ProductOrder = productOrder;
            return View(productOrder);
        }
        [HttpPost]
        public ActionResult editProductOrder(ProductOrder productOrder)
        {
            productOrder.Save();
            return RedirectToAction("productionOrders");
        }
        #endregion
        #region delete
      
        public ActionResult deleteProductOrder(int ID)
        {
            ProductOrder productOrder = virames<ProductOrder>
                           .Initialize(new ProductOrder()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            productOrder.Delete();
            return RedirectToAction("productionOrders");

        }
     
        #endregion
        #endregion

        #region workOrders
        public ActionResult workOrders()
        {
            ViewBag.Isactive = 27;
            List<Workorder> workOrderList = virames<Workorder>.Initialize(new List<Workorder>()).GetList();
            return View(workOrderList);
        }
        #endregion

        #region workOrderOperationStep
        public ActionResult workOrderOperationStep()
        {
            ViewBag.Isactive = 28;
            List<WorkorderOperationStep> workOrderOperationStepList = virames<WorkorderOperationStep>.Initialize(new List<WorkorderOperationStep>()).GetList();
            return View(workOrderOperationStepList);
        }
        #endregion

        #region materialRequirementPlan
        public ActionResult materialRequirementPlan()
        {
            ViewBag.Isactive = 29;
            List<MRPRecord> materialRequirementPlanList = virames<MRPRecord>.Initialize(new List<MRPRecord>()).GetList();
            return View(materialRequirementPlanList);
        }
        #endregion

        #region recipeSpecifiCodeDefinations
        public ActionResult recipeSpecifiCodeDefinitions()
        {
            ViewBag.Isactive = 30;
            List<SpeCode> recipeSpecifiCodeDefinitionsList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.BOM).GetList();
            return View(recipeSpecifiCodeDefinitionsList);
        }
        #region new
        [HttpGet]

        public ActionResult newBOMSpeCode()
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(SpeCodeType))).Where((x => x.Text ==SpeCodeType.BOM.ToString()));

            ViewBag.SpeCodeType = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.BOM).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text =  " | " + x.SpeCodeType
            });
            SpeCode specode = new SpeCode();
            return View(specode);
        }
        [HttpPost]
        public ActionResult newBOMSpeCode(SpeCode specode)
        {
            specode.Save();
            return RedirectToAction("recipeSpecifiCodeDefinitions");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailBomSpeCode(int ID)
        {


            SpeCode speCode = virames<SpeCode>
                            .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(speCode);
        }
        [HttpPost]
        public ActionResult detailBomSpeCode(SpeCode speCode)
        {
            
            return RedirectToAction("recipeSpecifiCodeDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editBomSpeCode(int ID)
        {


           

            SpeCode speCode = virames<SpeCode>
                             .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.SpeCode = speCode;
            return View(speCode);
        }
        [HttpPost]
        public ActionResult editBomSpeCode(SpeCode speCode)
        {
            speCode.Save();
            return RedirectToAction("recipeSpecifiCodeDefinitions");
        }
   
        #endregion     
        #region delete
        public ActionResult deleteBomSpeCode(int ID)
        {
            SpeCode speCode = virames<SpeCode>
                           .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            speCode.Delete();
            return RedirectToAction("recipeSpecifiCodeDefinitions");

        }
        #endregion
       
        #endregion

        #region projectSpeCodeDefinitions
        public ActionResult projectSpeCodeDefinitions()
        {
            ViewBag.Isactive = 31;
            List<SpeCode> projectSpeCodeDefinitionsList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.Project).GetList();
            return View(projectSpeCodeDefinitionsList);
        }
        #region new
        [HttpGet]

        public ActionResult newProjectSpeCode()
        {
            SpeCode specode = new SpeCode();
            return View(specode);
        }
        [HttpPost]
        public ActionResult newProjectSpeCode(SpeCode specode)
        {
            specode.Save();
            return RedirectToAction("projectSpeCodeDefinitions");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailProjectSpeCode(int ID)
        {


            SpeCode speCode = virames<SpeCode>
                            .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(speCode);
        }
        [HttpPost]
        public ActionResult detailProjectSpeCode(SpeCode speCode)
        {

            return RedirectToAction("projectSpeCodeDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editProjectSpeCode(int ID)
        {




            SpeCode speCode = virames<SpeCode>
                             .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.SpeCode = speCode;
            return View(speCode);
        }
        [HttpPost]
        public ActionResult editProjectSpeCode(SpeCode speCode)
        {
            speCode.Save();
            return RedirectToAction("projectSpeCodeDefinitions");
        }

        #endregion
        #region delete
        public ActionResult deleteProjectSpeCode(int ID)
        {
            SpeCode speCode = virames<SpeCode>
                           .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            speCode.Delete();
            return RedirectToAction("projectSpeCodeDefinitions");

        }
        #endregion
        #endregion

        #region productionOrderSpeCodeDefinitions
        public ActionResult productionOrderSpeCodeDefinitions()
        {
            ViewBag.Isactive = 32;
            List<SpeCode> productionOrderSpeCodeDefinitionsList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.ProductOrder).GetList();
            return View(productionOrderSpeCodeDefinitionsList);
        }
        #region new
        [HttpGet]

        public ActionResult newProductSpeCode()
        {
            SpeCode specode = new SpeCode();
            return View(specode);
        }
        [HttpPost]
        public ActionResult newProductSpeCode(SpeCode specode)
        {
            specode.Save();
            return RedirectToAction("productionOrderSpeCodeDefinitions");
        }
        #endregion
        #region detail
        [HttpGet]
        public ActionResult detailProductSpeCode(int ID)
        {


            SpeCode speCode = virames<SpeCode>
                            .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(speCode);
        }
        [HttpPost]
        public ActionResult detailProductSpeCode(SpeCode speCode)
        {

            return RedirectToAction("productionOrderSpeCodeDefinitions");
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editProductSpeCode(int ID)
        {




            SpeCode speCode = virames<SpeCode>
                             .Initialize(new SpeCode()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.SpeCode = speCode;
            return View(speCode);
        }
        [HttpPost]
        public ActionResult editProductSpeCode(SpeCode speCode)
        {
            speCode.Save();
            return RedirectToAction("productionOrderSpeCodeDefinitions");
        }

        #endregion
        #endregion

        #region iş emri Bilgileri
        public ActionResult kanbanDashBoard()
        {
            ViewBag.Isactive = 250;
            List<Workorder> workorderList = virames<Workorder>.Initialize(new List<Workorder>()).GetList();
            //List<Workorder> kanbanList = virames<Workorder>.Initialize(new List<Workorder>()).GetList();
            return View(workorderList);
        }
        #endregion
    }
}