using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models 
{ 
    public class Environment
    {
        private int environmentId;
        private String name;
        private int state;

        public int EnvironmentId { get => environmentId; set => environmentId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
