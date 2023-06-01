using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Payment;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.Order;
using SeaBreeze.Service.Interfaces;
using System.Net.Http.Headers;

namespace SeaBreeze.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;


        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PayriffOrder> CreateOrder(AppUser user, OrderDto orderDto, decimal amount)
        {

            Body body = new Body()
            {
                amount = amount,
                approveURL = "/payment/success.html",
                cancelURL = "/payment/cancel.html",
                cardUuid = "string",
                currencyType = "AZN",
                declineURL = "/payment/decline.html",
                description = $"{user.FullName} adlı istifadəçi {orderDto.Count} bilet sifariş etdi. Nömrə: {user.PhoneNumber} Tarix: {orderDto.OrderDate}, Rosebar: {orderDto.IsRosebar}, Məbləğ: {amount}",
                directPay = true,
                installmentPeriod = 0,
                installmentProductType = "BIRKART",
                language = "AZ",
                senderCardUID = "string"
            };

            Payment payment = new Payment()
            {
                body = body,
                merchant = "ES1091906"
            };






            // create a new HttpClient instance
            HttpClient client = new HttpClient();

            var url = "https://api.payriff.com/api/v2/createOrder";


            // create the request message
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);


            // serialize the payment object to JSON
            string paymentJson = JsonConvert.SerializeObject(payment);
            request.Content = new StringContent(paymentJson, System.Text.Encoding.UTF8, "application/json");


            // set the Content-Type header
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // set the Authorization header with the secret key
            request.Headers.Add("authorization", "E4B62EE091D04F4B8ABB871B5A0AE2FB");




            // send the request and get the response
            HttpResponseMessage response = await client.SendAsync(request);


            string responseBody = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(responseBody);


            PayriffOrder payriffOrder = new PayriffOrder()
            {
                orderId = root.payload.orderId,
                sessionId = root.payload.sessionId,
                paymentUrl = root.payload.paymentUrl,
                transactionId = root.payload.transactionId,
                totalAmount = amount,
                status = "CREATED"
            };

            await _context.PayriffOrders.AddAsync(payriffOrder);
            await _context.SaveChangesAsync();

            return payriffOrder;

        }





        public async Task<PayriffOrder> CreatePremiumOrder(AppUser user, PremiumOrderDto orderDto, decimal amount)
        {

            Body body = new Body()
            {
                amount = amount,
                approveURL = "/payment/success.html",
                cancelURL = "/payment/cancel.html",
                cardUuid = "string",
                currencyType = "AZN",
                declineURL = "/payment/decline.html",
                description = $"{user.FullName} adlı istifadəçi premium bilet sifariş etdi. FİN: {orderDto.Fin}, Nömrə: {user.PhoneNumber} , Məbləğ: {amount}",
                directPay = true,
                installmentPeriod = 0,
                installmentProductType = "BIRKART",
                language = "AZ",
                senderCardUID = "string"
            };

            Payment payment = new Payment()
            {
                body = body,
                merchant = "ES1091906"
            };






            // create a new HttpClient instance
            HttpClient client = new HttpClient();

            var url = "https://api.payriff.com/api/v2/createOrder";


            // create the request message
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);


            // serialize the payment object to JSON
            string paymentJson = JsonConvert.SerializeObject(payment);
            request.Content = new StringContent(paymentJson, System.Text.Encoding.UTF8, "application/json");


            // set the Content-Type header
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // set the Authorization header with the secret key
            request.Headers.Add("authorization", "E4B62EE091D04F4B8ABB871B5A0AE2FB");




            // send the request and get the response
            HttpResponseMessage response = await client.SendAsync(request);


            string responseBody = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(responseBody);


            PayriffOrder payriffOrder = new PayriffOrder()
            {
                orderId = root.payload.orderId,
                sessionId = root.payload.sessionId,
                paymentUrl = root.payload.paymentUrl,
                transactionId = root.payload.transactionId,
                totalAmount = amount,
                status = "CREATED"

            };

            await _context.PayriffOrders.AddAsync(payriffOrder);
            await _context.SaveChangesAsync();

            return payriffOrder;

        }



        public async Task<string> CheckOrderStatus(CheckOrderDto checkOrderDto)
        {
            CheckOrderBody checkOrderBody = new CheckOrderBody()
            {
                language = "AZ",
                orderId = checkOrderDto.OrderId,
                sessionId = checkOrderDto.SessionId
            };


            CheckOrderRoot checkOrderRoot = new CheckOrderRoot
            {
                body = checkOrderBody,
                merchant = "ES1091906"
            };


            // create a new HttpClient instance
            HttpClient client = new HttpClient();

            var url = "https://api.payriff.com/api/v2/getStatusOrder";


            // create the request message
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);


            // serialize the payment object to JSON
            string paymentJson = JsonConvert.SerializeObject(checkOrderRoot);
            request.Content = new StringContent(paymentJson, System.Text.Encoding.UTF8, "application/json");


            // set the Content-Type header
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // set the Authorization header with the secret key
            request.Headers.Add("authorization", "E4B62EE091D04F4B8ABB871B5A0AE2FB");

            // send the request and get the response
            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            CheckOrderResponseRoot root = JsonConvert.DeserializeObject<CheckOrderResponseRoot>(responseBody);


            var payrifforder = await _context.PayriffOrders
                                      .Where(po => po.sessionId == checkOrderDto.SessionId && po.orderId == checkOrderDto.OrderId)
                                      .FirstOrDefaultAsync();

            payrifforder.status = root.payload.orderStatus;

            _context.PayriffOrders.Update(payrifforder);
            await _context.SaveChangesAsync();


            //var ticketOrder = await _context.BeachClubOrders
            //    .Where(bco => bco.PayriffOrder.sessionId == checkOrderDto.SessionId && bco.PayriffOrder.orderId == checkOrderDto.OrderId)
            //    .Include(bco => bco.PayriffOrder)
            //    .FirstOrDefaultAsync();



            return root.payload.orderStatus;

        }


        public class Body
        {
            public decimal amount { get; set; }
            public string approveURL { get; set; }
            public string cancelURL { get; set; }
            public string cardUuid { get; set; }
            public string currencyType { get; set; }
            public string declineURL { get; set; }
            public string description { get; set; }
            public bool directPay { get; set; }
            public int installmentPeriod { get; set; }
            public string installmentProductType { get; set; }
            public string language { get; set; }
            public string senderCardUID { get; set; }
        }

        public class Payment
        {
            public Body body { get; set; }
            public string merchant { get; set; }
        }

        public class Payload
        {
            public string orderId { get; set; }
            public string sessionId { get; set; }
            public string paymentUrl { get; set; }
            public int transactionId { get; set; }
        }



        public class Root
        {
            public string code { get; set; }
            public string message { get; set; }
            public string route { get; set; }
            public object internalMessage { get; set; }
            public Payload payload { get; set; }
        }



        public class CheckOrderBody
        {
            public string language { get; set; }
            public string orderId { get; set; }
            public string sessionId { get; set; }
        }

        public class CheckOrderRoot
        {
            public CheckOrderBody body { get; set; }
            public string merchant { get; set; }
        }

        public class CheckOrderDto
        {
            public string OrderId { get; set; }
            public string SessionId { get; set; }
        }


        public class CheckOrderResponsePayload
        {
            public string orderId { get; set; }
            public string orderStatus { get; set; }
            public object paymentUrl { get; set; }
            public string responseDescription { get; set; }
        }

        public class CheckOrderResponseRoot
        {
            public string code { get; set; }
            public string message { get; set; }
            public string route { get; set; }
            public object internalMessage { get; set; }
            public CheckOrderResponsePayload payload { get; set; }
        }


    }
}