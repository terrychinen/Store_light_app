using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccess.Api;
using Domain.Models;
using Domain.Models.Responses;


namespace Domain.Controllers
{
    public class ProviderController
    {
        public async Task<Dictionary<string, dynamic>> GetProviders(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            ProviderAPI providerAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                providerAPI = new ProviderAPI();
                Dictionary<string, dynamic> response = await providerAPI.GetProviders(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        ProviderResponse providerListResponse = JsonConvert.DeserializeObject<ProviderResponse>(response["result"].Content);
                        data.Add("result", providerListResponse);
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
