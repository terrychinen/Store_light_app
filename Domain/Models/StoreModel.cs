using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{ 
    public class StoreModel
    {
        private int storeId;
        private string name;
        private int state;


        private double stockSelected;
        private string storeNameSelected;

        bool selectedStore;

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }


        public bool SelectedStore { get => selectedStore; set => selectedStore = value; }
        public double StockSelected { get => stockSelected; set => stockSelected = value; }
        public string StoreNameSelected { get => storeNameSelected; set => storeNameSelected = value; }
    }
}
