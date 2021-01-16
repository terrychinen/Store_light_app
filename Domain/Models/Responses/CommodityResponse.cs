using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;


namespace Domain.Models.Responses
{
    public class CommodityResponse
    {
        private bool ok;
        private string message;
        private List<CommodityModel> commodityList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }

        [JsonProperty("result")]
        public List<CommodityModel> CommodityList { get => commodityList; set => commodityList = value; }
    }
}
