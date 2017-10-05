using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeKepper.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Description { get; set; }
        public int UPCNumber { get; set; }
        public int Weight { get; set; }
        public int AmountOnHand { get; set; }
        public bool IsActive { get; set; }

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Stores { get; set; }

    }
}