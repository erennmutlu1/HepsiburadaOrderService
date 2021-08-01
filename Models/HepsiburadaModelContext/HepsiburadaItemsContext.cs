using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiburadaOrderService.Context;

namespace HepsiburadaOrderService.Models.HepsiburadaContext
{
   public class HepsiburadaItemsContext
    {
        [Key]
        public long Id { get; set; }
        public string lineItemId { get; set; }
        public string listingId { get; set; }
        public string merchantId { get; set; }
        public string hbSku { get; set; }
        public string merchantSku { get; set; }
        public int quantity { get; set; }
        public Price price { get; set; }
        public double vat { get; set; }
        public TotalPrice totalPrice { get; set; }
        public Commission commission { get; set; }
        public UnitHBDiscount unitHBDiscount { get; set; }
        public TotalHBDiscount totalHBDiscount { get; set; }
        public MerchantUnitPrice merchantUnitPrice { get; set; }
        public MerchantTotalPrice merchantTotalPrice { get; set; }
        public string cargoPaymentInfo { get; set; }
        public string customizedText01 { get; set; }
        public string customizedText02 { get; set; }
        public string customizedText03 { get; set; }
        public string customizedText04 { get; set; }
        public List<object> properties { get; set; }
        public string productName { get; set; }
        public string orderNumber { get; set; }
        public DateTime orderDate { get; set; }
        public string deliveryType { get; set; }
        public string customerDelivery { get; set; }
        public object pickupTime { get; set; }
        public string gtip { get; set; }
        public double weight { get; set; }
        public int vatRate { get; set; }
    }
}
