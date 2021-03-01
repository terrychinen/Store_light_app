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
    public class OutputController
    {
        public Dictionary<string, dynamic> GetOutputs(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            OutputAPI outputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                outputAPI = new OutputAPI();
                Dictionary<string, dynamic> response = outputAPI.GetOutputs(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        OutputResponse outputListResponse = JsonConvert.DeserializeObject<OutputResponse>(response["result"].Content);
                        data.Add("result", outputListResponse);
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

        public Dictionary<string, dynamic> CreateOutput(int storeID, int environmentID, int commodityID, double quantity,
            int employeeGivesID, int employeeReceivesID, string dateOutput, string notes, int state, string token)
        {
            Dictionary<string, dynamic> data;
            OutputAPI outputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                outputAPI = new OutputAPI();
                Dictionary<string, dynamic> response = outputAPI.CreateOutput(storeID, environmentID, commodityID, quantity,
                        employeeGivesID, employeeReceivesID, dateOutput, notes, state, token);

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


        public Dictionary<string, dynamic> UpdateOutput(int outputID, int environmentID,
            int employeeGivesID, int employeeReceivesID, string dateOutput, string notes, int state, string token)
        {
            Dictionary<string, dynamic> data;
            OutputAPI outputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                outputAPI = new OutputAPI();
                Dictionary<string, dynamic> response = outputAPI.UpdateOutput(outputID, environmentID, employeeGivesID, employeeReceivesID,
                    dateOutput, notes, state, token);

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


        public Dictionary<string, dynamic> UpdateStock (int outputID, int storeID, int commodityID, double quantity, double leftQuantity, string token)
        {
            Dictionary<string, dynamic> data;
            OutputAPI outputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                outputAPI = new OutputAPI();
                Dictionary<string, dynamic> response = outputAPI.UpdateStock(outputID, storeID, commodityID, quantity, leftQuantity, token);

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


        public Dictionary<string, dynamic> SearchOutputAPI(string search, int searchBy, int state, string token)
        {

            Dictionary<string, dynamic> data;
            OutputAPI outputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                outputAPI = new OutputAPI();
                Dictionary<string, dynamic> response = outputAPI.SearchOutput(search, searchBy, 1, token);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        OutputResponse outputListResponse = JsonConvert.DeserializeObject<OutputResponse>(response["result"].Content);
                        data.Add("result", outputListResponse);
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
