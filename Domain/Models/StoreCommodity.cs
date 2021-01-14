using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StoreCommodity
    {
        private int storeId;
        private int commodityId;
        private double stock;
        private int state;

        public int StoreId { get => storeId; set => storeId = value; }
        public int CommodityId { get => commodityId; set => commodityId = value; }
        public double Stock { get => stock; set => stock = value; }
        public int State { get => state; set => state = value; }
    }
}
