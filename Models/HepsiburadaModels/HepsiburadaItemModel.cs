using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaOrderService.Models.HepsiburadaModels
{
    public class HepsiburadaItemModel
    {
        [Key]
        public long Id { get; set; }
        public string lineItemId { get; set; }
        public string merchantId { get; set; }
        public string hbSku { get; set; }
        public string merchantSku { get; set; }
        public long quantity { get; set; }
        public double vat { get; set; }
        public string cargoPaymentInfo { get; set; }
        public string customizedText01 { get; set; }
        public string customizedText02 { get; set; }
        public string customizedText03 { get; set; }
        public string customizedText04 { get; set; }
        public long properties { get; set; }
        public string productName { get; set; }
        public string orderNumber { get; set; }
        public DateTime orderDate { get; set; }
        public string deliveryType { get; set; }
        public string customerDelivery { get; set; }
        public string pickupTime { get; set; }
        public string gtip { get; set; }
        public double weight { get; set; }
        public long vatRate { get; set; }
    }

    public class Propertiess
    {
        [Key]
        public long Id { get; set; }
    }
}
