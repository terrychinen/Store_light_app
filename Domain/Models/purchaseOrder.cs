using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PurchaseOrder
    {
        private int purchaseOrderId; 
        private int providerId;
        private int employeeId;
        private DateTime orderDate;
        private DateTime expectedDate;
        private DateTime receiveDate;
        private double totalPrice;
        private int state;

        public int PurchaseOrderId { get => purchaseOrderId; set => purchaseOrderId = value; }
        public int ProviderId { get => providerId; set => providerId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public DateTime ExpectedDate { get => expectedDate; set => expectedDate = value; }
        public DateTime ReceiveDate { get => receiveDate; set => receiveDate = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int State { get => state; set => state = value; }
    }
}
