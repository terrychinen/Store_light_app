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


        public async Task<Dictionary<string, dynamic>> CreateInput(InputModel input, List<StoreCommodityModel> storeCommodityList, string token)
        {
            Dictionary<string, dynamic> data;
            InputAPI inputAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                inputAPI = new InputAPI();


                string inputData = "{" +
                        $"\"purchase_order_id\": {input.PurchaseOrderID}, \"employee_id\": {input.EmployeeId}, \"input_date\": \"{input.InputDate}\", " +
                        $"\"notes\": \"{input.Notes}\", \"state\": \"{input.State}\", \"detail\": [";


                string storeCommodityArray = "";
                for (int i = 0; i < storeCommodityList.Count; i++)
                {
                    storeCommodityArray += "{" +
                        $"\"store_id\": {storeCommodityList[i].StoreId}, \"commodity_id\": {storeCommodityList[i].CommodityId}, " +
                        $"\"quantity\": {storeCommodityList[i].Stock}" +
                        "},";
                }

                storeCommodityArray = storeCommodityArray.Remove(storeCommodityArray.Length - 1) + "]}";

                string parameter = inputData + storeCommodityArray;

                Dictionary<string, dynamic> response = await inputAPI.CreateInput(parameter, token);


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
