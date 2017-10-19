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

namespace TimeKepper.Controllers
{
    public class StoresController : Controller
    {
        private TimeKeeperContext db = new TimeKeeperContext();

        // GET: Stores
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Employee);
            return View(stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(x => x.IsActive == true), "Id", "FirstName");
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,name,description,EmployeeId")] Store store)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stores.Add(store);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", store.EmployeeId);
        //    return View(store);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax([Bind(Include = "id,name,description,employeeid")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    SuccessMsg = "Success"

                });
            }
            else
            {
                return this.Json(new
                {
                    EnableError = true,
                    ErrorTitle = "Error",
                    ErrorMsg = "Something goes wrong, please try again later"
                });
            }
            

            ViewBag.employeeid = new SelectList(db.Employees, "id", "firstname", store.EmployeeId);
            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", store.EmployeeId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,description,EmployeeId")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", store.EmployeeId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
