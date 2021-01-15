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


        public async Task<Dictionary<string, dynamic>> CreateCategory(CategoryModel category, string token)
        {
            Dictionary<string, dynamic> data;
            CategoryAPI categoryAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                categoryAPI = new CategoryAPI();
                Dictionary<string, dynamic> response = await categoryAPI.CreateCategory(category.Name, category.State, token);
                
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


        public async Task<Dictionary<string, dynamic>> UpdateCategory(CategoryModel category, string token)
        {
            Dictionary<string, dynamic> data;
            CategoryAPI categoryAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                categoryAPI = new CategoryAPI();
                Dictionary<string, dynamic> response = await categoryAPI.UpdateCategory(category.CategoryId, category.Name, category.State, token);

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



        public List<CategoryModel> SearchCategories(List<CategoryModel> categoryList, string search, int radioActive)
        {
            List<CategoryModel> categoryListFiltered = new List<CategoryModel>();

            for (int i = 0; i < categoryList.Count(); i++)
            {
                if(radioActive == 1)
                {
                    if (categoryList[i].Name.ToLower().Contains(search.ToLower()))
                    {
                        categoryListFiltered.Add(categoryList[i]);
                    }
                } else if(radioActive == 0)
                {
                    if (categoryList[i].CategoryId.ToString().Contains(search))
                    {
                        categoryListFiltered.Add(categoryList[i]);
                    }
                }
                
            }          

            return categoryListFiltered;
        }
    }
}
