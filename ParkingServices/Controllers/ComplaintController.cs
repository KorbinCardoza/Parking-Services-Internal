using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ParkingServices.Controllers
{


    [Authorize(Policy = "AllowedRolesOnly")]
    public class ComplaintController : Controller
    {
        private readonly ParkingContext _context;

        public ComplaintController(ParkingContext ctx)
        {
            _context = ctx;
        }
        
        public ActionResult Index(string complaintstatus, string empkey = "")
        {
            var complaintTypes = _context.ComplaintTypes.ToList();
            var employees = _context.Employees.Where(e => e.Active != 0).ToList();

            ViewBag.Status = (from c in _context.Complaints
                              select c.ComplaintStatus).Distinct();
            
            List<string> selectedEmployees = new List<string>();

            foreach (var e in employees)
            {
                selectedEmployees.Add(e.UserName);
            }

            ViewBag.EmployeeDD = selectedEmployees;


            var complaints = (from c in _context.Complaints
                              orderby c.ComplaintDateTime descending
                              where (c.ComplaintStatus == complaintstatus || complaintstatus == null || complaintstatus == "")
                              && (c.Employee.UserName == empkey || empkey == "")
                              select c).ToList();

            return View(complaints);
        }
        
        public IActionResult Details(int? id)
        {
            var complaintTypes = _context.ComplaintTypes.ToList();
            var employees = _context.Employees.Where(e => e.Active != 0).ToList();
            Complaint complaint = _context.Complaints.Find(id);
            if (id == null)
            {
              return BadRequest("request is incorrect");
            }
            if (complaint == null)
            {
                return NotFound();
            }
            return View(complaint);
        }

        // GET: Complaints/Create
        
        public Microsoft.AspNetCore.Mvc.ActionResult Create()
        {
            //dropdown for complaint type
            ViewBag.ComplaintType = new SelectList(_context.ComplaintTypes.OrderBy(x => x.ComplaintTypeDescription), "ComplaintType1", "ComplaintTypeDescription");



            List<SelectListItem> ParkedLocation = new List<SelectListItem>();

            ParkedLocation.Add(new SelectListItem { Text = "Select", Value = "" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-1", Value = "RP-1" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-2", Value = "RP-2" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-5", Value = "RP-5" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-7", Value = "RP-7" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-10", Value = "RP-10" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-12", Value = "RP-12" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-25", Value = "RP-25" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-90", Value = "RP-90" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-W-1", Value = "RP-W-1" });
            ParkedLocation.Add(new SelectListItem { Text = "Chemekata Parkade", Value = "CHEMEKATA PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Marion Parkade", Value = "MARION PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Liberty Parkade", Value = "LIBERTY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Pringle Parkade", Value = "PRINGLE PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Riverfront Lot", Value = "RIVERFRONT LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Union Lot", Value = "UNION LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Library Parkade", Value = "LIBRARY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Civic Center", Value = "CIVIC CENTER" });

            ViewBag.ParkedLocation = ParkedLocation;

            List<SelectListItem> paymentType = new List<SelectListItem>();

            paymentType.Add(new SelectListItem { Text = "", Value = "" });
            paymentType.Add(new SelectListItem { Text = "Cash Key", Value = "Key" });
            paymentType.Add(new SelectListItem { Text = "Coin", Value = "Coin" });
            paymentType.Add(new SelectListItem { Text = "Credit Card", Value = "Credit" });

            ViewBag.PaymentType = paymentType;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Create([Bind("ComplaintID,ComplaintDateTime,FirstName,LastName,EmailAddress,EmailFlag,Phone,ComplaintType,VehicleModel,VehicleMake,VehicleColor,VehiclePlate,VehicleLocation,CitationNumber,MeterID,MeterStreet,PaymentType,PaymentLastFour,PaymentAmount,ComplaintDetails,ComplaintStatus,EmployeeID,Response,AddressLine1,AddressLine2,City,State,Zip,PermitNumber,ParkedLocation")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                _context.Complaints.Add(complaint);
                _context.SaveChanges();
                sendEmail(complaint.ComplaintDetails);
                return RedirectToAction("Index");
            }

            ViewBag.ComplaintType = new SelectList(_context.ComplaintTypes, "ComplaintType1", "ComplaintTypeDescription", complaint.ComplaintType);

            return View(complaint);
        }
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int? id)
        {
            var complaintTypes = _context.ComplaintTypes.ToList();
            var employees = _context.Employees.Where(e => e.Active != 0).ToList();
            Complaint complaint = _context.Complaints.Find(id);
            

            List<SelectListItem> ParkedLocation = new List<SelectListItem>();

            ParkedLocation.Add(new SelectListItem { Text = "Select", Value = "" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-1", Value = "RP-1" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-2", Value = "RP-2" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-5", Value = "RP-5" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-7", Value = "RP-7" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-10", Value = "RP-10" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-12", Value = "RP-12" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-25", Value = "RP-25" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-90", Value = "RP-90" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-W-1", Value = "RP-W-1" });
            ParkedLocation.Add(new SelectListItem { Text = "Chemekata Parkade", Value = "CHEMEKATA PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Marion Parkade", Value = "MARION PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Liberty Parkade", Value = "LIBERTY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Pringle Parkade", Value = "PRINGLE PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Riverfront Lot", Value = "RIVERFRONT LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Union Lot", Value = "UNION LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Library Parkade", Value = "LIBRARY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Civic Center", Value = "CIVIC CENTER" });

            ViewBag.ParkedLocation = ParkedLocation;

            List<SelectListItem> paymentType = new List<SelectListItem>();
            
            paymentType.Add(new SelectListItem { Text = "", Value = "" });
            paymentType.Add(new SelectListItem { Text = "Cash Key", Value = "Key" });
            paymentType.Add(new SelectListItem { Text = "Coin", Value = "Coin" });
            paymentType.Add(new SelectListItem { Text = "Credit Card", Value = "Credit" });

            ViewBag.PaymentType = paymentType;

            ViewBag.ComplaintType = new SelectList(complaintTypes, "ComplaintType1", "ComplaintTypeDescription", complaint.ComplaintType);
            List<string> selectedEmployees = new List<string>();
            foreach (var e in employees)
            {
                selectedEmployees.Add(e.UserName);
            }

            ViewBag.EmployeeDD = selectedEmployees;
            
            ViewBag.ComplaintID = id;

            return View(complaint);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ComplaintId,ComplaintDateTime,FirstName,LastName,EmailAddress,EmailFlag,Phone,ComplaintType,VehicleModel,VehicleMake,VehicleColor,VehiclePlate,VehicleLocation,CitationNumber,MeterID,MeterStreet,PaymentType,PaymentLastFour,PaymentAmount,ComplaintDetails,ComplaintStatus,EmployeeID,Response,AddressLine1,AddressLine2,City,State,Zip,PermitNumber,ComplaintTypeNavigation,ParkedLocation")] Complaint complaint, string EmployeeUserName)
    
        {
            var employees = _context.Employees.Where(e => e.Active != 0).ToList();
            foreach (var e in _context.Employees.ToList())
            {
                if (e.UserName == EmployeeUserName)
                {
                    complaint.Employee = e;
                    complaint.EmployeeId = e.EmployeeId;
                }
            }
           
            foreach (var ct in _context.ComplaintTypes.ToList())
            {
                if(complaint.ComplaintTypeNavigation.ComplaintTypeDescription == ct.ComplaintTypeDescription)
                {
                    complaint.ComplaintType = ct.ComplaintType1;
                }
            }

            List<SelectListItem> ParkedLocation = new List<SelectListItem>();

            ParkedLocation.Add(new SelectListItem { Text = "Select", Value = "" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-1", Value = "RP-1" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-2", Value = "RP-2" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-5", Value = "RP-5" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-7", Value = "RP-7" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-10", Value = "RP-10" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-12", Value = "RP-12" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-25", Value = "RP-25" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-90", Value = "RP-90" });
            ParkedLocation.Add(new SelectListItem { Text = "RP-W-1", Value = "RP-W-1" });
            ParkedLocation.Add(new SelectListItem { Text = "Chemekata Parkade", Value = "CHEMEKATA PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Marion Parkade", Value = "MARION PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Liberty Parkade", Value = "LIBERTY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Pringle Parkade", Value = "PRINGLE PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Riverfront Lot", Value = "RIVERFRONT LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Union Lot", Value = "UNION LOT" });
            ParkedLocation.Add(new SelectListItem { Text = "Library Parkade", Value = "LIBRARY PARKADE" });
            ParkedLocation.Add(new SelectListItem { Text = "Civic Center", Value = "CIVIC CENTER" });

            ViewBag.ParkedLocation = ParkedLocation;

            List<SelectListItem> paymentType = new List<SelectListItem>();

            paymentType.Add(new SelectListItem { Text = "", Value = "" });
            paymentType.Add(new SelectListItem { Text = "Cash Key", Value = "Key" });
            paymentType.Add(new SelectListItem { Text = "Coin", Value = "Coin" });
            paymentType.Add(new SelectListItem { Text = "Credit Card", Value = "Credit" });

            ViewBag.PaymentType = paymentType;

            ViewBag.ComplaintType = new SelectList(_context.ComplaintTypes, "ComplaintType1", "ComplaintTypeDescription", complaint.ComplaintType);

            //dropdown for employee
            ViewBag.EmployeeDD = new SelectList(_context.Employees.OrderBy(x => x.UserName), "EmployeeID", "UserName", complaint.EmployeeId);



            if (ModelState.IsValid)
            {
                _context.Entry(complaint).State = EntityState.Modified;
                TempData["complaintID"] = complaint.ComplaintId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

   var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(complaint);
        }
        public IActionResult Delete(int? id)
        {

            Complaint complaint = _context.Complaints.Find(id);
            
            return View(complaint);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = _context.Complaints.Find(id);
            _context.Complaints.Remove(complaint);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private static void sendEmail(string complaintDetails)
        {
            var _config = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("ismtp.cityofsalem.net");
            MailMessage message = new MailMessage();
            if (_config == "Development")
            {
                //For testing purposes message.To.Add("kcardoza@cityofsalem.net");
                message.To.Add("AppAdmin@cityofsalem.net");
            }
            if (_config == "Production")
            {
                message.To.Add("parkingservices@cityofsalem.net");
            }
            message.From = new MailAddress("NoReply@cityofsalem.net");
            message.Subject = "New Parking Complaint";
            message.Body = "There is a new parking complaint with the following details:\r\n\r\n " + complaintDetails + " \r\n\r\nPlease view it at this site https://cityweb.cityofsalem.net/ParkingServices/";
            client.Send(message);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
