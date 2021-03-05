using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DataAccess.Api
{
    public class InputAPI
    {
        public Dictionary<string, dynamic> GetInputs(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/input?offset=" + offset + "&state=" + state;
                var client = new RestClient(url);

                var request = new RestRequest(Method.GET);
                request.AddHeader("token", token);

                IRestResponse response = client.Execute(request);

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


        public async Task<Dictionary<string, dynamic>> CreateInput(string dataJson, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/input";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddParameter("application/json", dataJson, ParameterType.RequestBody);

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


        public async Task<Dictionary<string, dynamic>> UpdateInput(int purchaseOrderID, string dataJson, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/input/" + purchaseOrderID;
                var client = new RestClient(url);

                var request = new RestRequest(Method.PUT);
                request.AddParameter("application/json", dataJson, ParameterType.RequestBody);

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


        public Dictionary<string, dynamic> SearchInput(string search, int searchBy, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/input/search";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"search={search}&search_by={searchBy}&state={state}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

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


        public Dictionary<string, dynamic> SearchInputByDate(string search, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/input/search/bydate";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"search={search}&state={state}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

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


        public async Task<Dictionary<string, dynamic>> GetInputDetail(int purchaseOrderID, string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + $"/input/{purchaseOrderID}?offset=" + offset;
                var client = new RestClient(url);

                var request = new RestRequest(Method.GET);
                request.AddHeader("token", token);

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
