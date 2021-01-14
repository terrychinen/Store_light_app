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
    public class StoreController
    {
        public async Task<Dictionary<string, dynamic>> getStores(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            StoreAPI storeAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                storeAPI = new StoreAPI();
                Dictionary<string, dynamic> response = await storeAPI.GetStores(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        StoreResponse storeListResponse = JsonConvert.DeserializeObject<StoreResponse>(response["result"].Content);
                        data.Add("result", storeListResponse);
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
    }
}
