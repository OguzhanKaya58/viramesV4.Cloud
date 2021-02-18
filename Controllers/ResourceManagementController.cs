#region System
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
#endregion
{ 
    [ViramesAuthorization]
    public class ResourceManagementController : Controller
    {

        #region Master Records
        #region workstationGroup
        public ActionResult WorkstationGroup()
        {
            ViewBag.Isactive = 41;
            List<WorkstationGroup> WorkstationGroupList = virames<WorkstationGroup>
                             .Initialize(new List<WorkstationGroup>())
                              .GetList();
            return View(WorkstationGroupList);
        }
        [HttpGet]
        public ActionResult NewWorkstationGroup()
        {

            WorkstationGroup workstationGroup = new WorkstationGroup();
            return View(workstationGroup);
        }
        [HttpPost]
        public ActionResult NewWorkstationGroup(WorkstationGroup workstationGroup)
        {

            workstationGroup.Save();
            return RedirectToAction("WorkstationGroup");
        }
        [HttpGet]
        public ActionResult EditWorkstationGroup(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            WorkstationGroup workstationGroup = virames<WorkstationGroup>
                             .Initialize(new WorkstationGroup()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(workstationGroup);
        }
        [HttpPost]
        public ActionResult EditWorkstationGroup(WorkstationGroup workstationGroup)
        {

            workstationGroup.Save();
            return RedirectToAction("WorkstationGroup");
        }
        [HttpGet]
        public ActionResult DetailWorkstationGroup(int ID)
        {
            WorkstationGroup workstationGroup = virames<WorkstationGroup>
                            .Initialize(new WorkstationGroup()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(workstationGroup);
        }
        [HttpPost]
        public ActionResult DetailWorkstationGroup(WorkstationGroup workstationGroup)
        {
            workstationGroup.Save();
            return RedirectToAction("WorkstationGroup");
        }
        [HttpGet]
        public ActionResult DeleteWorkstationGroup(int ID)
        {
            WorkstationGroup workstationGroup = virames<WorkstationGroup>
                           .Initialize(new WorkstationGroup()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(workstationGroup);

        }
        [HttpPost]
        public ActionResult DeleteWorkstationGroup(WorkstationGroup workstationGroup)
        {
            workstationGroup.Delete();
            return RedirectToAction("WorkstationGroup");
        }
        [HttpGet]
        public ActionResult WorkstationGroupWorkstationAppointmentAssigned(int ID)
        {
            List<Workstation> workstationGroupWorkstationAppointmentAssigned = virames<WorkstationGroupWorkstationAppointment>
                             .Initialize(new List<WorkstationGroupWorkstationAppointment>())
                             .Where(x => x.WorkstationGroupID == ID)
                            .GetList().Select(x => x.Workstation).ToList();
            return View(workstationGroupWorkstationAppointmentAssigned);
        }
        [HttpGet]
        public ActionResult EmployeeWorkstationGroupAppointmentAssigned(int ID)
        {
            List<Employee> employees = virames<EmployeeWorkstationGroupAppointment>
                            .Initialize(new List<EmployeeWorkstationGroupAppointment>())
                            .Where(x => x.WorkstationGroupID == ID)
                            .GetList().Select(x => x.Employee).ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult DocumentWorkstationGroupAppointmentAssigned(int ID)
        {
            List<Document> document = virames<DocumentWorkstationGroupAppointment>
                             .Initialize(new List<DocumentWorkstationGroupAppointment>())
                              .Where(x => x.WorkstationGroupID == ID)
                             .GetList().Select(x => x.Document).ToList();
            return View(document);
        }
        #endregion

        #region workstation
        public ActionResult Workstations()
        {
            ViewBag.Isactive = 43;
            List<Workstation> workstationList = virames<Workstation>
                             .Initialize(new List<Workstation>())
                             .GetList();
            return View(workstationList);
        }
        [HttpGet]
        public ActionResult EditWorkstation(int ID)
        {
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            Workstation workstation = virames<Workstation>
                             .Initialize(new Workstation()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(workstation);
        }
        [HttpPost]
        public ActionResult EditWorkstation(Workstation workstation)
        {
            workstation.Save();
            return RedirectToAction("Workstations");
        }
        [HttpGet]
        public ActionResult DetailWorkstations(int ID)
        {
            Workstation workstation = virames<Workstation>
                            .Initialize(new Workstation()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(workstation);
        }
        [HttpPost]
        public ActionResult DetailWorkstations(Workstation workstation)
        {
            workstation.Save();
            return RedirectToAction("Workstations");
        }
        [HttpGet]
        public ActionResult DeleteWorkstations(int ID)
        {
            Workstation workstation = virames<Workstation>
                           .Initialize(new Workstation()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(workstation);

        }
        [HttpPost]
        public ActionResult DeleteWorkstations(Workstation workstation)
        {
            RealEstate realEstate = virames<RealEstate>
                           .Initialize(new RealEstate()).Where(x => x.ID == workstation.ID)
                           .Take();
            if (realEstate != null)
                realEstate.Delete();
            workstation.Delete();
            return RedirectToAction("Workstations");
        }
        [HttpGet]
        public ActionResult EmployeeWorkstationAppointmentAssigneds(int ID)
        {
            List<Employee> employees = virames<EmployeeWorkstationAppointment>
                            .Initialize(new List<EmployeeWorkstationAppointment>())
                            .Where(x => x.WorkstationID == ID)
                            .GetList().Select(x => x.Employee).ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult DocumentWorkstationAppointmentAssigneds(int ID)
        {
            List<Document> document = virames<DocumentWorkstationAppointment>
                             .Initialize(new List<DocumentWorkstationAppointment>())
                              .Where(x => x.WorkstationID == ID)
                             .GetList().Select(x => x.Document).ToList();
            return View(document);
        }
        #endregion

        #region employee
        public ActionResult Employee()
        {
            ViewBag.Isactive = 44;
            List<Employee> EmployeeList = virames<Employee>
                             .Initialize(new List<Employee>())
                             .GetList();
            return View(EmployeeList);
        }
        [HttpGet]
        public ActionResult NewEmployee()
        {
            ViewBag.DepartmentScope = virames<Department>
                          .Initialize(new List<Department>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = "Kod = " + x.Code + " | " + "Tanım = " + x.Definition
                          });
            ViewBag.EmployeeType = new SelectList(Enum.GetValues(typeof(EmployeeType)));
            ViewBag.MaritalStatus = new SelectList(Enum.GetValues(typeof(MaritalStatus)));
            ViewBag.EducationLevel = new SelectList(Enum.GetValues(typeof(EducationLevel)));
            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)));
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult NewEmployee(Employee employee)
        {

            employee.Save();
            return RedirectToAction("Employee");
        }
        [HttpGet]
        public ActionResult EditEmployees(int ID)
        {
            ViewBag.MaritalStatus = new SelectList(Enum.GetValues(typeof(MaritalStatus)));
            ViewBag.EducationLevel = new SelectList(Enum.GetValues(typeof(EducationLevel)));
            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)));
            ViewBag.RecordStatus = new SelectList(Enum.GetValues(typeof(RecordStatus)));
            ViewBag.DepartmentScope = virames<Department>
                             .Initialize(new List<Department>())
                             .GetList().Select(x => new SelectListItem
                             {
                                 Value = x.ID.ToString(),
                                 Text = "Kod = " + x.Code + " | " + "Tanım = " + x.Definition
                             });
            ViewBag.EmployeeType = new SelectList(Enum.GetValues(typeof(EmployeeType)));
            Employee employee = virames<Employee>
                             .Initialize(new Employee()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(employee);
        }
        [HttpPost]
        public ActionResult EditEmployees(Employee employee)
        {
            employee.Save();
            return RedirectToAction("Employee");
        }
        [HttpGet]
        public ActionResult DetailEmployees(int ID)
        {
            Employee employee = virames<Employee>
                            .Initialize(new Employee()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(employee);
        }
        [HttpPost]
        public ActionResult DetailEmployees(Employee employee)
        {
            employee.Save();
            return RedirectToAction("Employee");
        }
        [HttpGet]
        public ActionResult DeleteEmployees(int ID)
        {
            Employee employee = virames<Employee>
                           .Initialize(new Employee()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(employee);

        }
        [HttpPost]
        public ActionResult DeleteEmployees(Employee employee)
        {
            employee.Delete();
            return RedirectToAction("employee");
        }
        [HttpGet]
        public ActionResult EmployeeCertificateAppointmentAssigneds(int ID)
        {
            List<Certificate> certificate = virames<EmployeeCertificateAppointment>
                             .Initialize(new List<EmployeeCertificateAppointment>())
                              .Where(x => x.EmployeeID == ID)
                             .GetList().Select(x => x.Certificate).ToList();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult EmployeeShiftAppointmentAssigneds(int ID)
        {
            List<Shift> shift = virames<EmployeeShiftAppointment>
                            .Initialize(new List<EmployeeShiftAppointment>())
                             .Where(x => x.EmployeeID == ID)
                            .GetList().Select(x => x.Shift).ToList();
            return View(shift);
        }
        [HttpGet]
        public ActionResult EmployeeDocumentUtilizationAssigned(int ID)
        {
            List<Document> document = virames<EmployeeDocumentUtilization>
                            .Initialize(new List<EmployeeDocumentUtilization>())
                             .Where(x => x.EmployeeID == ID)
                            .GetList().Select(x => x.Document).ToList();
            return View(document);
        }
        #endregion

        #region certificateList
        public ActionResult CertificateList()
        {
            ViewBag.Isactive = 45;
            List<Certificate> certificateList = virames<Certificate>
                             .Initialize(new List<Certificate>())
                             .GetList();
            return View(certificateList);
        }
        [HttpGet]
        public ActionResult NewCertificatee()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Certificate certificate = new Certificate();
            return View(certificate);
        }
        [HttpPost]
        public ActionResult NewCertificatee(Certificate certificate)
        {
            certificate.Save();
            return RedirectToAction("CertificateList");
        }
        [HttpGet]
        public ActionResult EditCertificatee(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            Certificate certificate = virames<Certificate>
                             .Initialize(new Certificate()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(certificate);
        }
        [HttpPost]
        public ActionResult EditCertificatee(Certificate certificate)
        {
            certificate.Save();
            return RedirectToAction("CertificateList");
        }
        [HttpGet]
        public ActionResult DetailCertificatee(int ID)
        {
            Certificate certificate = virames<Certificate>
                            .Initialize(new Certificate()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(certificate);
        }
        [HttpPost]
        public ActionResult DetailCertificatee(Certificate certificate)
        {
            certificate.Save();
            return RedirectToAction("CertificateList");
        }
        [HttpGet]
        public ActionResult DeleteCertificatee(int ID)
        {
            Certificate certificate = virames<Certificate>
                           .Initialize(new Certificate()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(certificate);

        }
        [HttpPost]
        public ActionResult DeleteCertificatee(Certificate certificate)
        {
            certificate.Delete();
            return RedirectToAction("CertificateList");
        }
        [HttpGet]
        public ActionResult DocumentCertificateAppointmentAssigneds(int ID)
        {
            List<Document> document = virames<DocumentCertificateAppointment>
                             .Initialize(new List<DocumentCertificateAppointment>())
                              .Where(x => x.CertificateID == ID)
                             .GetList().Select(x => x.Document).ToList();
            return View(document);
        }
        #endregion
        #endregion

        #region Transactions
        #region workstationPeriodicMaintenance
        public ActionResult WorkstationPeriodicMaintenance()
        {
            ViewBag.Isactive = 46;
            List<PeriodicMaintenance> PeriodicMaintenanceList = virames<PeriodicMaintenance>
                             .Initialize(new List<PeriodicMaintenance>())
                             .GetList();


            return View(PeriodicMaintenanceList);
        }
        [HttpGet]
        public ActionResult NewWorkstationPeriodicMaintenance()
        {
            ViewBag.Employee = virames<User>.Initialize(new List<User>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            });
            ViewBag.Workstation = virames<Workstation>.Initialize(new List<Workstation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Definition + " <<|>> " + x.Code + " <<|>> " + x.Status + " <<|>> " + x.Cost + " <<|>> " + x.PeriodicMaintenanceAmount + " <<|>> " + x.PeriodicMaintenanceDate
            });
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            PeriodicMaintenance periodicMaintenance = new PeriodicMaintenance();
            return View(periodicMaintenance);
        }
        [HttpPost]
        public ActionResult NewWorkstationPeriodicMaintenance(PeriodicMaintenance periodicMaintenance)
        {
            periodicMaintenance.Save();
            return RedirectToAction("WorkstationPeriodicMaintenance");
        }
        [HttpGet]
        public ActionResult EditWorkstationPeriodicMaintenance(int ID)
        {
            ViewBag.Employee = virames<User>.Initialize(new List<User>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            });
            ViewBag.Workstation = virames<Workstation>.Initialize(new List<Workstation>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Definition + " <<|>> " + x.Code + " <<|>> " + x.Status + " <<|>> " + x.Cost + " <<|>> " + x.PeriodicMaintenanceAmount + " <<|>> " + x.PeriodicMaintenanceDate
            });

            PeriodicMaintenance periodicMaintenance = virames<PeriodicMaintenance>
                             .Initialize(new PeriodicMaintenance()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(periodicMaintenance);
        }
        [HttpPost]
        public ActionResult EditWorkstationPeriodicMaintenance(PeriodicMaintenance periodicMaintenance)
        {
            periodicMaintenance.Save();
            return RedirectToAction("WorkstationPeriodicMaintenance");
        }
        [HttpGet]
        public ActionResult DetailWorkstationPeriodicMaintenance(int ID)
        {
            PeriodicMaintenance periodicMaintenance = virames<PeriodicMaintenance>
                            .Initialize(new PeriodicMaintenance()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(periodicMaintenance);
        }
        [HttpPost]
        public ActionResult DetailWorkstationPeriodicMaintenance(PeriodicMaintenance periodicMaintenance)
        {
            periodicMaintenance.Save();
            return RedirectToAction("WorkstationPeriodicMaintenance");
        }
        [HttpGet]
        public ActionResult DeleteWorkstationPeriodicMaintenance(int ID)
        {
            PeriodicMaintenance periodicMaintenance = virames<PeriodicMaintenance>
                           .Initialize(new PeriodicMaintenance()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(periodicMaintenance);

        }
        [HttpPost]
        public ActionResult DeleteWorkstationPeriodicMaintenance(PeriodicMaintenance periodicMaintenance)
        {
            periodicMaintenance.Delete();
            return RedirectToAction("WorkstationPeriodicMaintenance");
        }
        #endregion

        #region employeeWorkstationGroupAppointment
        public ActionResult EmployeeWorkstationGroupAppointment()
        {
            ViewBag.Isactive = 47;
            List<EmployeeWorkstationGroupAppointment> EmployeeWorkstationGroupAppointmentList = virames<EmployeeWorkstationGroupAppointment>
                              .Initialize(new List<EmployeeWorkstationGroupAppointment>())
                              .GetList();
            return View(EmployeeWorkstationGroupAppointmentList);
        }
        [HttpGet]
        public ActionResult NewEmployeeWorkstationGroupAppointments()
        {

            ViewBag.WorkstationGroup = virames<WorkstationGroup>.Initialize(new List<WorkstationGroup>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Definition,
                Selected = x.ID.Equals(6)
            });
            ViewBag.Employees = virames<Employee>.Initialize(new List<Employee>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name + " [" + x.Title + "]",


            });
            ViewBag.WorkstationGroupEmployees = null;

            EmployeeWorkstationGroupAppointment employeeWorkstationGroupAppointment = new EmployeeWorkstationGroupAppointment();
            //if (Session["WorkstationId"] != null)
            //{
            //    int id = (int)Session["WorkstationId"];
            //    employeeWorkstationGroupAppointment.WorkstationGroup = virames<WorkstationGroup>.Initialize(new WorkstationGroup()).Where(x => x.ID == id).Take();
            //    Session["WorkstationId"] = null;
            //}
            return View(employeeWorkstationGroupAppointment);
        }
        [HttpPost]
        public ActionResult NewEmployeeWorkstationGroupAppointments(EmployeeWorkstationGroupAppointment employeeWorkstationGroupAppointment)
        {
            employeeWorkstationGroupAppointment.Save();
            return RedirectToAction("EmployeeWorkstationGroupAppointment");
        }
        public ActionResult GetEmployees(int id)
        {
            try
            {

                List<EmployeeWorkstationGroupAppointment> employeeWorkstationGroupAppointment = virames<EmployeeWorkstationGroupAppointment>.Initialize(new List<EmployeeWorkstationGroupAppointment>()).Where(x => x.WorkstationGroup.ID == id).GetList();
                List<Employee> employees = new List<Employee>();
                foreach (var item in employeeWorkstationGroupAppointment)
                {
                    employees.Add(item.Employee);
                }
                ViewBag.WorkstationGroupEmployees = employees.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name + " [" + x.Title + "]",
                });
                return RedirectToAction("newEmployeeWorkstationGroupAppointment");
            }
            catch (Exception SerialEx)
            {

                throw SerialEx;
            }
        }
        #endregion

        #region workstationShiftAppointment
        public ActionResult WorkstationShiftAppointment()
        {
            ViewBag.Isactive = 48;
            List<WorkstationShiftAppointment> bomList = virames<WorkstationShiftAppointment>
                             .Initialize(new List<WorkstationShiftAppointment>())
                             .GetList();
            return View(bomList);
        }
        #endregion

        #region workstationGroupWorkstationAppointment
        public ActionResult WorkstationGroupWorkstationAppointment()
        {
            ViewBag.Isactive = 49;
            Statics.SetUser(virames<User>.Initialize(new Object.BusinessLogicLayer.System.User()).Where(x => x.Username == "virames").Take());
            Statics.SetWorkarea(virames<Workarea>.Initialize(new Workarea()).Where(x => x.Code == "DIZAYN").Take());
            List<WorkstationGroupWorkstationAppointment> costWorkstationAppList = virames<WorkstationGroupWorkstationAppointment>
                             .Initialize(new List<WorkstationGroupWorkstationAppointment>())
                             .GetList();
            return View(costWorkstationAppList);
        }
        #endregion

        #region employeeCertificateAppointment
        public ActionResult EmployeeCertificateAppointment()
        {
            ViewBag.Isactive = 50;
            List<EmployeeCertificateAppointment> EmployeeCertificateAppointmentList = virames<EmployeeCertificateAppointment>
                             .Initialize(new List<EmployeeCertificateAppointment>())
                             .GetList();
            return View(EmployeeCertificateAppointmentList);
        }
        #endregion

        #region employeeShiftAppointment
        public ActionResult EmployeeShiftAppointment()
        {
            ViewBag.Isactive = 51;
            List<Shift> shift = virames<EmployeeShiftAppointment>
                            .Initialize(new List<EmployeeShiftAppointment>())
                            .GetList().Select(x => x.Shift).ToList();
            return View(shift);
        }
        #endregion

        #region employeeWorkstationAppointment
        public ActionResult EmployeeWorkstationAppointment()
        {
            ViewBag.Isactive = 52;
            List<EmployeeWorkstationAppointment> EmployeeWorkstationAppointmentList = virames<EmployeeWorkstationAppointment>
                            .Initialize(new List<EmployeeWorkstationAppointment>())
                            .GetList();
            return View(EmployeeWorkstationAppointmentList);
        }
        #endregion
        #endregion

        #region Definitions
        #region location
        public ActionResult Location()
        {
            ViewBag.Isactive = 53;
            List<Location> _LocationList = virames<Location>
                             .Initialize(new List<Location>())
                             .GetList();
            return View(_LocationList);
        }
        [HttpGet]
        public ActionResult NewLocation()
        {
            Location location = new Location();
            return View(location);
        }
        [HttpPost]
        public ActionResult NewLocation(Location location)
        {
            location.Save();
            return RedirectToAction("Location");
        }
        [HttpGet]
        public ActionResult EditLocation(int ID)
        {
            Location location = virames<Location>
                             .Initialize(new Location()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(location);
        }
        [HttpPost]
        public ActionResult EditLocation(Location location)
        {
            location.Save();
            return RedirectToAction("Location");
        }
        [HttpGet]
        public ActionResult DetailLocation(int ID)
        {
            Location location = virames<Location>
                            .Initialize(new Location()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(location);
        }
        [HttpPost]
        public ActionResult DetailLocation(Location location)
        {
            location.Save();
            return RedirectToAction("Location");
        }
        [HttpGet]
        public ActionResult DeleteLocation(int ID)
        {
            Location location = virames<Location>
                           .Initialize(new Location()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(location);

        }
        [HttpPost]
        public ActionResult DeleteLocation(Location location)
        {
            location.Delete();
            return RedirectToAction("Location");
        }
        #endregion

        #region department
        public ActionResult Department()
        {
            ViewBag.Isactive = 54;
            List<Department> departmanList = virames<Department>
                             .Initialize(new List<Department>())
                             .GetList();
            return View(departmanList);
        }
        [HttpGet]
        public ActionResult NewDepartment()
        {
            ViewBag.upperDepartment = virames<Department>
                          .Initialize(new List<Department>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = "" + x.Definition
                          });
            ViewBag.ResponsibleEmployee = virames<Employee>
                           .Initialize(new List<Employee>())
                           .GetList().Select(x => new SelectListItem
                           {
                               Value = x.ID.ToString(),
                               Text = "" + x.Name
                           });
            Department department = new Department();
            return View(department);
        }
        [HttpPost]
        public ActionResult NewDepartment(Department department)
        {

            department.Save();
            return RedirectToAction("Department");
        }
        [HttpGet]
        public ActionResult EditDepartment(int ID)
        {
            Department department = virames<Department>
                             .Initialize(new Department()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(department);
        }
        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {
            department.Save();
            return RedirectToAction("Department");
        }
        [HttpGet]
        public ActionResult DetailDepartment(int ID)
        {
            Department department = virames<Department>
                            .Initialize(new Department()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(department);
        }
        [HttpPost]
        public ActionResult DetailDepartment(Department department)
        {
            department.Save();
            return RedirectToAction("Department");
        }
        [HttpGet]
        public ActionResult DeleteDepartment(int ID)
        {
            Department department = virames<Department>
                           .Initialize(new Department()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(department);

        }
        [HttpPost]
        public ActionResult DeleteDepartment(Department department)
        {
            department.Delete();
            return RedirectToAction("Department");
        }
        #endregion

        #region departmentScopeRecord
        public ActionResult DepartmentScopeRecord()
        {
            ViewBag.Isactive = 55;
            List<DepartmentScopeRecord> departmentScopeRecord = virames<DepartmentScopeRecord>
                .Initialize(new List<DepartmentScopeRecord>())
                .GetList();
            return View(departmentScopeRecord);
        }
        [HttpGet]
        public ActionResult NewDepartmentScopeRecord()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.DepartmentScopeRecord = virames<DepartmentScopeRecord>
                           .Initialize(new List<DepartmentScopeRecord>())
                           .GetList().Select(x => new SelectListItem
                           {
                               Value = x.ID.ToString(),
                               Text = "" + x.Definition
                           });
            DepartmentScopeRecord departmentScopeRecord = new DepartmentScopeRecord();
            return View(departmentScopeRecord);
        }
        [HttpPost]
        public ActionResult NewDepartmentScopeRecord(DepartmentScopeRecord departmentScopeRecord)
        {
            departmentScopeRecord.Save();
            return RedirectToAction("DepartmentScopeRecord");
        }
        [HttpGet]
        public ActionResult EditDepartmentScopeRecord(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.DepartmentScopeRecord = virames<DepartmentScopeRecord>
                           .Initialize(new List<DepartmentScopeRecord>())
                           .GetList().Select(x => new SelectListItem
                           {
                               Value = x.ID.ToString(),
                               Text = "" + x.Definition
                           });
            DepartmentScopeRecord departmentScopeRecord = virames<DepartmentScopeRecord>
                             .Initialize(new DepartmentScopeRecord()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(departmentScopeRecord);
        }
        [HttpPost]
        public ActionResult EditDepartmentScopeRecord(DepartmentScopeRecord departmentScopeRecord)
        {
            departmentScopeRecord.Save();
            return RedirectToAction("DepartmentScopeRecord");
        }
        [HttpGet]
        public ActionResult DetailDepartmentScopeRecord(int ID)
        {
            DepartmentScopeRecord departmentScopeRecord = virames<DepartmentScopeRecord>
                            .Initialize(new DepartmentScopeRecord()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(departmentScopeRecord);
        }
        [HttpPost]
        public ActionResult DetailDepartmentScopeRecord(DepartmentScopeRecord departmentScopeRecord)
        {
            departmentScopeRecord.Save();
            return RedirectToAction("DepartmentScopeRecord");
        }
        [HttpGet]
        public ActionResult DeleteDepartmentScopeRecord(int ID)
        {
            DepartmentScopeRecord departmentScopeRecord = virames<DepartmentScopeRecord>
                           .Initialize(new DepartmentScopeRecord()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(departmentScopeRecord);

        }
        [HttpPost]
        public ActionResult DeleteDepartmentScopeRecord(DepartmentScopeRecord departmentScopeRecord)
        {
            departmentScopeRecord.Delete();
            return RedirectToAction("DepartmentScopeRecord");
        }
        #endregion
        #endregion

    }
}