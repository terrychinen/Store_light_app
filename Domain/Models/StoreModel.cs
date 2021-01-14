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

        [JsonProperty("store_id")]
        public int StoreId { get => storeId; set => storeId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
