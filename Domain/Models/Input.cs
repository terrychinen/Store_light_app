using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Input
    {
        private int inputId;
        private int commodityId;
        private int storeId;
        private int employeeId;
        private double quantity;
        private DateTime date;
        private int state;

        public int InputId { get => inputId; set => inputId = value; }
        public int CommodityId { get => commodityId; set => commodityId = value; }
        public int StoreId { get => storeId; set => storeId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public DateTime Date { get => date; set => date = value; }
        public int State { get => state; set => state = value; }
    }
}
