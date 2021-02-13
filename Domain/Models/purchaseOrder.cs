using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{
    public class PurchaseOrder
    {
        private int purchaseOrderId; 
        private int providerId;
        private string providerName;
        private int employeeId;
        private string employeeName;
        private string orderDate;
        private string expectedDate;
        private string receiveDate;
        private string paidDate;
        private double totalPrice;
        private string message;
        private int? updatedBy;        
        private int state;

        private string updatedName;
        private string stateName;
        private string stateColor;


        [JsonProperty("purchase_order_id")]
        public int PurchaseOrderId { get => purchaseOrderId; set => purchaseOrderId = value; }

        [JsonProperty("provider_id")]
        public int ProviderId { get => providerId; set => providerId = value; }

        [JsonProperty("provider_name")]
        public string ProviderName { get => providerName; set => providerName = value; }

        [JsonProperty("employee_id")]
        public int EmployeeId { get => employeeId; set => employeeId = value; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get => employeeName; set => employeeName = value; }

        [JsonProperty("order_date")]
        public string OrderDate { get => orderDate; set => orderDate = value; }

        [JsonProperty("expected_date")]
        public string ExpectedDate { get => expectedDate; set => expectedDate = value; }

        [JsonProperty("receive_date")]
        public string ReceiveDate { get => receiveDate; set => receiveDate = value; }


        [JsonProperty("paid_date")]
        public string PaidDate { get => paidDate; set => paidDate = value; }


        [JsonProperty("total_price")]
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }

        public int State { get => state; set => state = value; }

        public string Message { get => message; set => message = value; }

        [JsonProperty("updated_by")]
        public int? UpdatedBy { get => updatedBy; set => updatedBy = value; }



        public string StateName { get => stateName; set => stateName = value; }
        public string StateColor { get => stateColor; set => stateColor = value; }

        [JsonProperty("updated_name")]
        public string UpdatedName { get => updatedName; set => updatedName = value; }

       
    }
}
