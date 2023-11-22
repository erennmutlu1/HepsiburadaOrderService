using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HepsiburadaOrderService.Context;
using HepsiburadaOrderService.DBContext;
using HepsiburadaOrderService.Models.HepsiburadaContext;
using HepsiburadaOrderService.Models.HepsiburadaModels;
using HepsiburadaOrderService.Utils;


namespace HepsiburadaOrderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {   
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);                   
                
                string apiUsername = "";
                string apiPassword = "";
                string merchantId = "";
                string token = TokenManager.GetToken($"{apiUsername}:{apiPassword}");
                var client = new RestClient("https://oms-external.hepsiburada.com/packages/merchantid/"+merchantId+"?timespan=96");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Basic {token}");
                request.AddParameter("text/plain", "", ParameterType.RequestBody);                
                IRestResponse response = client.Execute(request);
             
                var deserializedHepsiburadaResponse = JsonConvert.DeserializeObject<List<HepsiburadaOrderContext>>(response.Content);

                //try
                //{}
                using (var dbContext = new HepsiburadaDBContext())
                {                      
                    foreach (HepsiburadaOrderContext content in deserializedHepsiburadaResponse)
                    {
                        if (!dbContext.HepsiburadaOrders.Any(a => a.customerId == content.customerId))
                        {
                            var merchantTotalPrice = new HepsiburadaMerchantTotalPriceModel
                            {
                                currency = content.items[0].merchantTotalPrice.currency,
                                amount = content.items[0].merchantTotalPrice.amount,
                            };
                            dbContext.Add(merchantTotalPrice);
                            _ = dbContext.SaveChanges();

                            long merchantTotalPriceId = merchantTotalPrice.Id;

                            var commission = new HepsiburadaCommissionModel
                            {
                                currency = content.items[0].commission.currency,
                                amount = content.items[0].commission.amount
                            };

                                dbContext.Add(commission);
                            _ = dbContext.SaveChanges();
                            long commissionId = commission.Id;                             

                            var merchantUnitPrice = new HepsiburadaMerchantUnitPriceModel
                            {
                                currency = content.items[0].merchantUnitPrice.currency,
                                amount = content.items[0].merchantUnitPrice.amount
                            };

                            dbContext.Add(merchantUnitPrice);
                            _ = dbContext.SaveChanges();
                            long merchantUnitPriceId = merchantUnitPrice.Id;

                            var price = new HepsiburadaPriceModel
                            {
                                currency = content.items[0].price.currency,
                                amount = content.items[0].price.amount
                            };

                            dbContext.Add(price);
                            _ = dbContext.SaveChanges();
                            long priceId = price.Id;

                            var totalHBDiscount = new HepsiburadaTotalHBDiscountModel
                            {
                                currency = content.items[0].totalHBDiscount.currency,
                                amount = content.items[0].totalHBDiscount.amount
                            };

                            dbContext.Add(totalHBDiscount);
                            _ = dbContext.SaveChanges();
                            long totalHBDiscountId = totalHBDiscount.Id;

                            var totalPrice = new HepsiburadaTotalPriceModel
                            {
                                currency = content.items[0].totalPrice.currency,
                                amount = content.items[0].totalPrice.amount
                            };

                            dbContext.Add(totalPrice);
                            _ = dbContext.SaveChanges();                              
                            long totalPriceId = totalPrice.Id;

                            var unitHBDiscount = new HepsiburadaUnitHBDiscountModel
                            {
                                currency = content.items[0].unitHBDiscount.currency,
                                amount = content.items[0].unitHBDiscount.amount
                            };

                            dbContext.Add(unitHBDiscount);
                            _ = dbContext.SaveChanges();
                            long unitHBDiscountId = unitHBDiscount.Id;

                            var items = new HepsiburadaItemModel
                            {
                                lineItemId = content.items[0].lineItemId,
                                merchantId = content.items[0].merchantId,
                                hbSku = content.items[0].hbSku,
                                merchantSku = content.items[0].merchantSku,
                                quantity = content.items[0].quantity,                                  
                                vat=content.items[0].vat,                                   
                                cargoPaymentInfo=content.items[0].cargoPaymentInfo,
                                customizedText01=content.items[0].customizedText01,
                                customizedText02=content.items[0].customizedText02,
                                customizedText03=content.items[0].customizedText03,
                                customizedText04 = content.items[0].customizedText04,
                                productName=content.items[0].productName,
                                orderNumber=content.items[0].orderNumber,
                                orderDate=content.items[0].orderDate,
                                deliveryType=content.items[0].deliveryType,
                                customerDelivery=content.items[0].customerDelivery,
                                pickupTime=content.items[0].pickupTime,
                                gtip=content.items[0].gtip,
                                weight=content.items[0].weight,
                                vatRate=content.items[0].vatRate
                            };

                            dbContext.Add(items);
                            _ = dbContext.SaveChanges();
                            long itemsId = items.Id;

                            var orders = new HepsiburadaOrdersModel
                            {
                                id=content.id,
                                status=content.status,
                                customerId=content.customerId,
                                orderDate=content.orderDate,
                                dueDate=content.dueDate,
                                barcode=content.barcode,
                                packageNumber=content.packageNumber,
                                cargoCompany=content.cargoCompany,
                                shippingAddressDetail=content.shippingAddressDetail,
                                recipientName=content.recipientName,
                                shippingCountryCode=content.shippingCountryCode,
                                shippingDistrict=content.shippingDistrict,
                                shippingTown=content.shippingTown,
                                shippingCity=content.shippingCity,
                                email=content.email,
                                phoneNumber=content.phoneNumber,
                                companyName=content.companyName,
                                billingAddress=content.billingAddress,
                                billingCity=content.billingCity,
                                billingTown=content.billingTown,
                                billingDistrict=content.billingDistrict,
                                taxOffice=content.taxOffice,
                                taxNumber=content.taxNumber,
                                identityNo=content.identityNo,
                                shippingTotalPrice=content.shippingTotalPrice,
                                customsTotalPrice=content.customsTotalPrice,
                            };

                            dbContext.Add(orders);
                            _ = dbContext.SaveChanges();
                            long ordersId = orders.Id1;
                        }
                    }
                }
                //catch (Exception ex)
                //{

                //    throw;
                //}
                _logger.LogInformation(response.Content);
                Console.WriteLine(response.Content);
                await Task.Delay(10 * 1000, stoppingToken);
            }
        }
    }
}
