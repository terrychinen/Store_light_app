using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Output
    {
        private int outputId;
        private int storeId;
        private int commodityId;
        private int environmentId;
        private double quantity;
        private int employeeGivesId;
        private int employeeReceivesId;
        private DateTime date;
        private int state;

        public int OutputId { get => outputId; set => outputId = value; }
        public int StoreId { get => storeId; set => storeId = value; }
        public int CommodityId { get => commodityId; set => commodityId = value; }
        public int EnvironmentId { get => environmentId; set => environmentId = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public int EmployeeGivesId { get => employeeGivesId; set => employeeGivesId = value; }
        public int EmployeeReceivesId { get => employeeReceivesId; set => employeeReceivesId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int State { get => state; set => state = value; }
    }
}
