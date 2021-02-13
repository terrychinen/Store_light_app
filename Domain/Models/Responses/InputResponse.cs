using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models.Responses
{
    public class InputResponse
    {
        private bool ok;
        private string message;
        private List<InputModel> inputList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }

        [JsonProperty("result")]
        public List<InputModel> InputList { get => inputList; set => inputList = value; }
    }
}
