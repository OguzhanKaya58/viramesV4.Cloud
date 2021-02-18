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
    public class QualityManagementController : Controller
    {
        
        // GET: QualityManagement
        public ActionResult qualityControlCriteriaSet()
        {
            ViewBag.Isactive = 33;
            List<CriteriaSet> qualityControlCriteriaSetList = virames<CriteriaSet>.Initialize(new List<CriteriaSet>()).GetList();
            return View(qualityControlCriteriaSetList);
        }
        public ActionResult Improprieties()
        {
            ViewBag.Isactive = 34;
            List<NonConformance> ImproprietiesList = virames<NonConformance>.Initialize(new List<NonConformance>()).GetList();
            return View(ImproprietiesList);
        }
        public ActionResult qualityControlFiche()
        {
            ViewBag.Isactive = 35;
            List<MaterialFiche> qualityConrolficheList = virames<MaterialFiche>.Initialize(new List<MaterialFiche>()).Where(x=>x.Type==TransactionType.QualityControlFiche).GetList();
            return View(qualityConrolficheList);
        }
        public ActionResult correctivePreventiveActivities()
        {
            ViewBag.Isactive = 36;
            List<NonConformanceCPA> correctivePreventiveActivityList = virames<NonConformanceCPA>.Initialize(new List<NonConformanceCPA>()).GetList();
            return View(correctivePreventiveActivityList);
        }
        public ActionResult purchaseReceiptsApprovalTransactions()
        {
            ViewBag.Isactive = 37;
            List<MaterialFiche> purchaseReceiptsApprovalTransactionList = virames<MaterialFiche>.Initialize(new List<MaterialFiche>()).Where(x=>x.Type==TransactionType.PurchaseFiche).GetList();
            return View(purchaseReceiptsApprovalTransactionList);
        }
        public ActionResult criteriaSetSpeCode()
        {
            ViewBag.Isactive = 38;
            List<SpeCode> criteriaSetSpeCodeList = virames<SpeCode>.Initialize(new List<SpeCode>()).Where(x=>x.SpeCodeType==SpeCodeType.CriteriaSet).GetList();
            return View(criteriaSetSpeCodeList);
        }
        public ActionResult ImproprietyType()
        {
            ViewBag.Isactive = 39;
            List<ImproprietyType> ImproprietyTypeList = virames<ImproprietyType>.Initialize(new List<ImproprietyType>()).GetList();
            return View(ImproprietyTypeList);
        }
        public ActionResult ImproprietyStepDefinitions()
        {
            ViewBag.Isactive = 40;
            List<NonConformanceStep> ImproprietyStepDefinitionList = virames<NonConformanceStep>.Initialize(new List<NonConformanceStep>()).GetList();
            return View(ImproprietyStepDefinitionList);
        }
    }
}