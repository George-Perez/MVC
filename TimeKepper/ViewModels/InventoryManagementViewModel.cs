using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeKepper.ViewModels
{
    public class InventoryManagementViewModel
    {
        public string  ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemUPC { get; set; }
        public int ItemStockAmount { get; set; }
        public string StoreName { get; set; }
    }
}