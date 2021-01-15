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


        public async Task<Dictionary<string, dynamic>> CreateEnvironment(EnvironmentModel environment, string token)
        {
            Dictionary<string, dynamic> data;
            EnvironmentAPI environmentAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                environmentAPI = new EnvironmentAPI();
                Dictionary<string, dynamic> response = await environmentAPI.CreateEnvironment(environment.Name, environment.State, token);

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


        public async Task<Dictionary<string, dynamic>> UpdateEnvironment(EnvironmentModel environment, string token)
        {
            Dictionary<string, dynamic> data;
            EnvironmentAPI environmentAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                environmentAPI = new EnvironmentAPI();
                Dictionary<string, dynamic> response = await environmentAPI.UpdateEnvironment(environment.EnvironmentId, environment.Name, environment.State, token);

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


        public List<EnvironmentModel> SearchEnvironments(List<EnvironmentModel> environmentList, string search, int radioActive)
        {
            List<EnvironmentModel> environmentListFiltered = new List<EnvironmentModel>();

            for (int i = 0; i < environmentList.Count(); i++)
            {
                if (radioActive == 1)
                {
                    if (environmentList[i].Name.ToLower().Contains(search.ToLower()))
                    {
                        environmentListFiltered.Add(environmentList[i]);
                    }
                }
                else if (radioActive == 0)
                {
                    if (environmentList[i].EnvironmentId.ToString().Contains(search))
                    {
                        environmentListFiltered.Add(environmentList[i]);
                    }
                }

            }

            return environmentListFiltered;
        }
    }
}
