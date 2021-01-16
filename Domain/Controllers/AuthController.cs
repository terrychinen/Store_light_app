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
    public class AuthController
    {
        public async Task<Dictionary<string, dynamic>> SignIn(string username, string password)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();
                AuthAPI authAPI = new AuthAPI();

                Dictionary<string, dynamic> response = await authAPI.SignIn(username, password);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(response["result"].Content);
                        Token tokenResponse = JsonConvert.DeserializeObject<Token>(response["result"].Content);
                        data.Add("result", authResponse);
                        data.Add("token", tokenResponse);
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
