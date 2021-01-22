using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;

namespace DataAccess.Api
{
    public class PurchaseOrderAPI
    {
        public async Task<Dictionary<string, dynamic>> GetPurchaseOrders(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/purchase_order?offset=" + offset;
                var client = new RestClient(url);

                var request = new RestRequest(Method.GET);
                request.AddHeader("token", token);

                IRestResponse response = await client.ExecuteAsync(request);

                data.Add("ok", true);
                data.Add("result", response);

                return data;
            }
            catch (Exception error)
            {
                data = new Dictionary<string, dynamic>
                {
                    { "ok", false },
                    { "result", error }
                };

                return data;
            }
        }



        public async Task<Dictionary<string, dynamic>> CreatePurchaseOrder(int providerID, int emplooyeeID, DateTime orderDate, 
            DateTime expectedDate, DateTime receiveDate, double totalPrice, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/purchase_order";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"provider_id={providerID}&employee_id={emplooyeeID}" +
                    $"&order_date={orderDate}&expected_date={expectedDate}&receive_date={receiveDate}&total_price={totalPrice}" +
                    $"&state={state}", ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteAsync(request);

                data.Add("ok", true);
                data.Add("result", response);

                return data;
            }
            catch (Exception error)
            {
                data = new Dictionary<string, dynamic>
                {
                    { "ok", false },
                    { "result", error }
                };

                return data;
            }
        }



        public async Task<Dictionary<string, dynamic>> UpdatePurchaseOrder(int purchaseOrderID, int providerID, int emplooyeeID, DateTime orderDate,
            DateTime expectedDate, DateTime receiveDate, double totalPrice, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/purchase_order/" + purchaseOrderID;
                var client = new RestClient(url);

                var request = new RestRequest(Method.PUT);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"provider_id={providerID}&employee_id={emplooyeeID}"+
                    $"&expected_date={expectedDate}&receive_date={receiveDate}&total_price={totalPrice}&state={state}", ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteAsync(request);

                data.Add("ok", true);
                data.Add("result", response);

                return data;
            }
            catch (Exception error)
            {
                data = new Dictionary<string, dynamic>
                {
                    { "ok", false },
                    { "result", error }
                };

                return data;
            }
        }
    }
}
