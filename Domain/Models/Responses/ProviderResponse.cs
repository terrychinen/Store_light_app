using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models.Responses
{
    public class ProviderResponse
    {
        private bool ok;
        private string message;
        private List<ProviderModel> providerList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }

        [JsonProperty("result")]
        public List<ProviderModel> ProviderList { get => providerList; set => providerList = value; }
    }
}
