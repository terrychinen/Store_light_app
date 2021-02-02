using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Domain.Controllers;
using Domain;
using Domain.Models;

namespace Presentation.UI.Order
{
    /// <summary>
    /// Lógica de interacción para EditDeleteCommodityQuantity.xaml
    /// </summary>
    public partial class EditDeleteCommodityQuantity : Window
    {
        //private List<CommodityModel> selectedComomdityListDB;
        private List<CommodityModel> selectedCommodityList;
        private CommodityModel commodity;
        private int checkForm;

        public EditDeleteCommodityQuantity(CommodityModel commodity, int checkForm)
        {
            InitializeComponent();

            this.commodity = commodity;
            this.checkForm = checkForm;

            if(checkForm == 0)
            {
                selectedCommodityList = CreateOrderForm.selectedCommodityList;
            }else
            {
//                selectedComomdityListDB = UpdatePurchaseOrderForm.selectedUpdateCommodityList;
                selectedCommodityList = UpdatePurchaseOrderForm.selectedUpdateCommodityList;
            }

            lb_commodity.Content = $"{commodity.Name}";
            txt_stock.Text = commodity.Quantity.ToString();
            txt_price.Text = commodity.UnitPrice.ToString();           
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (txt_stock.Text.Trim() != "")
            {
                for (int i = 0; i < selectedCommodityList.Count; i++)
                {
                    if (selectedCommodityList[i].Name == commodity.Name)
                    {
                        double quantity = double.Parse(txt_stock.Text);
                        double unitPrice = double.Parse(txt_price.Text);

                        if(checkForm == 0)
                        {
                            CreateOrderForm.selectedCommodityList[i].Quantity = quantity;
                            CreateOrderForm.selectedCommodityList[i].UnitPrice = unitPrice;
                            CreateOrderForm.selectedCommodityList[i].TotalPrice = Math.Round(quantity * unitPrice, 2);
                        }else
                        {
                            UpdatePurchaseOrderForm.selectedUpdateCommodityListDB[i].Quantity = quantity;
                            UpdatePurchaseOrderForm.selectedUpdateCommodityListDB[i].UnitPrice = unitPrice;
                            UpdatePurchaseOrderForm.selectedUpdateCommodityListDB[i].TotalPrice = Math.Round(quantity * unitPrice, 2);

                            UpdatePurchaseOrderForm.selectedUpdateCommodityList[i].Quantity = quantity;
                            UpdatePurchaseOrderForm.selectedUpdateCommodityList[i].UnitPrice = unitPrice;
                            UpdatePurchaseOrderForm.selectedUpdateCommodityList[i].TotalPrice = Math.Round(quantity * unitPrice, 2);
                        }
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Complete el campo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {     
            for (int i = 0; i < selectedCommodityList.Count; i++)
            {
                if (selectedCommodityList[i].Name == commodity.Name)
                {
                    if (checkForm == 0)
                    {
                        CreateOrderForm.selectedCommodityList[i].StatePurchaseOrderDetail = 0;
                        CreateOrderForm.selectedCommodityList.RemoveAt(i);
                    }else
                    {
                        UpdatePurchaseOrderForm.selectedUpdateCommodityListDB[i].StatePurchaseOrderDetail = 0;
                        UpdatePurchaseOrderForm.selectedUpdateCommodityList.RemoveAt(i);
                    }                    
                }
            }

            this.Close();
        }
    }
}
