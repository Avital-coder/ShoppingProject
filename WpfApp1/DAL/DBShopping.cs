using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DBShopping : DbContext
    {
        public DBShopping() : base("DBShopping") { }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<ShopsDB>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}