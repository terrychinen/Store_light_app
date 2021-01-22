using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Api;
using Domain.Models;
using Domain.Models.Responses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Domain.Controllers
{
    public class PurchaseOrderController
    {

        public async Task<Dictionary<string, dynamic>> GetPurchaseOrder(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();
                Dictionary<string, dynamic> response = await purchaseOrderAPI.GetPurchaseOrders(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        PurchaseOrderResponse purchaseOrderListResponse = JsonConvert.DeserializeObject<PurchaseOrderResponse>(response["result"].Content);
                        data.Add("result", purchaseOrderListResponse);
                    }
                    else
                    {
                        data.Add("result", dataResponse.Message);
                    }

                    return data;
                }

                return response;

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


        public async Task<Dictionary<string, dynamic>> CreatePurchaseOrder(PurchaseOrder purchaseOrder, string token)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();
                Dictionary<string, dynamic> response = await purchaseOrderAPI.CreatePurchaseOrder(purchaseOrder.ProviderId,
                    purchaseOrder.EmployeeId, purchaseOrder.OrderDate, purchaseOrder.ExpectedDate, purchaseOrder.ReceiveDate, purchaseOrder.TotalPrice,
                    purchaseOrder.State, token);

                Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                data.Add("ok", dataResponse.Ok);
                data.Add("result", dataResponse.Message);

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


        public async Task<Dictionary<string, dynamic>> UpdatePurchaseOrder(PurchaseOrder purchaseOrder, string token)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();
                Dictionary<string, dynamic> response = await purchaseOrderAPI.UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId, 
                    purchaseOrder.ProviderId, purchaseOrder.EmployeeId, purchaseOrder.OrderDate, purchaseOrder.ExpectedDate, 
                    purchaseOrder.ReceiveDate, purchaseOrder.TotalPrice, purchaseOrder.State, token);

                Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                data.Add("ok", dataResponse.Ok);
                data.Add("result", dataResponse.Message);

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


        public List<PurchaseOrder> SearchPurchaseOrder(PurchaseOrder purchaseOrdersList, string search, int radioActive)
        {
            List<PurchaseOrder> purchaseOrdersListFiltered = new List<PurchaseOrder>();

            if (radioActive == 0)
            {
                if (purchaseOrdersList.PurchaseOrderId.ToString() == search)
                {
                    purchaseOrdersListFiltered.Add(purchaseOrdersList);
                }
            } else if (radioActive == 0)
            {
                if (purchaseOrdersList.PurchaseOrderId.ToString().Contains(search))
                {
                    purchaseOrdersListFiltered.Add(purchaseOrdersList);
                }
            }
            return purchaseOrdersListFiltered;
        }
    }
}
