using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKepper.Data;
using TimeKepper.ViewModels;

namespace TimeKepper.Controllers
{
    public class StoreManagemantController : Controller

    {
        private TimeKeeperContext db = new TimeKeeperContext();
    // GET: StoreManagemant
    public ActionResult Index()
        {
            var Results = from A in db.Stores
                          join B in db.Employees
                          on A.EmployeeId equals B.Id
                          select new StoreManagementViewModel
                          {
                              Name = A.Name,
                              Description = A.Description,
                              FirstName = B.FirstName,
                              LastName = B.LastName

                          };
            return View(Results);
        }
    }
}