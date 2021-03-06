﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DataAccess.Api
{
    public class OutputAPI
    {
        public Dictionary<string, dynamic> GetOutputs(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/output?offset=" + offset + "&state=" + state;
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

        public Dictionary<string, dynamic> CreateOutput(int storeID, int environmentID, int commodityID, double quantity, 
            int employeeGivesID, int employeeReceivesID, string dateOutput, string notes, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/output";
                var client = new RestClient(url);

                var request = new RestRequest(Method.POST);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"store_id={storeID}&environment_id={environmentID}&" +
                    $"commodity_id={commodityID}&quantity={quantity}&employee_gives={employeeGivesID}&employee_receives={employeeReceivesID}" +
                    $"&date_output={dateOutput}&notes={notes}&state={state}", ParameterType.RequestBody);

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


        public Dictionary<string, dynamic> UpdateOutput(int outputID, int environmentID, 
            int employeeGivesID, int employeeReceivesID, string dateOutput, string notes, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/output/" + outputID;
                var client = new RestClient(url);

                var request = new RestRequest(Method.PUT);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"environment_id={environmentID}&" +
                    $"employee_gives={employeeGivesID}&employee_receives={employeeReceivesID}&" +
                    $"date_output={dateOutput}&notes={notes}&state={state}", ParameterType.RequestBody);

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


        public Dictionary<string, dynamic> UpdateStock(int outputID, int storeID, int commodityID, double quantity, double leftQuantity,  string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/output/stock/" + outputID;
                var client = new RestClient(url);

                var request = new RestRequest(Method.PUT);
                request.AddHeader("token", token);
                request.AddParameter("application/x-www-form-urlencoded", $"store_id={storeID}&commodity_id={commodityID}&" +
                    $"quantity={quantity}&left_quantity={leftQuantity}", ParameterType.RequestBody);

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

        public Dictionary<string, dynamic> SearchOutput(string search, int searchBy, int state, string token)
        {
            Dictionary<string, dynamic> data;

            try
            {
                data = new Dictionary<string, dynamic>();

                var url = Connection.CONNECTION + "/output/search";
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

    }
}
