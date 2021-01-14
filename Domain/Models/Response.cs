using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    class Response
    {
        private bool ok;
        private string message;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }
    }
}
