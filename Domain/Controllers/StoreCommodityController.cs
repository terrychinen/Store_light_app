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


        public async Task<Dictionary<string, dynamic>> CreateStoreCommodity(List<StoreCommodityModel> storeCommodityList, string token)
        {
            Dictionary<string, dynamic> data;
            StoreCommodityAPI storeCommodityAPI;

            string storeCommodityString = "";

            for(int i=0; i< storeCommodityList.Count(); i++)
            {
                storeCommodityString += "store_id[" + i + "]=" + storeCommodityList[i] +
                    "&commodity_id[" + i + "]=" + storeCommodityList[i].CommodityId +
                    "&stock[" + i + "]=" + storeCommodityList[i].Stock +
                    "&state[" + i + "]=" + storeCommodityList[i].State +
                    "&";
            }

            storeCommodityString.Remove(storeCommodityString.Length - 1);

            try
            {
                data = new Dictionary<string, dynamic>();
                storeCommodityAPI = new StoreCommodityAPI();
                Dictionary<string, dynamic> response = await storeCommodityAPI.CreateStoreCommodity(storeCommodityString, token);

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


    }
}
