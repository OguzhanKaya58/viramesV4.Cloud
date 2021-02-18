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
    public class ProductManagementController : Controller
    {
        #region MaterialDefinition
        public ActionResult materialDefinitions()
        {
           ViewBag.Isactive = 1;
            List<Material> materialList = virames<Material>.Initialize(new List<Material>()).GetList();
            return View(materialList);
        }
        [HttpGet]
        public ActionResult detailMaterialDefinition(int ID)
        {
            Material material = virames<Material>
                            .Initialize(new Material()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(material);
        }
        [HttpPost]
        public ActionResult detailMaterialDefinition(Material material)
        {
            material.Save();
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult editMaterialDefinition(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));

            Material material = virames<Material>
                             .Initialize(new Material()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Material = material;
            return View(material);
        }
        [HttpPost]
        public ActionResult editMaterialDefinition(Material material)
        {
            material.Save();
            return RedirectToAction("materialDefinations");
        }
        [HttpGet]
        public ActionResult newMaterialDefinition()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Material material = new Material();
            return View(material);
        }
        [HttpPost]
        public ActionResult newMaterialDefinition(Material material)
        {
            material.Save();
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult newMaterial()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Material material = new Material();
            return View(material);
        }
        [HttpPost]
        public ActionResult newMaterial(Material material)
        {
            material.Save();
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult deleteMaterialDefinition(int ID)
        {
            Material material = virames<Material>
                           .Initialize(new Material()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(material);

        }
        [HttpPost]
        public ActionResult deleteMaterialDefinition(Material material)
        {
     
            material.Delete();
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailMaterialFiche(int ID)
        {

            List<BOM> bomList = virames<BOM>.Initialize(new List<BOM>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
                           
            return View(bomList);
        }
        [HttpPost]
        public ActionResult detailMaterialFiche(BOM material)
        {
            
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailCriteriaSet(int ID)
        {

            List<CriteriaSet> criteriaSetList = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();

            return View(criteriaSetList);
        }
        [HttpPost]
        public ActionResult detailCriteriaSet(CriteriaSet material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailDocumentManagement(int ID)
        {

            List<Document> materialDocumentList = virames<Document>.Initialize(new List<Document>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();

            return View(materialDocumentList);
        }
        [HttpPost]
        public ActionResult detailDocumentManagement(Document material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailDocument(int ID)
        {
            Document material = virames<Document>
                            .Initialize(new Document()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(material);
        }
        [HttpPost]
        public ActionResult detailDocument(Document material)
        {
      
            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailDocumentRecord(int ID)
        {

            List<Material> criteriaSetList = virames<Material>.Initialize(new List<Material>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();

            return View(criteriaSetList);
        }
        [HttpPost]
        public ActionResult detailDocumentRecord(Material material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult receipts(int ID)
        {
         
            List<BOM> BOMList = virames<BOM>.Initialize(new List<BOM>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(BOMList);
        }
        [HttpPost]
        public ActionResult receipts(BOM material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailFiche(int ID)
        {

            List<MaterialFiche> ficheList = virames<MaterialFiche>.Initialize(new List<MaterialFiche>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(ficheList);
        }
        [HttpPost]
        public ActionResult detailFiche(MaterialFiche material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult detailEmployee(int ID)
        {

            List<Employee> employeeList = virames<Employee>.Initialize(new List<Employee>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(employeeList);
        }
        [HttpPost]
        public ActionResult detailEmployee(Employee material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult project(int ID)
        {

            List<Project> projectList = virames<Project>.Initialize(new List<Project>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(projectList);
        }
        [HttpPost]
        public ActionResult project(Project material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult productOrders(int ID)
        {

            List<ProductOrder> productOrderList = virames<ProductOrder>.Initialize(new List<ProductOrder>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(productOrderList);
        }
        [HttpPost]
        public ActionResult productOrders(ProductOrder material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult workStations(int ID)
        {

            List<Workstation> workstations = virames<Workstation>.Initialize(new List<Workstation>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(workstations);
        }
        [HttpPost]
        public ActionResult workStations(Workstation material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult purchaseContracts(int ID)
        {

            List<PurchaseContract> purchaseContractlList = virames<PurchaseContract>.Initialize(new List<PurchaseContract>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseContractlList);
        }
        [HttpPost]
        public ActionResult PurchaseContracts(PurchaseContract material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult purchaseIndents(int ID)
        {

            List<PurchaseIndent> purchaseIndentList = virames<PurchaseIndent>.Initialize(new List<PurchaseIndent>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseIndentList);
        }
        [HttpPost]
        public ActionResult purchaseIndents(PurchaseIndent material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult purchaseOrders(int ID)
        {

            List<PurchaseOrder> purchaseOrderList = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseOrderList);
        }
        [HttpPost]
        public ActionResult purchaseOrders(PurchaseOrder material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult purchaseProposal(int ID)
        {

            List<PurchaseProposal> purchaseProposalList = virames<PurchaseProposal>.Initialize(new List<PurchaseProposal>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseProposalList);
        }
        [HttpPost]
        public ActionResult purchaseProposal(PurchaseProposal material)
        {

            return RedirectToAction("materialDefinitions");
        }
        [HttpGet]
        public ActionResult certificates(int ID)
        {

            List<Certificate> certificatelList = virames<Certificate>.Initialize(new List<Certificate>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(certificatelList);
        }
        [HttpPost]
        public ActionResult certificates(Certificate material)
        {

            return RedirectToAction("materialDefinitions");
        }
        public ActionResult engineeringOperations()
        {
            ViewBag.Isactive = 1000;
            List<Material> materialList = virames<Material>.Initialize(new List<Material>()).GetList();
            return View(materialList);
        }
        public ActionResult exportMaterial()
        {

            return View();
        }
        #endregion
      
        
        #region Material Fiche
        public ActionResult materialFiche()
        {
            ViewBag.Isactive = 2;
            List<MaterialFiche> materialFicheList = virames<MaterialFiche>.Initialize(new List<MaterialFiche>()).Where(x => x.Type != TransactionType.PurchaseFiche && x.Type != TransactionType.QualityControlFiche && x.Type != TransactionType.SalesFiche).GetList();
            return View(materialFicheList);
        }
        [HttpGet]
        public ActionResult detailFicheMaterial(int ID)
        {
            MaterialFiche materialFiche = virames<MaterialFiche>
                            .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(materialFiche);
        }
        [HttpPost]
        public ActionResult detailFicheMaterial(MaterialFiche materialFiche)
        {
            materialFiche.Save();
            return RedirectToAction("materialFİche");
        }
        [HttpGet]
        public ActionResult deleteFicheMaterial(int ID)
        {
            MaterialFiche materialFiche = virames<MaterialFiche>
                           .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(materialFiche);

        }
        [HttpPost]
        public ActionResult deleteFicheMaterial(MaterialFiche materialFiche)
        {
            materialFiche.Delete();
            return RedirectToAction("materialFiche");
        }
        [HttpGet]
        public ActionResult newFicheMaterial()
        {
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName 
            });
            ViewBag.Employee = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Name
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x=>x.SpeCodeType==SpeCodeType.MaterialFiche).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpeCodeType + " | " + x.SpecialCode
            });
            MaterialFiche materialFiche = new MaterialFiche();
            return View(materialFiche);
        }
        [HttpPost]
        public ActionResult newFicheMaterial(MaterialFiche materialFiche)
        {
            materialFiche.Save();
            return RedirectToAction("materialDefinitions");
        }
        #endregion
      
        
        #region MaterialCriteriaSetAppointments
        public ActionResult materialCriteriaSetAppointments()
        {
            ViewBag.Isactive = 3;
            List<MaterialCriteriaSetAppointment> materialCriteriaSetAppList = virames<MaterialCriteriaSetAppointment>.InitializeList(new List<MaterialCriteriaSetAppointment>()).GetList();
            return View(materialCriteriaSetAppList);
        }
        [HttpGet]
        public ActionResult newMaterialCriteriaSetAppointments()
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType +" | " + x.TraceType + " | " +x.MainUnit
            });

            ViewBag.CriteriaSet = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.SpeCode
            });
          
          
            MaterialCriteriaSetAppointment materialCriteria = new MaterialCriteriaSetAppointment();
            return View(materialCriteria);
        }
        [HttpPost]
        public ActionResult newMaterialCriteriaSetAppointments(MaterialCriteriaSetAppointment materialCriteria)
        {
            materialCriteria.Save();
            return RedirectToAction("materialCriteriaSetAppointments");
        }
        [HttpGet]
        public ActionResult detailMaterialCriteriaSetAppointments(int ID)
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.TraceType + " | " + x.MainUnit
            });

            ViewBag.CriteriaSet = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.SpeCode
            });
            MaterialCriteriaSetAppointment materialCriteria = virames<MaterialCriteriaSetAppointment>
                            .Initialize(new MaterialCriteriaSetAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(materialCriteria);
        }
        [HttpPost]
        public ActionResult detailMaterialCriteriaSetAppointments(MaterialCriteriaSetAppointment materialCriteria)
        {
            materialCriteria.Save();
            return RedirectToAction("materialCriteriaSetAppointments");
        }
        [HttpGet]
        public ActionResult editMaterialCriteriaSetAppointments(int ID)
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.TraceType + " | " + x.MainUnit
            });

            ViewBag.CriteriaSet = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.SpeCode
            });

            MaterialCriteriaSetAppointment materialCriteria = virames<MaterialCriteriaSetAppointment>
                             .Initialize(new MaterialCriteriaSetAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
          
            return View(materialCriteria);
        }
        [HttpPost]
        public ActionResult editMaterialCriteriaSetAppointments(MaterialCriteriaSetAppointment materialCriteria)
        {
            materialCriteria.Save();
            return RedirectToAction("materialCriteriaSetAppointments");
        }
        #endregion


        #region materialPriceAppointment
        [HttpGet]
        public ActionResult newMaterialPriceAppointment()
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.TraceType + " | " + x.MainUnit
            });

            
           
            ViewBag.Currency = virames<Currency>.Initialize(new List<Currency>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name + " | " + x.Symbol
            });
          
            ViewBag.Pricetype = new SelectList(Enum.GetValues(typeof(PriceType)));
            ViewBag.MaterialPrice = new SelectList(Enum.GetValues(typeof(Status)));

            MaterialPriceAppointment materialPrice = new MaterialPriceAppointment();
            return View(materialPrice);
        }
        [HttpPost]
        public ActionResult newMaterialPriceAppointment(MaterialPriceAppointment materialPrice)
        {
            materialPrice.Save();
            return RedirectToAction("materialPriceAppointment");
        }
        [HttpGet]
        public ActionResult editMaterialPriceAppointment(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.TraceType + " | " + x.MainUnit
            });
            MaterialPriceAppointment materialPrice = virames<MaterialPriceAppointment>
                             .Initialize(new MaterialPriceAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.Material = materialPrice;
            return View(materialPrice);
        }
        [HttpPost]
        public ActionResult editMaterialPriceAppointment(MaterialPriceAppointment materialPrice)
        {
            materialPrice.Save();
            return RedirectToAction("materialPriceAppointment");
        }
        [HttpGet]
        public ActionResult materialPriceAppointment()
        {
            
            ViewBag.Isactive = 4;
            List<MaterialPriceAppointment> materialPriceAppointmentList = virames<MaterialPriceAppointment>.InitializeList(new List<MaterialPriceAppointment>()).GetList();
            return View(materialPriceAppointmentList);
        }
        [HttpGet]
        public ActionResult detailMaterialPriceAppointment(int ID)
        {
            ViewBag.Material = virames<Material>.Initialize(new List<Material>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.TraceType + " | " + x.MainUnit
            });

            ViewBag.CriteriaSet = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " + x.SpeCode
            });
            MaterialPriceAppointment materialPrice = virames<MaterialPriceAppointment>
                            .Initialize(new MaterialPriceAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(materialPrice);
        }
        [HttpPost]
        public ActionResult detailMaterialPriceAppointment(MaterialPriceAppointment materialPrice)
        {
            materialPrice.Save();
            return RedirectToAction("materialPriceAppointment");
        }
        #endregion


        #region purchaseFiche
        [HttpGet]
        public ActionResult detailPurchaseFiche(int ID)
        {
           
            MaterialFiche purchaseFiche = virames<MaterialFiche>
                            .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(purchaseFiche);
        }
        [HttpPost]
        public ActionResult detailPurchaseFiche(MaterialFiche purchaseFiche)
        {
            purchaseFiche.Save();
            return RedirectToAction("materialPriceAppointment");
        }
        [HttpGet]
        public ActionResult editPurchaseFiche(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName 
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpeCodeType + " | " + x.SpecialCode
            });
            ViewBag.Account = virames<Account>.Initialize(new List<Account>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | " 
            });
            ViewBag.PurchaseOrder = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Number + " | "+x.Date 
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.Employee = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Name
            });
            MaterialFiche purchaseFiche = virames<MaterialFiche>
                             .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.PurchaseFiche = purchaseFiche ;
            return View(purchaseFiche);
        }
        [HttpPost]
        public ActionResult editPurchaseFiche(MaterialFiche purchaseFiche)
        {
            purchaseFiche.Save();
            return RedirectToAction("purchaseFiche");
        }
        [HttpGet]
        public ActionResult newPurchaseFiche()
        {
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).GetList().Where(x=>x.SpeCodeType==SpeCodeType.MaterialFiche).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpeCodeType + " | " + x.SpecialCode
            });
            ViewBag.Account = virames<Account>.Initialize(new List<Account>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | "
            });
            ViewBag.PurchaseOrder = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Number + " | " + x.Date
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.Employee = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Name
            });
            MaterialFiche purchaseFiche = new MaterialFiche();
            return View(purchaseFiche);
        }
        [HttpPost]
        public ActionResult newPurchaseFiche(MaterialFiche purchaseFiche)
        {
            purchaseFiche.Save();
            return RedirectToAction("purchaseFiche");
        }
        [HttpGet]
        public ActionResult deletePurchaseFiche(int ID)
        {
            MaterialFiche purchaseFiche = virames<MaterialFiche>
                           .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(purchaseFiche);

        }
        [HttpPost]
        public ActionResult deletePurchaseFiche(MaterialFiche purchaseFiche)
        {
            purchaseFiche.Delete();
            return RedirectToAction("purchaseFiche");
        }
        public ActionResult purchaseFiche()
        {
            ViewBag.Isactive = 5;
            List<MaterialFiche> purchaseList = virames<MaterialFiche>.InitializeList(new List<MaterialFiche>()).Where(x => x.Type ==TransactionType.PurchaseFiche).GetList();
            return View(purchaseList);
        }
        #endregion


        #region salesFiche
        [HttpGet]
        public ActionResult editSalesFiche(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpeCodeType + " | " + x.SpecialCode
            });
            ViewBag.Account = virames<Account>.Initialize(new List<Account>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | "
            });
            ViewBag.PurchaseOrder = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Number + " | " + x.Date
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.Employee = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Name
            });
            MaterialFiche salesFiche = virames<MaterialFiche>
                             .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            ViewBag.SalesFiche = salesFiche;
            return View(salesFiche);
        }
        [HttpPost]
        public ActionResult editSalesFiche(MaterialFiche salesFiche)
        {
            salesFiche.Save();
            return RedirectToAction("salesFiche");
        }
        [HttpGet]
        public ActionResult detailSalesFiche(int ID)
        {

            MaterialFiche salesFiche = virames<MaterialFiche>
                            .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(salesFiche);
        }
        [HttpPost]
        public ActionResult detailSalesFiche(MaterialFiche salesFiche)
        {
            salesFiche.Save();
            return RedirectToAction("salesFiche");
        }
        [HttpGet]
        public ActionResult newSalesFiche()
        {
            ViewBag.Warehouse = virames<Warehouse>.Initialize(new List<Warehouse>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.WarehouseName
            });
            ViewBag.SpeCode = virames<SpeCode>.Initialize(new List<SpeCode>()).GetList().Where(x => x.SpeCodeType == SpeCodeType.MaterialFiche).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SpeCodeType + " | " + x.SpecialCode
            });
            ViewBag.Account = virames<Account>.Initialize(new List<Account>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CodeAndDefinition + " | "
            });
            ViewBag.PurchaseOrder = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Number + " | " + x.Date
            });
            ViewBag.Project = virames<Project>.Initialize(new List<Project>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Definition
            });
            ViewBag.Employee = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Code + " | " + x.Name
            });
            MaterialFiche purchaseFiche = new MaterialFiche();
            return View(purchaseFiche);
        }
        [HttpPost]
        public ActionResult newSalesFiche(MaterialFiche salesFiche)
        {
            salesFiche.Date = salesFiche.Date.Date;
            salesFiche.Save();

            return RedirectToAction("salesFiche");
        }
        public ActionResult salesFiche()
        {
            ViewBag.Isactive = 6;
            List<MaterialFiche> purchaseList = virames<MaterialFiche>.InitializeList(new List<MaterialFiche>()).Where(x => x.Type == TransactionType.SalesFiche).GetList();
            return View(purchaseList);
        }
        [HttpGet]
        public ActionResult deleteSalesFiche(int ID)
        {
            MaterialFiche salesFiche = virames<MaterialFiche>
                           .Initialize(new MaterialFiche()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(salesFiche);

        }
        [HttpPost]
        public ActionResult deleteSalesFiche(MaterialFiche salesFiche)
        {
            salesFiche.Delete();
            return RedirectToAction("salesFiche");
        }
        #endregion


        #region serialLotNumberMaintenanceRepairRecord
        public ActionResult serialLotNumberMaintenanceRepairRecord()
        {
            ViewBag.Isactive = 7;
            List<SerialLotNumberMaintenanceRepairRecord> SerialLotNumberMaintenanceRepairRecordList = virames<SerialLotNumberMaintenanceRepairRecord>.Initialize(new List<SerialLotNumberMaintenanceRepairRecord>()).GetList();
            return View(SerialLotNumberMaintenanceRepairRecordList);
        }
        #endregion

        
        #region unitSetDefinition
        public ActionResult unitSetDefinition()
        {
            ViewBag.Isactive = 8;
            List<UnitSet> unitsetDefinitionList = virames<UnitSet>.Initialize(new List<UnitSet>()).GetList();
            return View(unitsetDefinitionList);
        }
        #endregion


        #region MaterialSpeCode
        public ActionResult MaterialSpeCode()
        {
            ViewBag.Isactive = 9;
            List<SpeCode> materialSpeCodeList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.Material).GetList();
            return View(materialSpeCodeList);
        }
        #endregion


        #region MaterialClasses
        public ActionResult materialClasses()
        {
            ViewBag.Isactive = 10;
            List<MaterialClass> materialClassesList = virames<MaterialClass>.Initialize(new List<MaterialClass>()).GetList();
            return View(materialClassesList);
        }
        #endregion


        #region MaterialType
        public ActionResult materialType()
        {
            ViewBag.Isactive = 11;
            List<MaterialType> materialTypeList = virames<MaterialType>.Initialize(new List<MaterialType>()).GetList();
            return View(materialTypeList);
        }
        #endregion


        #region serialTemplate
        public ActionResult serialTemplate()
        {
            ViewBag.Isactive = 12;
            List<SerialTemplate> serialTemplateList = virames<SerialTemplate>.Initialize(new List<SerialTemplate>()).GetList();
            return View(serialTemplateList);
        }
        #endregion


        #region MaterialSpecification

        public ActionResult materialSpecification()
        {
            ViewBag.Isactive = 13;
            List<MaterialSpecification> materialSpecificationList = virames<MaterialSpecification>.Initialize(new List<MaterialSpecification>()).GetList();
            return View(materialSpecificationList);
        }
        #endregion


        #region unitSetSpeCode
        public ActionResult unitSetSpeCode()
        {
            ViewBag.Isactive = 14;
            List<SpeCode> unitSetSpeCodeList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.UnitSet).GetList();
            return View(unitSetSpeCodeList);
        }
        #endregion


        #region MaterialFicheSpeCode
        public ActionResult materialFicheSpeCode()
        {
            ViewBag.Isactive = 15;
            List<SpeCode> materialFicheSpeCodeList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x => x.SpeCodeType == SpeCodeType.MaterialFiche).GetList();
            return View(materialFicheSpeCodeList);
        }
        #endregion
    }
}