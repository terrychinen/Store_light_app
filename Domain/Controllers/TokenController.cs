using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Api;
using Domain.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Domain.Controllers
{
    public class TokenController
    {
        public bool ValidateToken(Token token)
        {
            DateTime today = DateTime.Now;

            var diff = (today - token.CreatedAt).TotalMilliseconds;

            if (token.ExpiresIn - diff >= 300000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<Dictionary<string, dynamic>> RefreshToken(Token token, int userID)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();
                TokenAPI tokenAPI = new TokenAPI();

                Dictionary<string, dynamic> response = await tokenAPI.RefreshToken(token.TokenKey, userID);  

                if (response["ok"])
                {
                    Token tokenResponse = JsonConvert.DeserializeObject<Token>(response["result"].Content);
                    data.Add("result", tokenResponse);
                }else
                {
                    data.Add("result", "Error, consultar con el programador");
                }

                return data;
            }
            catch(Exception error)
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
