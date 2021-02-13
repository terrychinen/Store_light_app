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
    public class InputController
    {
        public Dictionary<string, dynamic> GetInputs(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            InputAPI inputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                inputAPI = new InputAPI();
                Dictionary<string, dynamic> response = inputAPI.GetInputs(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        InputResponse inputListResponse = JsonConvert.DeserializeObject<InputResponse>(response["result"].Content);
                        data.Add("result", inputListResponse);
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
