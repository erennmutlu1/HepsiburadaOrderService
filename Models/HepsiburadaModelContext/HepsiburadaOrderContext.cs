using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiburadaOrderService.Context;



namespace HepsiburadaOrderService.Models.HepsiburadaContext
{
    public class HepsiburadaResponse
    {
        public List<HepsiburadaOrderContext> data { get; set; }
    }
    public class HepsiburadaOrderContext
    {
        [Key]
        public long Id1 { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string customerId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime dueDate { get; set; }
        public string barcode { get; set; }
        public string packageNumber { get; set; }
        public string cargoCompany { get; set; }
        public string shippingAddressDetail { get; set; }
        public string recipientName { get; set; }
        public string shippingCountryCode { get; set; }
        public string shippingDistrict { get; set; }
        public string shippingTown { get; set; }
        public string shippingCity { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string companyName { get; set; }
        public string billingAddress { get; set; }
        public string billingCity { get; set; }
        public string billingTown { get; set; }
        public string billingDistrict { get; set; }
        public string taxOffice { get; set; }
        public string taxNumber { get; set; }
        public string identityNo { get; set; }
        public string shippingTotalPrice { get; set; }
        public string customsTotalPrice { get; set; }
        public TotalPrice totalPrice { get; set; }
        public List<Item> items { get; set; }
      




    }
}
