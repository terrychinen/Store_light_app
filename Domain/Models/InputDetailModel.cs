using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{
    public class InputDetailModel
    {
        private int purchaseOrderID;
        private int commodityId;
        private string commodityName;
        private int storeId;
        private string storeName;
        private double quantity;


        [JsonProperty("purchase_order_id")]
        public int PurchaseOrderID { get => purchaseOrderID; set => purchaseOrderID = value; }


        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }


        [JsonProperty("commodity_name")]
        public string CommodityName { get => commodityName; set => commodityName = value; }

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }

        [JsonProperty("store_name")]
        public string StoreName { get => storeName; set => storeName = value; }

        [JsonProperty("quantity")]
        public double Quantity { get => quantity; set => quantity = value; }
    }
}
