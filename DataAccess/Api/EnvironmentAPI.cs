﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace DataAccess.Api
{
    public class EnvironmentAPI
    {
        public async Task<Dictionary<string, dynamic>> GetEnvironments(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/environment?offset=" + offset + "&state=" + state;
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


        public async Task<Dictionary<string, dynamic>> CreateEnvironment(string environmentName, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/environment";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"name={environmentName}&state={state}", ParameterType.RequestBody);

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


        public async Task<Dictionary<string, dynamic>> UpdateEnvironment(int environmentID, string environmentName, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/environment/" + environmentID;
                var client = new RestClient(url);

                var request = new RestRequest(Method.PUT);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"name={environmentName}&state={state}", ParameterType.RequestBody);

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
