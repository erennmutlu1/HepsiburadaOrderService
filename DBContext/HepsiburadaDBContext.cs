using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiburadaOrderService.Models.HepsiburadaModels;

namespace HepsiburadaOrderService.DBContext
{
    class HepsiburadaDBContext:DbContext
    {
        public DbSet<HepsiburadaOrdersModel> HepsiburadaOrders { get; set; }
        public DbSet<HepsiburadaItemModel>HepsiburadaItems { get; set; }
        public DbSet<HepsiburadaCommissionModel> HepsiburadaCommissions { get; set; }
        public DbSet<HepsiburadaMerchantTotalPriceModel> HepsiburadaMerchantTotalPrices { get; set; }
        public DbSet<HepsiburadaMerchantUnitPriceModel> HepsiburadaMerchantUnitPrices { get; set; }
        public DbSet<HepsiburadaPriceModel> HepsiburadaPrices { get; set; }
        public DbSet<HepsiburadaTotalHBDiscountModel> HepsiburadaTotalHBDiscounts { get; set; }
        public DbSet<HepsiburadaTotalPriceModel> HepsiburadaTotalPrices { get; set; }
        public DbSet<HepsiburadaUnitHBDiscountModel> HepsiburadaUnitHBDiscounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HepsiburadaOrderDatabase;Integrated Security=True");
        }

    }
}
