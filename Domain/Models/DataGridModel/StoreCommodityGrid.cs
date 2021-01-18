using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DataGridModel
{
    public class StoreCommodityGrid
    {
        List<int> storeIdList;
        List<string> storeNameList;
        int commodityId;
        string commodityName;
        double stock;
        double stockTotal;
        int state;


        public List<int> StoreIdList { get => storeIdList; set => storeIdList = value; }

        public List<string> StoreNameList { get => storeNameList; set => storeNameList = value; }

        public int CommodityId { get => commodityId; set => commodityId = value; }

        public string CommodityName { get => commodityName; set => commodityName = value; }

        public double Stock { get => stock; set => stock = value; }

        public double StockTotal { get => stockTotal; set => stockTotal = value; }

        public int State { get => state; set => state = value; }
    }
}
