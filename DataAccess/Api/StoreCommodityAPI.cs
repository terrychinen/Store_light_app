﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DataAccess.Api
{
    public class StoreCommodityAPI
    {
        public async Task<Dictionary<string, dynamic>> GetStoreCommodity(string token, int offset, int state) 
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/store_commodity?offset=" + offset + "&state=" + state;
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

        public async Task<Dictionary<string, dynamic>> CreateStoreCommodity(string storeCommodityString, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/store_commodity";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"{storeCommodityString}", ParameterType.RequestBody);

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