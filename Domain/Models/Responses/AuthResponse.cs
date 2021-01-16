using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models.Responses
{
    public class AuthResponse
    {
        private bool ok;
        private string message;
        private EmployeeModel user;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }
        public EmployeeModel User { get => user; set => user = value; }
    }
}
