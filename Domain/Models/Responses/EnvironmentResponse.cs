using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models.Responses
{
    public class EnvironmentResponse
    {
        private bool ok;
        private string message;
        private List<EnvironmentModel> environmentList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }

        [JsonProperty("result")]
        public List<EnvironmentModel> EnvironmentList { get => environmentList; set => environmentList = value; }
    }
}
