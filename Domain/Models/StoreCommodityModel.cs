using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{
    public class StoreCommodityModel
    {
        int storeId;
        string storeName;
        int commodityId;
        string commodityName;
        double stock;
        double stockTotal;
        int state;       
        bool selectedStore; 
        string stateString;

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }

        [JsonProperty("store_name")]
        public string StoreName { get => storeName; set => storeName = value; }

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }

        [JsonProperty("commodity_name")]
        public string CommodityName { get => commodityName; set => commodityName = value; }

        public double Stock { get => stock; set => stock = value; }

        [JsonProperty("stock_total")]
        public double StockTotal { get => stockTotal; set => stockTotal = value; }

        public int State { get => state; set => state = value; }

        public bool SelectedStore { get => selectedStore; set => selectedStore = value; }
        public string StateString { get => stateString; set => stateString = value; }




        // public List<string> StoreNameSelectedList { get => storeNameSelectedList; set => storeNameSelectedList = value; }
    }
}
