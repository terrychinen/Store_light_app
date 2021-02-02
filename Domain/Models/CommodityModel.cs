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

        private double quantity;
        private double unitPrice;
        private double totalPrice;
        private int statePurchaseOrderDetail;

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }
        [JsonProperty("category_id")]
        public int CategoryId { get => categoryId; set => categoryId = value; }
        [JsonProperty("category_name")]
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }


        [JsonProperty("quantity")]
        public double Quantity { get => quantity; set => quantity = value; }

        [JsonProperty("unit_price")]
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }

        [JsonProperty("total_price")]
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int StatePurchaseOrderDetail { get => statePurchaseOrderDetail; set => statePurchaseOrderDetail = value; }
    }
}
