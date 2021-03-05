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
        private int purchaseOrderID;
        private int commodityId;        
        private int storeId;
        private int employeeId;
        private string employeeName;
        private double quantity;
        private string inputDate;
        private string notes;
        private int state;

        private string stateName;
        private string stateColor;

        [JsonProperty("purchase_order_id")]
        public int PurchaseOrderID { get => purchaseOrderID; set => purchaseOrderID = value; }

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }

        [JsonProperty("employee_id")]
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public double Quantity { get => quantity; set => quantity = value; }

        [JsonProperty("input_date")]
        public string InputDate { get => inputDate; set => inputDate = value; }


        public int State { get => state; set => state = value; }
        public string Notes { get => notes; set => notes = value; }


        [JsonProperty("employee_name")]
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string StateName { get => stateName; set => stateName = value; }
        public string StateColor { get => stateColor; set => stateColor = value; }
    }
}
