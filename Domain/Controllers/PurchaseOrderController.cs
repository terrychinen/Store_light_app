using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Api;
using Domain.Models;
using Domain.Models.Responses;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

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

        

        public async Task<Dictionary<string, dynamic>> CreatePurchaseOrder(PurchaseOrder purchaseOrder, List<CommodityModel> commodityList, string token)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();

                string purchaseData = $"provider_id={purchaseOrder.ProviderId}&employee_id={purchaseOrder.EmployeeId}" +
                    $"&order_date={purchaseOrder.OrderDate}&expected_date={purchaseOrder.ExpectedDate}&receive_date={purchaseOrder.ReceiveDate}&paid_date={purchaseOrder.PaidDate}" +
                    $"&total_price={purchaseOrder.TotalPrice}&message={purchaseOrder.Message}&state={purchaseOrder.State}&";


                string commodityArray = "";
                for (int i = 0; i < commodityList.Count; i++)
                {
                    commodityArray += $"commodity_id={commodityList[i].CommodityId}&quantity={commodityList[i].Quantity}" +
                        $"&unit_price={commodityList[i].UnitPrice}&commodity_total_price={commodityList[i].TotalPrice}&";
                }

                commodityArray = commodityArray.Remove(commodityArray.Length - 1);


                string parameter = purchaseData + commodityArray;

                Dictionary<string, dynamic> response = await purchaseOrderAPI.CreatePurchaseOrder(parameter, token);





                //   Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                data.Add("ok",true);
               data.Add("result", "wewe");


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



        public async Task<Dictionary<string, dynamic>> GetPurchaseOrderDetail(int purchaseOrderID, string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();
                Dictionary<string, dynamic> response = await purchaseOrderAPI.GetPurchaseOrderDetail(purchaseOrderID, token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        CommodityResponse purchaseOrderDetailListResponse = JsonConvert.DeserializeObject<CommodityResponse>(response["result"].Content);
                        data.Add("result", purchaseOrderDetailListResponse);
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



        public async Task<Dictionary<string, dynamic>> UpdatePurchaseOrder(PurchaseOrder purchaseOrder, List<CommodityModel> commodityList, string token)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();

                string purchaseData = $"provider_id={purchaseOrder.ProviderId}&order_date={purchaseOrder.OrderDate}" +
                $"&expected_date={purchaseOrder.ExpectedDate}&receive_date={purchaseOrder.ReceiveDate}&paid_date={purchaseOrder.PaidDate}&total_price={purchaseOrder.TotalPrice}" +
                $"&message={purchaseOrder.Message}&updated_by={purchaseOrder.UpdatedBy}&state={purchaseOrder.State}&";

                if(commodityList.Count == 0)
                {
                    purchaseData = purchaseData.Remove(purchaseData.Length - 1);
                }


                string commodityArray = "";
                for (int i = 0; i < commodityList.Count; i++)
                {
                    commodityArray += $"commodity_id={commodityList[i].CommodityId}&quantity={commodityList[i].Quantity}" +
                        $"&unit_price={commodityList[i].UnitPrice}&commodity_total_price={commodityList[i].TotalPrice}&state_active={commodityList[i].StatePurchaseOrderDetail}&";
                }


                commodityArray = commodityArray.Remove(commodityArray.Length - 1);
                string parameter = purchaseData + commodityArray;


                Dictionary<string, dynamic> response = await purchaseOrderAPI.UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId, parameter, token);

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



        public async Task<Dictionary<string, dynamic>> GetPurchaseOrderWithState(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            PurchaseOrderAPI purchaseOrderAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                purchaseOrderAPI = new PurchaseOrderAPI();
                Dictionary<string, dynamic> response = await purchaseOrderAPI.GetPurchaseOrdersWithState(token, offset, state);

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
