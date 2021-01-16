using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{
    public class CommodityModel
    {
        private int commodityId;
        private int categoryId;
        private string categoryName;
        private string name;
        private int state;

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }
        [JsonProperty("category_id")]
        public int CategoryId { get => categoryId; set => categoryId = value; }
        [JsonProperty("category_name")]
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
