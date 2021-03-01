using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Domain.Models
{
    public class OutputModel
    {
        private int outputId;
        private int storeId;
        private string storeName;
        private int commodityId;
        private string commodityName;
        private int environmentId;
        private string environmentName;
        private double quantity;
        private int employeeGivesId;
        private string employeeGivesName;
        private int employeeReceivesId;
        private string employeeReceivesName;
        private string dateOutput;
        private string notes;
        private int state;


        [JsonProperty("output_id")]
        public int OutputId { get => outputId; set => outputId = value; }

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }

        [JsonProperty("store_name")]
        public string StoreName { get => storeName; set => storeName = value; }

        [JsonProperty("commodity_id")]
        public int CommodityId { get => commodityId; set => commodityId = value; }

        [JsonProperty("commodity_name")]
        public string CommodityName { get => commodityName; set => commodityName = value; }

        [JsonProperty("environment_id")]
        public int EnvironmentId { get => environmentId; set => environmentId = value; }

        [JsonProperty("environment_name")]
        public string EnvironmentName { get => environmentName; set => environmentName = value; }
        public double Quantity { get => quantity; set => quantity = value; }

        [JsonProperty("employee_gives")]
        public int EmployeeGivesId { get => employeeGivesId; set => employeeGivesId = value; }

        [JsonProperty("employee_gives_name")]
        public string EmployeeGivesName { get => employeeGivesName; set => employeeGivesName = value; }

        [JsonProperty("employee_receives")]
        public int EmployeeReceivesId { get => employeeReceivesId; set => employeeReceivesId = value; }

        [JsonProperty("employee_receives_name")]
        public string EmployeeReceivesName { get => employeeReceivesName; set => employeeReceivesName = value; }

        [JsonProperty("date_output")]
        public string DateOutput { get => dateOutput; set => dateOutput = value; }
        public int State { get => state; set => state = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
