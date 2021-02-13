using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Domain.Models
{
    public class InputModel
    {
        private int purchaseOrderId;
        private int commodityId;        
        private int storeId;
        private int employeeId;
        private double quantity;
        private DateTime date;
        private int state;

        [JsonProperty("purchase_order_id")]
        public int PurchaseOrderId { get => purchaseOrderId; set => purchaseOrderId = value; }

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }

        [JsonProperty("employee_id")]
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public DateTime Date { get => date; set => date = value; }
        public int State { get => state; set => state = value; }
    }
}
