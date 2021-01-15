using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccess.Api;
using Domain.Models;
using Domain.Models.Responses;


namespace Domain.Controllers
{
    public class ProviderController
    {
        public async Task<Dictionary<string, dynamic>> GetProviders(string token, int offset, int state)
        {
            Dictionary<string, dynamic> data;
            ProviderAPI providerAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                providerAPI = new ProviderAPI();
                Dictionary<string, dynamic> response = await providerAPI.GetProviders(token, offset, state);

                if (response["ok"])
                {
                    Response dataResponse = JsonConvert.DeserializeObject<Response>(response["result"].Content);

                    data.Add("ok", dataResponse.Ok);


                    if (dataResponse.Ok)
                    {
                        ProviderResponse providerListResponse = JsonConvert.DeserializeObject<ProviderResponse>(response["result"].Content);
                        data.Add("result", providerListResponse);
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


        public async Task<Dictionary<string, dynamic>> CreateProvider(ProviderModel provider, string token)
        {
            Dictionary<string, dynamic> data;
            ProviderAPI providerAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                providerAPI = new ProviderAPI();
                Dictionary<string, dynamic> response = await providerAPI.CreateProvider(provider.Name, provider.Ruc, provider.Address, provider.Phone, provider.State, token);

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


        public async Task<Dictionary<string, dynamic>> UpdateProvider(ProviderModel provider, string token)
        {
            Dictionary<string, dynamic> data;
            ProviderAPI providerAPI;

            try
            {
                data = new Dictionary<string, dynamic>();
                providerAPI = new ProviderAPI();
                Dictionary<string, dynamic> response = await providerAPI.UpdateProvider(provider.ProviderId, provider.Name, provider.Ruc, provider.Address, provider.Phone, provider.State, token);

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




        public List<ProviderModel> SearchProviders(List<ProviderModel> providerList, string search, int radioActive)
        {
            List<ProviderModel> providerListFiltered = new List<ProviderModel>();

            for (int i = 0; i < providerList.Count(); i++)
            {
                if (radioActive == 0)
                {
                    if (providerList[i].ProviderId.ToString().Contains(search))
                    {
                        providerListFiltered.Add(providerList[i]);
                    }
                }
                else if (radioActive == 1)
                {
                    if (providerList[i].Name.ToLower().Contains(search.ToLower()))
                    {
                        providerListFiltered.Add(providerList[i]);
                    }
                }else if(radioActive == 2)
                {
                    if (providerList[i].Ruc.Contains(search))
                    {
                        providerListFiltered.Add(providerList[i]);
                    }
                }else if(radioActive == 3)
                {
                    if (providerList[i].Address.ToLower().Contains(search.ToLower()))
                    {
                        providerListFiltered.Add(providerList[i]);
                    }
                }else if(radioActive == 4)
                {
                    if (providerList[i].Phone.Contains(search))
                    {
                        providerListFiltered.Add(providerList[i]);
                    }
                }

            }

            return providerListFiltered;
        }
    }
}
