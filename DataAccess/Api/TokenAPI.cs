using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;

namespace DataAccess.Api
{
    public class TokenAPI
    {
        public async Task<Dictionary<string, dynamic>> RefreshToken(string token, int userId)
        {
            Dictionary<string, dynamic> data;
            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/token/refresh";

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("application/x-www-form-urlencoded", $"token={token}&user_id={userId}", ParameterType.RequestBody);
                
                IRestResponse response = await client.ExecuteAsync(request);

                data.Add("ok", true);
                data.Add("result", response);

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
