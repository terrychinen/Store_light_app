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
    public class CategoryController
    {
        public async Task<Dictionary<string, dynamic>> GetCategories(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            CategoryAPI categoryAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                categoryAPI = new CategoryAPI();
                Dictionary<string, dynamic> response = await categoryAPI.GetCategories(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        CategoryResponse categoryListResponse = JsonConvert.DeserializeObject<CategoryResponse>(response["result"].Content);
                        data.Add("result", categoryListResponse);
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

        public async Task<Dictionary<string, dynamic>> CreateCategory(string categoryName, int state, string token)
        {
            Dictionary<string, dynamic> data;
            CategoryAPI categoryAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                categoryAPI = new CategoryAPI();
                Dictionary<string, dynamic> response = await categoryAPI.CreateCategory(categoryName, state, token);
                
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
