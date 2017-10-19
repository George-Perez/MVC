using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeKepper.Data;
using TimeKepper.Models;
using PagedList;

namespace TimeKepper.Controllers
{
    public class EmployeesController : Controller
    {
        private TimeKeeperContext db = new TimeKeeperContext();

        // GET: Employees
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            //We are sorting to sortOrder so the view can store temporarely (The most Current)
        ViewBag.CurrentSort = sortOrder;

            /*Checking to see if the search string id null
             *If not , then we reset the page back to one.
             */
        
            if (searchString != null)
            {
                page = 1;
            }

             else
	        {
                //If the search string is null, then we reasign the previous value to searchString.
                searchString = currentFilter;
	        }
            
            //We assign the value of the searchString to a viewbag to store the view
            ViewBag.CurrentFilter = searchString;


            //We need to cast it as IQueryable to be able to filter the values.
            var Results = (IQueryable<Employee>)db.Employees;

            //Checking to see what the sort catagory we are going to choose from
            switch (sortOrder)
            {
                case "FirstName":
                    Results = Results.OrderByDescending(x => x.FirstName);
                    break;
                case "LastName":
                    Results = Results.OrderByDescending(x => x.LastName);
                    break;
                default:
                    Results = Results.OrderBy(x => x.Id);
                    break;
            }

            //if the user types anything in the search box, search the database.
            if (!String.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(x => x.FirstName.Contains(searchString) 
                || x.LastName.Contains(searchString)
                || x.Nickname.Contains(searchString));
            }

            //Defining the initial values of our pagedList
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Passing the filters and Model back to the view
            return View(Results.ToPagedList(pageNumber, pageSize));

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Birthdate,Nickname,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Birthdate,Nickname,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
