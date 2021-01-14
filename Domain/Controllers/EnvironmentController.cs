using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Api;
using Domain.Models.Responses;
using Domain.Models;
using Newtonsoft.Json;

namespace Domain.Controllers
{
    public class EnvironmentController
    {
        public async Task<Dictionary<string, dynamic>> GetEnviroments(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            EnvironmentAPI environmentAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                environmentAPI = new EnvironmentAPI();
                Dictionary<string, dynamic> response = await environmentAPI.GetEnvironments(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        EnvironmentResponse environmentListResponse = JsonConvert.DeserializeObject<EnvironmentResponse>(response["result"].Content);
                        data.Add("result", environmentListResponse);
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
