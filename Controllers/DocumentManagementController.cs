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
    public class DocumentManagementController : Controller
    {

        #region Master Records

        #region Document
        [HttpGet]
        public ActionResult Document()
        {
            ViewBag.Isactive = 66;
            List<Document> documentList = virames<Document>
                             .Initialize(new List<Document>())
                             .GetList();
            return View(documentList);
        }
        [HttpGet]
        public ActionResult NewDocument()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.DocumentAvailability = new SelectList(Enum.GetValues(typeof(DocumentAvailability)));
            Document document = new Document();
            return View(document);
        }
        [HttpPost]
        public ActionResult NewDocument(Document document)
        {
            document.Save();
            return RedirectToAction("Document");
        }
        [HttpGet]
        public ActionResult EditDocument(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.DocumentAvailability = new SelectList(Enum.GetValues(typeof(DocumentAvailability)));
            Document document = virames<Document>
                             .Initialize(new Document()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(document);
        }
        [HttpPost]
        public ActionResult EditDocument(Document document)
        {
            document.Save();
            return RedirectToAction("Document");
        }
        [HttpGet]
        public ActionResult DetailDocument(int ID)
        {
            Document document = virames<Document>
                            .Initialize(new Document()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(document);
        }
        [HttpPost]
        public ActionResult DetailDocument(Document document)
        {
            document.Save();
            return RedirectToAction("Document");
        }
        [HttpGet]
        public ActionResult DeleteDocument(int ID)
        {
            Document document = virames<Document>
                           .Initialize(new Document()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(document);

        }
        [HttpPost]
        public ActionResult DeleteDocument(Document document)
        {
            document.Delete();
            return RedirectToAction("Document");
        }
        [HttpGet]
        public ActionResult DocumentRecords(int ID)
        {

            List<Document> documentList = virames<Document>
                             .Initialize(new List<Document>()).Where(x => x.ID == ID)
                             .GetList();
            return View(documentList);

        }
        [HttpGet]
        public ActionResult Material(int ID)
        {
            List<Material> material = virames<Material>.Initialize(new List<Material>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(material);
        }
        [HttpGet]
        public ActionResult Bom(int ID)
        {
            List<BOM> Bom = virames<BOM>.Initialize(new List<BOM>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(Bom);
        }
        [HttpGet]
        public ActionResult MaterialFiches(int ID)
        {
            List<MaterialFiche> materialFiche = virames<MaterialFiche>.Initialize(new List<MaterialFiche>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(materialFiche);
        }
        [HttpGet]
        public ActionResult Employee(int ID)
        {
            List<Employee> employee = virames<Employee>.Initialize(new List<Employee>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Project(int ID)
        {
            List<Project> project = virames<Project>.Initialize(new List<Project>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(project);
        }
        [HttpGet]
        public ActionResult ProductOrders(int ID)
        {
            List<ProductOrder> productOrder = virames<ProductOrder>.Initialize(new List<ProductOrder>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(productOrder);
        }
        [HttpGet]
        public ActionResult WorkStations(int ID)
        {
            List<Workstation> workstation = virames<Workstation>.Initialize(new List<Workstation>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(workstation);
        }
        [HttpGet]
        public ActionResult PurchaseContracts(int ID)
        {
            List<PurchaseContract> purchaseContract = virames<PurchaseContract>.Initialize(new List<PurchaseContract>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseContract);
        }
        [HttpGet]
        public ActionResult PurchaseIndents(int ID)
        {
            List<PurchaseIndent> purchaseIndent = virames<PurchaseIndent>.Initialize(new List<PurchaseIndent>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseIndent);
        }
        [HttpGet]
        public ActionResult PurchaseOrders(int ID)
        {
            List<PurchaseOrder> purchaseOrder = virames<PurchaseOrder>.Initialize(new List<PurchaseOrder>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseOrder);
        }
        [HttpGet]
        public ActionResult PurchaseProposal(int ID)
        {
            List<PurchaseProposal> purchaseProposal = virames<PurchaseProposal>.Initialize(new List<PurchaseProposal>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(purchaseProposal);
        }
        [HttpGet]
        public ActionResult Certificates(int ID)
        {
            List<Certificate> certificate = virames<Certificate>.Initialize(new List<Certificate>()).Where(x => x.ID.ToString() == ID.ToString()).GetList();
            return View(certificate);
        }
        #endregion

        #endregion

        #region Transactions

        #region documentBomAppointment
        [HttpGet]
        public ActionResult DocumentBomAppointment()
        {
            ViewBag.Isactive = 67;
            List<DocumentBOMAppointment> documentBOMAppointments = virames<DocumentBOMAppointment>
                .Initialize(new List<DocumentBOMAppointment>())
                .GetList();
            return View(documentBOMAppointments);
        }
        [HttpGet]
        public ActionResult NewDocumentBomAppointment()
        {
            ViewBag.Bom = virames<BOM>
                          .Initialize(new List<BOM>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Workstation + " | " + x.Material + " | " + x.Amount + " | " + x.Priority + " | " + x.Type + " | " + x.Status + " | " + x.CodeAndDefinition
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentBOMAppointment documentBOMAppointment = new DocumentBOMAppointment();
            return View(documentBOMAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentBomAppointment(DocumentBOMAppointment documentBOMAppointment)
        {
            documentBOMAppointment.Save();
            return RedirectToAction("DocumentBomAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentBOMAppointment(int ID)
        {
            ViewBag.Bom = virames<BOM>
                           .Initialize(new List<BOM>())
                           .GetList().Select(x => new SelectListItem
                           {
                               Value = x.ID.ToString(),
                               Text = x.Workstation + " | " + x.Material + " | " + x.Amount + " | " + x.Priority + " | " + x.Type + " | " + x.Status + " | " + x.CodeAndDefinition
                           });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentBOMAppointment documentBOMAppointment = virames<DocumentBOMAppointment>
                             .Initialize(new DocumentBOMAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentBOMAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentBomAppointment(DocumentBOMAppointment documentBOMAppointment)
        {
            documentBOMAppointment.Save();
            return RedirectToAction("DocumentBomAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentBomAppointment(int ID)
        {
            DocumentBOMAppointment documentBOMAppointment = virames<DocumentBOMAppointment>
                            .Initialize(new DocumentBOMAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentBOMAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentBomAppointment(DocumentBOMAppointment documentBOMAppointment)
        {
            documentBOMAppointment.Save();
            return RedirectToAction("DocumentBomAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentBomAppointment(int ID)
        {
            DocumentBOMAppointment documentBOMAppointment = virames<DocumentBOMAppointment>
                           .Initialize(new DocumentBOMAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentBOMAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentBomAppointment(DocumentBOMAppointment documentBOMAppointment)
        {
            documentBOMAppointment.Delete();
            return RedirectToAction("DocumentBomAppointment");
        }
        #endregion

        #region documentMaterialAppointment
        [HttpGet]
        public ActionResult DocumentMaterialAppointment()
        {
            ViewBag.Isactive = 68;
            List<DocumentMaterialAppointment> documentMaterialAppList = virames<DocumentMaterialAppointment>
                             .Initialize(new List<DocumentMaterialAppointment>())
                             .GetList();
            return View(documentMaterialAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentMaterialAppointment()
        {
            ViewBag.Material = virames<Material>
                          .Initialize(new List<Material>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.SpeCode
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentMaterialAppointment documentMaterialAppointment = new DocumentMaterialAppointment();
            return View(documentMaterialAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentMaterialAppointment(DocumentMaterialAppointment documentMaterialAppointment)
        {
            documentMaterialAppointment.Save();
            return RedirectToAction("DocumentMaterialAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentMaterialAppointment(int ID)
        {
            ViewBag.Material = virames<Material>
                     .Initialize(new List<Material>())
                     .GetList().Select(x => new SelectListItem
                     {
                         Value = x.ID.ToString(),
                         Text = x.CodeAndDefinition + " | " + x.MaterialType + " | " + x.SpeCode
                     });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentMaterialAppointment documentMaterialAppointment = virames<DocumentMaterialAppointment>
                             .Initialize(new DocumentMaterialAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentMaterialAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentMaterialAppointment(DocumentMaterialAppointment documentMaterialAppointment)
        {
            documentMaterialAppointment.Save();
            return RedirectToAction("DocumentMaterialAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentMaterialAppointment(int ID)
        {
            DocumentMaterialAppointment documentMaterialAppointment = virames<DocumentMaterialAppointment>
                            .Initialize(new DocumentMaterialAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentMaterialAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentMaterialAppointment(DocumentMaterialAppointment documentMaterialAppointment)
        {
            documentMaterialAppointment.Save();
            return RedirectToAction("DocumentMaterialAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentMaterialAppointment(int ID)
        {
            DocumentMaterialAppointment documentMaterialAppointment = virames<DocumentMaterialAppointment>
                           .Initialize(new DocumentMaterialAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentMaterialAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentMaterialAppointment(DocumentMaterialAppointment documentMaterialAppointment)
        {
            documentMaterialAppointment.Delete();
            return RedirectToAction("DocumentMaterialAppointment");
        }
        #endregion
     
        #region documentWorkstationAppointment
        [HttpGet]
        public ActionResult DocumentWorkstationAppointment()
        {
            ViewBag.Isactive = 69;
            List<DocumentWorkstationAppointment> documentWorkstationAppList = virames<DocumentWorkstationAppointment>
                             .Initialize(new List<DocumentWorkstationAppointment>())
                             .GetList();
            return View(documentWorkstationAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentWorkstationAppointment()
        {
            ViewBag.Workstation = virames<Workstation>
                          .Initialize(new List<Workstation>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.CodeAndDefinition + " | " + x.Location + " | " + x.Status
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentWorkstationAppointment documentWorkstationAppointment = new DocumentWorkstationAppointment();
            return View(documentWorkstationAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentWorkstationAppointment(DocumentWorkstationAppointment documentWorkstationAppointment)
        {
            documentWorkstationAppointment.Save();
            return RedirectToAction("DocumentWorkstationAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentWorkstationAppointment(int ID)
        {
            ViewBag.Workstation = virames<Workstation>
                         .Initialize(new List<Workstation>())
                         .GetList().Select(x => new SelectListItem
                         {
                             Value = x.ID.ToString(),
                             Text = x.CodeAndDefinition + " | " + x.Location + " | " + x.Status
                         });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentWorkstationAppointment documentWorkstationAppointment = virames<DocumentWorkstationAppointment>
                             .Initialize(new DocumentWorkstationAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentWorkstationAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentWorkstationAppointment(DocumentWorkstationAppointment documentWorkstationAppointment)
        {
            documentWorkstationAppointment.Save();
            return RedirectToAction("DocumentWorkstationAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentWorkstationAppointment(int ID)
        {
            DocumentWorkstationAppointment documentWorkstationAppointment = virames<DocumentWorkstationAppointment>
                            .Initialize(new DocumentWorkstationAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentWorkstationAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentWorkstationAppointment(DocumentWorkstationAppointment documentWorkstationAppointment)
        {
            documentWorkstationAppointment.Save();
            return RedirectToAction("DocumentWorkstationAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentWorkstationAppointment(int ID)
        {
            DocumentWorkstationAppointment documentWorkstationAppointment = virames<DocumentWorkstationAppointment>
                           .Initialize(new DocumentWorkstationAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentWorkstationAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentWorkstationAppointment(DocumentWorkstationAppointment documentWorkstationAppointment)
        {
            documentWorkstationAppointment.Delete();
            return RedirectToAction("DocumentWorkstationAppointment");
        }
        #endregion

        #region documentWorkstationGroupAppointment
        [HttpGet]
        public ActionResult DocumentWorkstationGroupAppointment()
        {
            ViewBag.Isactive = 70;
            List<DocumentWorkstationGroupAppointment> documentWorkstationGroupAppList = virames<DocumentWorkstationGroupAppointment>
                             .Initialize(new List<DocumentWorkstationGroupAppointment>())
                             .GetList();
            return View(documentWorkstationGroupAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentWorkstationGroupAppointment()
        {
            ViewBag.WorkstationGroup = virames<WorkstationGroup>
                          .Initialize(new List<WorkstationGroup>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.CodeAndDefinition + " | " + x.Location + " | " + x.Status
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment = new DocumentWorkstationGroupAppointment();
            return View(documentWorkstationGroupAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentWorkstationGroupAppointment(DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment)
        {
            documentWorkstationGroupAppointment.Save();
            return RedirectToAction("DocumentWorkstationGroupAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentWorkstationGroupAppointment(int ID)
        {
            ViewBag.WorkstationGroup = virames<WorkstationGroup>
                         .Initialize(new List<WorkstationGroup>())
                         .GetList().Select(x => new SelectListItem
                         {
                             Value = x.ID.ToString(),
                             Text = x.CodeAndDefinition + " | " + x.Location + " | " + x.Status
                         });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment = virames<DocumentWorkstationGroupAppointment>
                             .Initialize(new DocumentWorkstationGroupAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentWorkstationGroupAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentWorkstationGroupAppointment(DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment)
        {
            documentWorkstationGroupAppointment.Save();
            return RedirectToAction("DocumentWorkstationGroupAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentWorkstationGroupAppointment(int ID)
        {
            DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment = virames<DocumentWorkstationGroupAppointment>
                            .Initialize(new DocumentWorkstationGroupAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentWorkstationGroupAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentWorkstationGroupAppointment(DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment)
        {
            documentWorkstationGroupAppointment.Save();
            return RedirectToAction("DocumentWorkstationGroupAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentWorkstationGroupAppointment(int ID)
        {
            DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment = virames<DocumentWorkstationGroupAppointment>
                           .Initialize(new DocumentWorkstationGroupAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentWorkstationGroupAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentWorkstationGroupAppointment(DocumentWorkstationGroupAppointment documentWorkstationGroupAppointment)
        {
            documentWorkstationGroupAppointment.Delete();
            return RedirectToAction("DocumentWorkstationGroupAppointment");
        }
        #endregion

        #region documentEmployeeAppointment
        [HttpGet]
        public ActionResult DocumentEmployeeAppointment()
        {
            ViewBag.Isactive = 71;
            List<DocumentEmployeeAppointment> documentEmployeeList = virames<DocumentEmployeeAppointment>
                             .Initialize(new List<DocumentEmployeeAppointment>())
                             .GetList();
            return View(documentEmployeeList);
        }
        [HttpGet]
        public ActionResult NewDocumentEmployeeAppointment()
        {
            ViewBag.Employee = virames<Employee>
                          .Initialize(new List<Employee>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Name + " | " + x.Status + " | " + x.Cost
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentEmployeeAppointment documentEmployeeAppointment = new DocumentEmployeeAppointment();
            return View(documentEmployeeAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentEmployeeAppointment(DocumentEmployeeAppointment documentEmployeeAppointment)
        {
            documentEmployeeAppointment.Save();
            return RedirectToAction("DocumentEmployeeAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentEmployeeAppointment(int ID)
        {
            ViewBag.Employee = virames<Employee>
                         .Initialize(new List<Employee>())
                         .GetList().Select(x => new SelectListItem
                         {
                             Value = x.ID.ToString(),
                             Text = x.Code + " | " + x.Name + " | " + x.Status + " | " + x.Cost
                         });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentEmployeeAppointment documentEmployeeAppointment = virames<DocumentEmployeeAppointment>
                             .Initialize(new DocumentEmployeeAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentEmployeeAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentEmployeeAppointment(DocumentEmployeeAppointment documentEmployeeAppointment)
        {
            documentEmployeeAppointment.Save();
            return RedirectToAction("DocumentEmployeeAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentEmployeeAppointment(int ID)
        {
            DocumentEmployeeAppointment documentEmployeeAppointment = virames<DocumentEmployeeAppointment>
                            .Initialize(new DocumentEmployeeAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentEmployeeAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentEmployeeAppointment(DocumentEmployeeAppointment documentEmployeeAppointment)
        {
            documentEmployeeAppointment.Save();
            return RedirectToAction("DocumentEmployeeAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentEmployeeAppointment(int ID)
        {
            DocumentEmployeeAppointment documentEmployeeAppointment = virames<DocumentEmployeeAppointment>
                           .Initialize(new DocumentEmployeeAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentEmployeeAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentEmployeeAppointment(DocumentEmployeeAppointment documentEmployeeAppointment)
        {
            documentEmployeeAppointment.Delete();
            return RedirectToAction("DocumentEmployeeAppointment");
        }
        #endregion

        #region documentProductOrderAppointment
        [HttpGet]
        public ActionResult DocumentProductOrderAppointment()
        {
            ViewBag.Isactive = 72;
            List<DocumentProductOrderAppointment> documentProductOrderAppList = virames<DocumentProductOrderAppointment>
                             .Initialize(new List<DocumentProductOrderAppointment>())
                             .GetList();
            return View(documentProductOrderAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentProductOrderAppointment()
        {
            ViewBag.ProductOrder = virames<ProductOrder>
                          .Initialize(new List<ProductOrder>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Description + " | " + x.Completion + " | " + x.Date.ToString("yyyy,MM,dd") + " | " + x.PlanningStatus
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentProductOrderAppointment documentProductOrderAppointment = new DocumentProductOrderAppointment();
            return View(documentProductOrderAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentProductOrderAppointment(DocumentProductOrderAppointment documentProductOrderAppointment)
        {
            documentProductOrderAppointment.Save();
            return RedirectToAction("DocumentProductOrderAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentProductOrderAppointment(int ID)
        {
            ViewBag.ProductOrder = virames<ProductOrder>
                          .Initialize(new List<ProductOrder>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Description + " | " + x.Completion + " | " + x.Date.ToString("yyyy,MM,dd") + " | " + x.PlanningStatus
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentProductOrderAppointment documentProductOrderAppointment = virames<DocumentProductOrderAppointment>
                             .Initialize(new DocumentProductOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentProductOrderAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentProductOrderAppointment(DocumentProductOrderAppointment documentProductOrderAppointment)
        {
            documentProductOrderAppointment.Save();
            return RedirectToAction("DocumentProductOrderAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentProductOrderAppointment(int ID)
        {
            DocumentProductOrderAppointment documentProductOrderAppointment = virames<DocumentProductOrderAppointment>
                            .Initialize(new DocumentProductOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentProductOrderAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentProductOrderAppointment(DocumentProductOrderAppointment documentProductOrderAppointment)
        {
            documentProductOrderAppointment.Save();
            return RedirectToAction("DocumentProductOrderAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentProductOrderAppointment(int ID)
        {
            DocumentProductOrderAppointment documentProductOrderAppointment = virames<DocumentProductOrderAppointment>
                           .Initialize(new DocumentProductOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentProductOrderAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentProductOrderAppointment(DocumentProductOrderAppointment documentProductOrderAppointment)
        {
            documentProductOrderAppointment.Delete();
            return RedirectToAction("DocumentProductOrderAppointment");
        }
        #endregion

        #region documentMaterialFicheAppointment
        [HttpGet]
        public ActionResult DocumentMaterialFicheAppointment()
        {
            ViewBag.Isactive = 73;
            List<DocumentMaterialFicheAppointment> documentMaterialFicheAppList = virames<DocumentMaterialFicheAppointment>
                             .Initialize(new List<DocumentMaterialFicheAppointment>())
                             .GetList();
            return View(documentMaterialFicheAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentMaterialFicheAppointment()
        {
            ViewBag.MaterialFiche = virames<MaterialFiche>
                          .Initialize(new List<MaterialFiche>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Type + " | " + x.Warehouse + " | " + x.PurchaseOrder + " | " + x.Workorder + " | " + x.BarcodeStatus
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentMaterialFicheAppointment documentMaterialFicheAppointment = new DocumentMaterialFicheAppointment();
            return View(documentMaterialFicheAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentMaterialFicheAppointment(DocumentMaterialFicheAppointment documentMaterialFicheAppointment)
        {
            documentMaterialFicheAppointment.Save();
            return RedirectToAction("DocumentMaterialFicheAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentMaterialFicheAppointment(int ID)
        {
            ViewBag.MaterialFiche = virames<MaterialFiche>
                          .Initialize(new List<MaterialFiche>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Type + " | " + x.Warehouse + " | " + x.PurchaseOrder + " | " + x.Workorder + " | " + x.BarcodeStatus
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentMaterialFicheAppointment documentMaterialFicheAppointment = virames<DocumentMaterialFicheAppointment>
                             .Initialize(new DocumentMaterialFicheAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentMaterialFicheAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentMaterialFicheAppointment(DocumentMaterialFicheAppointment documentMaterialFicheAppointment)
        {
            documentMaterialFicheAppointment.Save();
            return RedirectToAction("DocumentMaterialFicheAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentMaterialFicheAppointment(int ID)
        {
            DocumentMaterialFicheAppointment documentMaterialFicheAppointment = virames<DocumentMaterialFicheAppointment>
                            .Initialize(new DocumentMaterialFicheAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentMaterialFicheAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentMaterialFicheAppointment(DocumentMaterialFicheAppointment documentMaterialFicheAppointment)
        {
            documentMaterialFicheAppointment.Save();
            return RedirectToAction("DocumentMaterialFicheAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentMaterialFicheAppointment(int ID)
        {
            DocumentMaterialFicheAppointment documentMaterialFicheAppointment = virames<DocumentMaterialFicheAppointment>
                           .Initialize(new DocumentMaterialFicheAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentMaterialFicheAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentMaterialFicheAppointment(DocumentMaterialFicheAppointment documentMaterialFicheAppointment)
        {
            documentMaterialFicheAppointment.Delete();
            return RedirectToAction("DocumentMaterialFicheAppointment");
        }
        #endregion

        #region documentCertificateAppointment
        [HttpGet]
        public ActionResult DocumentCertificateAppointment()
        {
            ViewBag.Isactive = 74;
            List<DocumentCertificateAppointment> documentCertificateAppList = virames<DocumentCertificateAppointment>
                             .Initialize(new List<DocumentCertificateAppointment>())
                             .GetList();
            return View(documentCertificateAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentCertificateAppointment()
        {
            ViewBag.Certificate = virames<Certificate>
                          .Initialize(new List<Certificate>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Definition
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentCertificateAppointment documentCertificateAppointment = new DocumentCertificateAppointment();
            return View(documentCertificateAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentCertificateAppointment(DocumentCertificateAppointment documentCertificateAppointment)
        {
            documentCertificateAppointment.Save();
            return RedirectToAction("DocumentCertificateAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentCertificateAppointment(int ID)
        {
            ViewBag.Certificate = virames<Certificate>
                          .Initialize(new List<Certificate>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Definition
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentCertificateAppointment documentCertificateAppointment = virames<DocumentCertificateAppointment>
                             .Initialize(new DocumentCertificateAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentCertificateAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentCertificateAppointment(DocumentCertificateAppointment documentCertificateAppointment)
        {
            documentCertificateAppointment.Save();
            return RedirectToAction("DocumentCertificateAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentCertificateAppointment(int ID)
        {
            DocumentCertificateAppointment documentCertificateAppointment = virames<DocumentCertificateAppointment>
                            .Initialize(new DocumentCertificateAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentCertificateAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentCertificateAppointment(DocumentCertificateAppointment documentCertificateAppointment)
        {
            documentCertificateAppointment.Save();
            return RedirectToAction("DocumentCertificateAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentCertificateAppointment(int ID)
        {
            DocumentCertificateAppointment documentCertificateAppointment = virames<DocumentCertificateAppointment>
                           .Initialize(new DocumentCertificateAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentCertificateAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentCertificateAppointment(DocumentCertificateAppointment documentCertificateAppointment)
        {
            documentCertificateAppointment.Delete();
            return RedirectToAction("DocumentCertificateAppointment");
        }
        #endregion

        #region documentProjectAppointwment
        [HttpGet]
        public ActionResult DocumentProjectAppointment()
        {
            ViewBag.Isactive = 75;
            List<DocumentProjectAppointment> documentProjectAppList = virames<DocumentProjectAppointment>
                             .Initialize(new List<DocumentProjectAppointment>())
                             .GetList();
            return View(documentProjectAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentProjectAppointment()
        {
            ViewBag.Project = virames<Project>
                          .Initialize(new List<Project>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Definition + " | " + x.StartDate.ToString("yyyy.MM.dd") + " | " + x.EndDate.ToString("yyyy.MM.dd")
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentProjectAppointment documentProjectAppointment = new DocumentProjectAppointment();
            return View(documentProjectAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentProjectAppointment(DocumentProjectAppointment documentProjectAppointment)
        {
            documentProjectAppointment.Save();
            return RedirectToAction("DocumentProjectAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentProjectAppointment(int ID)
        {
            ViewBag.Project = virames<Project>
                          .Initialize(new List<Project>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Code + " | " + x.Definition + " | " + x.StartDate.ToString("yyyy.MM.dd") + " | " + x.EndDate.ToString("yyyy.MM.dd")
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentProjectAppointment documentProjectAppointment = virames<DocumentProjectAppointment>
                             .Initialize(new DocumentProjectAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentProjectAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentProjectAppointment(DocumentProjectAppointment documentProjectAppointment)
        {
            documentProjectAppointment.Save();
            return RedirectToAction("DocumentProjectAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentProjectAppointment(int ID)
        {
            DocumentProjectAppointment documentProjectAppointment = virames<DocumentProjectAppointment>
                            .Initialize(new DocumentProjectAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentProjectAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentProjectAppointment(DocumentProjectAppointment documentProjectAppointment)
        {
            documentProjectAppointment.Save();
            return RedirectToAction("DocumentProjectAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentProjectAppointment(int ID)
        {
            DocumentProjectAppointment DocumentProjectAppointment = virames<DocumentProjectAppointment>
                           .Initialize(new DocumentProjectAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(DocumentProjectAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentProjectAppointment(DocumentProjectAppointment documentProjectAppointment)
        {
            documentProjectAppointment.Delete();
            return RedirectToAction("DocumentProjectAppointment");
        }
        #endregion

        #region documentPurchaseIndentAppointment
        [HttpGet]
        public ActionResult DocumentPurchaseIndentAppointment()
        {
            ViewBag.Isactive = 76;
            List<DocumentPurchaseIndentAppointment> documentPurchaseIndentAppList = virames<DocumentPurchaseIndentAppointment>
                             .Initialize(new List<DocumentPurchaseIndentAppointment>())
                             .GetList();
            return View(documentPurchaseIndentAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentPurchaseIndentAppointment()
        {
            ViewBag.PurchaseIndent = virames<PurchaseIndent>
                          .Initialize(new List<PurchaseIndent>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.PurchaseDemand + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment = new DocumentPurchaseIndentAppointment();
            return View(documentPurchaseIndentAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentPurchaseIndentAppointment(DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment)
        {
            documentPurchaseIndentAppointment.Save();
            return RedirectToAction("DocumentPurchaseIndentAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentPurchaseIndentAppointment(int ID)
        {
            ViewBag.PurchaseIndent = virames<PurchaseIndent>
                         .Initialize(new List<PurchaseIndent>())
                         .GetList().Select(x => new SelectListItem
                         {
                             Value = x.ID.ToString(),
                             Text = x.Number + " | " + x.PurchaseDemand + " | " + x.ApprovalInformation
                         });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment = virames<DocumentPurchaseIndentAppointment>
                             .Initialize(new DocumentPurchaseIndentAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentPurchaseIndentAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentPurchaseIndentAppointment(DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment)
        {
            documentPurchaseIndentAppointment.Save();
            return RedirectToAction("DocumentPurchaseIndentAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentPurchaseIndentAppointment(int ID)
        {
            DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment = virames<DocumentPurchaseIndentAppointment>
                            .Initialize(new DocumentPurchaseIndentAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentPurchaseIndentAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentPurchaseIndentAppointment(DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment)
        {
            documentPurchaseIndentAppointment.Save();
            return RedirectToAction("DocumentPurchaseIndentAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentPurchaseIndentAppointment(int ID)
        {
            DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment = virames<DocumentPurchaseIndentAppointment>
                           .Initialize(new DocumentPurchaseIndentAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentPurchaseIndentAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentPurchaseIndentAppointment(DocumentPurchaseIndentAppointment documentPurchaseIndentAppointment)
        {
            documentPurchaseIndentAppointment.Delete();
            return RedirectToAction("DocumentPurchaseIndentAppointment");
        }
        #endregion

        #region documentPurchaseProposalAppointment
        [HttpGet]
        public ActionResult DocumentPurchaseProposalAppointment()
        {
            ViewBag.Isactive = 77;
            List<DocumentPurchaseProposalAppointment> documentPurchaseProposalAppList = virames<DocumentPurchaseProposalAppointment>
                             .Initialize(new List<DocumentPurchaseProposalAppointment>())
                             .GetList();
            return View(documentPurchaseProposalAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentPurchaseProposalAppointment()
        {
            ViewBag.PurchaseProposal = virames<PurchaseProposal>
                          .Initialize(new List<PurchaseProposal>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.PurchaseIndent + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment = new DocumentPurchaseProposalAppointment();
            return View(documentPurchaseProposalAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentPurchaseProposalAppointment(DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment)
        {
            documentPurchaseProposalAppointment.Save();
            return RedirectToAction("DocumentPurchaseProposalAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentPurchaseProposalAppointment(int ID)
        {
            ViewBag.PurchaseProposal = virames<PurchaseProposal>
                          .Initialize(new List<PurchaseProposal>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.PurchaseIndent + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment = virames<DocumentPurchaseProposalAppointment>
                             .Initialize(new DocumentPurchaseProposalAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentPurchaseProposalAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentPurchaseProposalAppointment(DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment)
        {
            documentPurchaseProposalAppointment.Save();
            return RedirectToAction("DocumentPurchaseProposalAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentPurchaseProposalAppointment(int ID)
        {
            DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment = virames<DocumentPurchaseProposalAppointment>
                            .Initialize(new DocumentPurchaseProposalAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentPurchaseProposalAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentPurchaseProposalAppointment(DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment)
        {
            documentPurchaseProposalAppointment.Save();
            return RedirectToAction("DocumentPurchaseProposalAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentPurchaseProposalAppointment(int ID)
        {
            DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment = virames<DocumentPurchaseProposalAppointment>
                           .Initialize(new DocumentPurchaseProposalAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentPurchaseProposalAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentPurchaseProposalAppointment(DocumentPurchaseProposalAppointment documentPurchaseProposalAppointment)
        {
            documentPurchaseProposalAppointment.Delete();
            return RedirectToAction("DocumentPurchaseProposalAppointment");
        }
        #endregion

        #region documentPurchaseContractAppointment
        [HttpGet]
        public ActionResult DocumentPurchaseContractAppointment()
        {
            ViewBag.Isactive = 78;
            List<DocumentPurchaseContractAppointment> documentPurchaseContractAppList = virames<DocumentPurchaseContractAppointment>
                             .Initialize(new List<DocumentPurchaseContractAppointment>())
                             .GetList();
            return View(documentPurchaseContractAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentPurchaseContractAppointment()
        {
            ViewBag.PurchaseContract = virames<PurchaseContract>
                          .Initialize(new List<PurchaseContract>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Proposal + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseContractAppointment documentPurchaseContractAppointment = new DocumentPurchaseContractAppointment();
            return View(documentPurchaseContractAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentPurchaseContractAppointment(DocumentPurchaseContractAppointment documentPurchaseContractAppointment)
        {
            documentPurchaseContractAppointment.Save();
            return RedirectToAction("DocumentPurchaseContractAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentPurchaseContractAppointment(int ID)
        {
            ViewBag.PurchaseContract = virames<PurchaseContract>
                          .Initialize(new List<PurchaseContract>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.Proposal + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseContractAppointment documentPurchaseContractAppointment = virames<DocumentPurchaseContractAppointment>
                             .Initialize(new DocumentPurchaseContractAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentPurchaseContractAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentPurchaseContractAppointment(DocumentPurchaseContractAppointment documentPurchaseContractAppointment)
        {
            documentPurchaseContractAppointment.Save();
            return RedirectToAction("DocumentPurchaseContractAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentPurchaseContractAppointment(int ID)
        {
            DocumentPurchaseContractAppointment documentPurchaseContractAppointment = virames<DocumentPurchaseContractAppointment>
                            .Initialize(new DocumentPurchaseContractAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentPurchaseContractAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentPurchaseContractAppointment(DocumentPurchaseContractAppointment documentPurchaseContractAppointment)
        {
            documentPurchaseContractAppointment.Save();
            return RedirectToAction("DocumentPurchaseContractAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentPurchaseContractAppointment(int ID)
        {
            DocumentPurchaseContractAppointment documentPurchaseContractAppointment = virames<DocumentPurchaseContractAppointment>
                           .Initialize(new DocumentPurchaseContractAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentPurchaseContractAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentPurchaseContractAppointment(DocumentPurchaseContractAppointment documentPurchaseContractAppointment)
        {
            documentPurchaseContractAppointment.Delete();
            return RedirectToAction("DocumentPurchaseContractAppointment");
        }
        #endregion

        #region documentPurchaseOrderAppointment
        [HttpGet]
        public ActionResult DocumentPurchaseOrderAppointment()
        {
            ViewBag.Isactive = 79;
            List<DocumentPurchaseOrderAppointment> documentPurchaseOrderAppList = virames<DocumentPurchaseOrderAppointment>
                             .Initialize(new List<DocumentPurchaseOrderAppointment>())
                             .GetList();
            return View(documentPurchaseOrderAppList);
        }
        [HttpGet]
        public ActionResult NewDocumentPurchaseOrderAppointment()
        {
            ViewBag.PurchaseOrder = virames<PurchaseOrder>
                          .Initialize(new List<PurchaseOrder>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.PurchaseContract + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment = new DocumentPurchaseOrderAppointment();
            return View(documentPurchaseOrderAppointment);
        }
        [HttpPost]
        public ActionResult NewDocumentPurchaseOrderAppointment(DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment)
        {
            documentPurchaseOrderAppointment.Save();
            return RedirectToAction("DocumentPurchaseOrderAppointment");
        }
        [HttpGet]
        public ActionResult EditDocumentPurchaseOrderAppointment(int ID)
        {
            ViewBag.PurchaseOrder = virames<PurchaseOrder>
                          .Initialize(new List<PurchaseOrder>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Number + " | " + x.PurchaseContract + " | " + x.ApprovalInformation
                          });
            ViewBag.Document = virames<Document>
                          .Initialize(new List<Document>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.DocumentNo + " | " + x.FileName + " | " + x.Description + " | " + x.Status + " | " + x.Availability + " | " + x.Status + " | " + x.Type
                          });
            DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment = virames<DocumentPurchaseOrderAppointment>
                             .Initialize(new DocumentPurchaseOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(documentPurchaseOrderAppointment);
        }
        [HttpPost]
        public ActionResult EditDocumentPurchaseOrderAppointment(DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment)
        {
            documentPurchaseOrderAppointment.Save();
            return RedirectToAction("DocumentPurchaseOrderAppointment");
        }
        [HttpGet]
        public ActionResult DetailDocumentPurchaseOrderAppointment(int ID)
        {
            DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment = virames<DocumentPurchaseOrderAppointment>
                            .Initialize(new DocumentPurchaseOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(documentPurchaseOrderAppointment);
        }
        [HttpPost]
        public ActionResult DetailDocumentPurchaseOrderAppointment(DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment)
        {
            documentPurchaseOrderAppointment.Save();
            return RedirectToAction("DocumentPurchaseOrderAppointment");
        }
        [HttpGet]
        public ActionResult DeleteDocumentPurchaseOrderAppointment(int ID)
        {
            DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment = virames<DocumentPurchaseOrderAppointment>
                           .Initialize(new DocumentPurchaseOrderAppointment()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(documentPurchaseOrderAppointment);

        }
        [HttpPost]
        public ActionResult DeleteDocumentPurchaseOrderAppointment(DocumentPurchaseOrderAppointment documentPurchaseOrderAppointment)
        {
            documentPurchaseOrderAppointment.Delete();
            return RedirectToAction("DocumentPurchaseOrderAppointment");
        }
        #endregion
        #endregion

    }
}