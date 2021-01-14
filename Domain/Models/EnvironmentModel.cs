using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Domain.Models 
{ 
    public class EnvironmentModel
    {
        private int environmentId;
        private string name;
        private int state;

        [JsonProperty("environment_id")]
        public int EnvironmentId { get => environmentId; set => environmentId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
