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
    public class EmployeeController
    {
        public async Task<Dictionary<string, dynamic>> GetEmployees(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            EmployeeAPI employeeAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                employeeAPI = new EmployeeAPI();
                Dictionary<string, dynamic> response = await employeeAPI.GetEmployees(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        EmployeeResponse employeeListResponse = JsonConvert.DeserializeObject<EmployeeResponse>(response["result"].Content);
                        data.Add("result", employeeListResponse);
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


        public async Task<Dictionary<string, dynamic>> CreateEmployee(EmployeeModel employee, string token)
        {
            Dictionary<string, dynamic> data;
            EmployeeAPI employeeAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                employeeAPI = new EmployeeAPI();
                Dictionary<string, dynamic> response = await employeeAPI.CreateEmployee(employee.Name, employee.Username, employee.Password, employee.State, token);

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


        public async Task<Dictionary<string, dynamic>> UpdateEmployee(EmployeeModel employee, string token)
        {
            Dictionary<string, dynamic> data;
            EmployeeAPI employeeAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                employeeAPI = new EmployeeAPI();
                Dictionary<string, dynamic> response = await employeeAPI.UpdateEmployee(employee.EmployeeId, employee.Name, employee.Username, employee.Password, employee.State, token);

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



        public List<EmployeeModel> SearchEmployees(List<EmployeeModel> employeeList, string search, int radioActive)
        {
            List<EmployeeModel> employeeListFiltered = new List<EmployeeModel>();

            for (int i = 0; i < employeeList.Count(); i++)
            {
                if (radioActive == 1)
                {
                    if (employeeList[i].Name.ToLower().Contains(search.ToLower()))
                    {
                        employeeListFiltered.Add(employeeList[i]);
                    }
                }
                else if (radioActive == 0)
                {
                    if (employeeList[i].EmployeeId.ToString().Contains(search))
                    {
                        employeeListFiltered.Add(employeeList[i]);
                    }
                }
                else if (radioActive == 2)
                {
                    if (employeeList[i].Username.ToLower().Contains(search.ToLower()))
                    {
                        employeeListFiltered.Add(employeeList[i]);
                    }
                }

            }

            return employeeListFiltered;
        }
    }
}
