using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaOrderService.Context
{
 
    public class TotalPrice
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Price
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Commission
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public float amount { get; set; }
    }

    public class UnitHBDiscount
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class TotalHBDiscount
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class MerchantUnitPrice
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class MerchantTotalPrice
    {
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Item
    {
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
        public string pickupTime { get; set; }
        public string gtip { get; set; }
        public double weight { get; set; }
        public int vatRate { get; set; }
    }

    public class HepsiburadaOrders
    {
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
        public object shippingTotalPrice { get; set; }
        public object customsTotalPrice { get; set; }
        public TotalPrice totalPrice { get; set; }
        public List<Item> items { get; set; }
    }
}
