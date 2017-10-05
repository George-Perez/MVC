using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKepper.Data;
using TimeKepper.ViewModels;

namespace TimeKepper.Controllers
{
    public class IventoryManagementController : Controller
    {
        private TimeKeeperContext db = new TimeKeeperContext();
        // GET: IventoryManagement
        public ActionResult Index()
        {
            var InventoryResult = from A in db.Inventories
                                  join B in db.Stores
                                  on A.StoreId equals B.Id
                                  select new InventoryManagementViewModel
                                  {
                                      ItemName = A.Name,
                                      ItemDescription = A.Description,
                                      ItemUPC = A.UPCNumber,
                                      ItemStockAmount = A.AmountOnHand,
                                      StoreName = B.Name

                                  };


            return View(InventoryResult);
        }
    }
}