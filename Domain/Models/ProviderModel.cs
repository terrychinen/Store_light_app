using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Domain.Models
{
    public class ProviderModel
    {
        private int providerId;
        private string name;
        private string ruc;
        private string address;
        private string phone;
        private int state;

        [JsonProperty("provider_id")]
        public int ProviderId { get => providerId; set => providerId = value; }
        public string Name { get => name; set => name = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int State { get => state; set => state = value; }
    }
}
