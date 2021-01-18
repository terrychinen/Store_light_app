using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;

namespace Domain.Models.Responses
{
    public class StoreCommodityResponse
    {
        private bool ok;
        private string message;
        private List<StoreCommodityModel> storeCommodityList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }

        [JsonProperty("result")]
        public List<StoreCommodityModel> StoreCommodityList { get => storeCommodityList; set => storeCommodityList = value; }
    }
}
