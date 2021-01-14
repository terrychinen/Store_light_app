using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Provider
    {
        private int providerId;
        private String name;
        private int state;

        public int ProviderId { get => providerId; set => providerId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
