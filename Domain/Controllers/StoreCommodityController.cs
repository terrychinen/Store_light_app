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
    public class StoreCommodityController
    {
        public async Task<Dictionary<string, dynamic>> GetStoresCommodities(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = await storeCommodityAPI.GetStoreCommodity(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        StoreCommodityResponse storeCommodityListResponse = JsonConvert.DeserializeObject<StoreCommodityResponse>(response["result"].Content);
                        data.Add("result", storeCommodityListResponse);
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


        public async Task<Dictionary<string, dynamic>> GetStoresCommoditiesWithStockMin(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = await storeCommodityAPI.GetStoreCommodityWithStockMin(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        StoreCommodityResponse storeCommodityListResponse = JsonConvert.DeserializeObject<StoreCommodityResponse>(response["result"].Content);
                        data.Add("result", storeCommodityListResponse);
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


        public async Task<Dictionary<string, dynamic>> CreateStoreCommodity(StoreCommodityModel storeCommodity, string token)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = await storeCommodityAPI.CreateStoreCommodity(storeCommodity.StoreId, 
                    storeCommodity.CommodityId, storeCommodity.Stock, storeCommodity.StockMin, storeCommodity.State, token);

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


        public async Task<Dictionary<string, dynamic>> UpdateStoreCommodity(StoreCommodityModel storeCommodity, string token)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = await storeCommodityAPI.UpdateStoreCommodity(storeCommodity.StoreId, 
                    storeCommodity.CommodityId, storeCommodity.Stock, storeCommodity.StockMin, storeCommodity.State, token);

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


        public Dictionary<string, dynamic> SearchCommoditiesByStoreID(string search, int storeID, string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = storeCommodityAPI.SearchCommoditiesByStoreId(search, storeID, token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        StoreCommodityResponse storeCommodityListResponse = JsonConvert.DeserializeObject<StoreCommodityResponse>(response["result"].Content);
                        data.Add("result", storeCommodityListResponse);
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



        public Dictionary<string, dynamic> SearchCommoditiesByStoreIDAndCommodityID(int storeID, int commodityID, string token)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = storeCommodityAPI.SearchCommoditiesByStoreIdAndCommodityId(storeID, commodityID, token);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        StoreCommodityResponse storeCommodityListResponse = JsonConvert.DeserializeObject<StoreCommodityResponse>(response["result"].Content);
                        data.Add("result", storeCommodityListResponse);
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



        public List<StoreCommodityModel> SearchStoreCommodity(List<StoreCommodityModel> storeCommodityList, string search, int radioActive)
        {
            List<StoreCommodityModel> storeCommodityListFiltered = new List<StoreCommodityModel>();

            for (int i = 0; i < storeCommodityList.Count(); i++)
            {
                if (radioActive == 1)
                {
                    if (storeCommodityList[i].CommodityName.ToLower().Contains(search.ToLower()))
                    {
                        storeCommodityListFiltered.Add(storeCommodityList[i]);
                    }
                }
                else if (radioActive == 0)
                {
                    if (storeCommodityList[i].CommodityId.ToString().Contains(search))
                    {
                        storeCommodityListFiltered.Add(storeCommodityList[i]);
                    }
                }
                else if (radioActive == 2)
                {
                    if (storeCommodityList[i].StoreName.ToLower().ToString().Contains(search.ToLower()))
                    {
                        storeCommodityListFiltered.Add(storeCommodityList[i]);
                    }
                }

            }

            return storeCommodityListFiltered;
        }
    }
}
