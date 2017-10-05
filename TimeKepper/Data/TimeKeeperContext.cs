using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TimeKepper.Models;

namespace TimeKepper.Data
{
    public class TimeKeeperContext : DbContext
    {
        public TimeKeeperContext () : base("Defaultconnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Store> Stores { get; set; }

        public System.Data.Entity.DbSet<TimeKepper.Models.Inventory> Inventories { get; set; }
    }
}