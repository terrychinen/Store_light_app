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
using System.Text.RegularExpressions;


namespace Presentation.UI.Order
{
    /// <summary>
    /// Lógica de interacción para InsertCommodityQuantityForm.xaml
    /// </summary>
    public partial class InsertCommodityQuantityForm : Window
    {
        private int commodityID;
        private string commodityName;

        private int checkForm;

        public InsertCommodityQuantityForm(int commodityId, string commodityName, int checkForm)
        {
            InitializeComponent();

            this.commodityID = commodityId;
            this.commodityName = commodityName;
            this.checkForm = checkForm;
            lb_commodity.Content = commodityName;

            txt_price.Text = "0";
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+[.[0-9]+]?");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_quantity.Text.Trim() != "" &&  txt_price.Text.Trim() != "")
                {
                    double quantity = double.Parse(txt_quantity.Text);
                    double price = double.Parse(txt_price.Text);

                    if(quantity >= 0)
                    {
                        if(price >= 0)
                        {                         

                            CommodityModel commoditySelected = new CommodityModel();

                            commoditySelected.Name = commodityName;
                            commoditySelected.CommodityId = commodityID;
                            commoditySelected.Quantity = quantity;
                            commoditySelected.UnitPrice = price;
                            commoditySelected.TotalPrice = Math.Round(quantity * price, 2);
                       

                            if (checkForm == 0)
                            {
                                CreateOrderForm.selectedCommodityList.Add(commoditySelected);
                            }else
                            {
                                UpdatePurchaseOrderForm.selectedUpdateCommodityList.Add(commoditySelected);
                            }
                            
                            this.Close();
                        }else
                        {
                            MessageBox.Show("Ingrese un valor en el costo unitario (mayor o igual que 0)!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                      
                    }else
                    {
                        MessageBox.Show("Ingrese el stock un valor mayor o igual que 0!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                 
                }
                else
                {
                    MessageBox.Show("Complete el campo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Ingrese un formato correcto!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }           

        }
    }
}
