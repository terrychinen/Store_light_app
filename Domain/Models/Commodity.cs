using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Commodity
    {
        private int commodityId;
        private int categoryId;
        private String name;
        private int state;

        public int CommodityId { get => commodityId; set => commodityId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Name { get => name; set => name = value; }
        public int State { get => state; set => state = value; }
    }
}
