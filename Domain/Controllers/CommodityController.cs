using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Api;
using Domain.Models;
using Domain.Models.Responses;
using Newtonsoft.Json;

namespace Domain.Controllers
{
    public class CommodityController
    {
        public async Task<Dictionary<string, dynamic>> GetCommodities(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            CommodityAPI commodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                commodityAPI = new CommodityAPI();
                Dictionary<string, dynamic> response = await commodityAPI.GetCommodities(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        CommodityResponse commodityListResponse = JsonConvert.DeserializeObject<CommodityResponse>(response["result"].Content);
                        data.Add("result", commodityListResponse);
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


        public async Task<Dictionary<string, dynamic>> CreateCommodity(CommodityModel commodity, string token)
        {
            Dictionary<string, dynamic> data;
            CommodityAPI commodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                commodityAPI = new CommodityAPI();
                Dictionary<string, dynamic> response = await commodityAPI.CreateCommodity(commodity.Name, commodity.CategoryId, commodity.State, token);

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


        public async Task<Dictionary<string, dynamic>> UpdateCommodity(CommodityModel commodity, string token)
        {
            Dictionary<string, dynamic> data;
            CommodityAPI commodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                commodityAPI = new CommodityAPI();
                Dictionary<string, dynamic> response = await commodityAPI.UpdateCommodity(commodity.CommodityId, commodity.CategoryId, commodity.Name, commodity.State, token);

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


        public Dictionary<string, dynamic> SearchCommoditiesAPI(string search, int searchBy, int state, string token)
        {
            Dictionary<string, dynamic> data;
            CommodityAPI commodityAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                commodityAPI = new CommodityAPI();
                Dictionary<string, dynamic> response = commodityAPI.SearchCommodity(search, searchBy, 1, token);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        CommodityResponse commodityListResponse = JsonConvert.DeserializeObject<CommodityResponse>(response["result"].Content);
                        data.Add("result", commodityListResponse);
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





        public List<CommodityModel> SearchCommodities(List<CommodityModel> commodityList, string search, int radioActive)
        {
            List<CommodityModel> commodityListFiltered = new List<CommodityModel>();

            for (int i = 0; i < commodityList.Count(); i++)
            {
                if (radioActive == 1)
                {
                    if (commodityList[i].Name.ToLower().Contains(search.ToLower()))
                    {
                        commodityListFiltered.Add(commodityList[i]);
                    }
                }
                else if (radioActive == 0)
                {
                    if (commodityList[i].CommodityId.ToString().Contains(search))
                    {
                        commodityListFiltered.Add(commodityList[i]);
                    }
                }else if (radioActive == 2) 
                {
                    if (commodityList[i].CategoryName.ToLower().ToString().Contains(search.ToLower()))
                    {
                        commodityListFiltered.Add(commodityList[i]);
                    }
                }

            }

            return commodityListFiltered;
        }

    }
}
