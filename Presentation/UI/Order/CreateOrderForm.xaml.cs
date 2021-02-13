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
using WpfControls;
using System.Globalization;

namespace Presentation.UI.Order
{
    /// <summary>
    /// Lógica de interacción para CreateOrderForm.xaml
    /// </summary>
    public partial class CreateOrderForm : Window
    {
        private CommodityController commodityController;
        private List<CommodityModel> commodityList;

        private ProviderController providerController;
        private List<ProviderModel> providerList;

        private PurchaseOrder purchaseOrder;
        private PurchaseOrderController purchaseOrderController;

        public static List<CommodityModel> selectedCommodityList;

        private double totalPrice;

        public CreateOrderForm() { 
            InitializeComponent();           

            commodityList = new List<CommodityModel>();
            selectedCommodityList = new List<CommodityModel>();

            commodityController = new CommodityController();
            order_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            purchaseOrder = new PurchaseOrder();
            purchaseOrderController = new PurchaseOrderController();

            LoadProviders();

            commodityListBox.ItemsSource = selectedCommodityList;

            cb_commodity.DisplayMemberPath = "Name";
            cb_commodity.SelectedValuePath = "CommodityId";

            cb_provider.DisplayMemberPath = "Name";
            cb_provider.SelectedValuePath = "ProviderId";


            receive_date.Text = "";
            expected_date.Text = "";

            txt_total_price.Content = "TOTAL: ";
        }


        private async void LoadProviders()
        {
            providerController = new ProviderController();

            var dataResponse = await providerController.GetProviders(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                providerList = dataResponse["result"].ProviderList;
                cb_provider.ItemsSource = providerList;
            }
        }


        private void AddQuantity_Click(object sender, RoutedEventArgs e)
        {
                   
            CommodityModel commodity = cb_commodity.SelectedItem as CommodityModel;
            if (cb_commodity.Text.Trim() == null || commodity == null)
            {
                MessageBox.Show("Ingrese una mercacancía válida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);               
            }else
            {
                int check = 0;
                for (int i = 0; i < selectedCommodityList.Count; i++)
                {
                    if(selectedCommodityList[i].Name == commodity.Name)
                    {
                        check = 1;
                    }
                }
                if(check == 1)
                {
                    MessageBox.Show("Ya agregó esta mercancía en su orden de pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }else
                {
                    InsertCommodityQuantityForm insertCommodityQuantityForm = new InsertCommodityQuantityForm(commodity.CommodityId, cb_commodity.Text, 0);
                    insertCommodityQuantityForm.ShowDialog();
                    commodityListBox.Items.Refresh();
                    cb_commodity.Text = "";
                    totalPrice = 0;
                    for (int i = 0; i < selectedCommodityList.Count; i++)
                    {
                        totalPrice += selectedCommodityList[i].TotalPrice;
                    }

                    double roundTotalPrice = Math.Round(totalPrice, 2);
                    txt_total_price.Content = "TOTAL: S/" + roundTotalPrice;
                }                
            }
        }


        private void cb_commodity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (cb_commodity.Text.Trim().Length >= 2)
                {
                    var dataResponse = commodityController.SearchCommoditiesAPI(cb_commodity.Text, 1, 1, UserData.getToken().TokenKey);
                    cb_commodity.ItemsSource = dataResponse["result"].CommodityList;
                }
                else if (cb_commodity.Text.Trim().Length <= 2)
                {
                    cb_commodity.ItemsSource = null;
                    cb_commodity.IsDropDownOpen = false;
                }
            }
            catch(Exception error)
            {

            }           
        }


        private void cb_commodity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                cb_commodity.IsDropDownOpen = true;
                cb_commodity.SelectedItem = true;
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedCommodityList.Count >= 1)
            {
                ProviderModel providerModel = cb_provider.SelectedItem as ProviderModel;
                if (providerModel != null)
                {
                    DateTime orderDateTime;
                    DateTime? receiveDateTime = null;
                    DateTime? expectedDateTime = null;
                    DateTime? paidDateTime = null;


                    if (order_date.Text != "") {
                        if (expected_date.Text.Trim() != "")
                        {
                            expectedDateTime = DateTime.ParseExact(expected_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        if (receive_date.Text.Trim() != "")
                        {
                            receiveDateTime = DateTime.ParseExact(receive_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }


                        string data = DateTime.ParseExact(order_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy HH:mm:ss");
                        orderDateTime = DateTime.Parse(data);

                        if (orderDateTime > expectedDateTime)
                        {
                            MessageBox.Show("La fecha de llegada tiene que ser mayor que la fecha de orden!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (orderDateTime > receiveDateTime)
                        {
                            MessageBox.Show("La fecha recibido tiene que ser mayor que la fecha de orden!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (expectedDateTime > receiveDateTime)
                        {
                            MessageBox.Show("La fecha recibido tiene que ser mayor que la fecha de llegada!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            string convertOrder = orderDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string convertExpected = "null";
                            string convertReceive = "null";
                            string convertPaid = "null";

                            if (expectedDateTime != null || expectedDateTime.HasValue)
                            {
                                convertExpected = expectedDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else {
                                convertExpected = "null";
                            }

                            if (receiveDateTime != null || receiveDateTime.HasValue)
                            {
                                convertReceive = receiveDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else {
                                convertReceive = "null";
                            }

                            if (paidDateTime != null || paidDateTime.HasValue)
                            {
                                convertPaid = paidDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else {
                                convertPaid = "null";
                            }


                            purchaseOrder.EmployeeId = UserData.getEmployee().EmployeeId;
                            purchaseOrder.ProviderId = providerModel.ProviderId;
                            purchaseOrder.OrderDate = convertOrder;
                            purchaseOrder.ExpectedDate = convertExpected;
                            purchaseOrder.ReceiveDate = convertReceive;
                            purchaseOrder.PaidDate = convertPaid;
                            purchaseOrder.TotalPrice = totalPrice;
                            purchaseOrder.State = stateOfOrder();
                            purchaseOrder.Message = txt_message.Text;

                            var dataResponse = await purchaseOrderController.CreatePurchaseOrder(purchaseOrder, selectedCommodityList, UserData.getToken().TokenKey);

                            if (dataResponse["ok"])
                            {
                                MessageBox.Show("El órden se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }                                     

                    }
                    else
                    {
                        MessageBox.Show("Ingrese la fecha del pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }                    
                    
                  
                }else
                {
                    MessageBox.Show("Ingrese el proveedor!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else
            {
                MessageBox.Show("Ingrese al menos 1 mercancía para crear un órden de pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }

        

        private int stateOfOrder()
        {
            if (rb_pending.IsChecked.Value)
            {
                return 0;
            }
            else if (rb_waiting.IsChecked.Value)
            {
                return 1;
            }
            else if (rb_received.IsChecked.Value)
            {
                return 2;
            }
            else if(rb_paid.IsChecked.Value)
            {
                return 3;
            }
            else if (rb_cancel.IsChecked.Value)
            {
                return 4;
            }else
            {
                return 4;
            }
        }


        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CommodityModel commodity = commodityListBox.SelectedItem as CommodityModel;

                if (commodity != null)
                {
                    EditDeleteCommodityQuantity editDeleteCommodityQuantityForm = new EditDeleteCommodityQuantity(commodity, 0);
                    editDeleteCommodityQuantityForm.ShowDialog();
                    commodityListBox.Items.Refresh();

                    totalPrice = 0;
                    for (int i=0; i<selectedCommodityList.Count; i++)
                    {
                        totalPrice += selectedCommodityList[i].TotalPrice;
                    }

                    double roundTotalPrice = Math.Round(totalPrice, 2);
                    txt_total_price.Content = "TOTAL: S/" + roundTotalPrice;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
