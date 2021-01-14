using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{ 
    public class Employee
    {
        private int employeeId;
        private int tokenId;
        private string name;
        private string username;
        private int state;

        [JsonProperty("employee_id")]
        public int EmployeeId { get => employeeId; set => employeeId = value; }

        [JsonProperty("token_id")]
        public int TokenId { get => tokenId; set => tokenId = value; }

        public string Name { get => name; set => name = value; }

        public string Username { get => username; set => username = value; }

        public int State { get => state; set => state = value; }
    }
}
