using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{ 
    public class Store
    {
        private int storeId;
        private String name;
        private int state;

        public int StoreId { get => storeId; set => storeId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
