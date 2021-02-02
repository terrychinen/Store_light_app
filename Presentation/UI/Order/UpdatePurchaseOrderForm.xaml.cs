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
using System.Globalization;

namespace Presentation.UI.Order
{
    /// <summary>
    /// Lógica de interacción para UpdatePurchaseOrderForm.xaml
    /// </summary>
    public partial class UpdatePurchaseOrderForm : Window
    {
        private CommodityController commodityController;
        private List<CommodityModel> commodityList;

        private ProviderController providerController;
        private List<ProviderModel> providerList;

        private PurchaseOrder purchaseOrder;
        private PurchaseOrderController purchaseOrderController;

        public static List<CommodityModel> selectedUpdateCommodityListDB;
        public static List<CommodityModel> selectedUpdateCommodityList;

        private double totalPrice;


        public UpdatePurchaseOrderForm(PurchaseOrder purchaseOrder)
        {
            InitializeComponent();

            commodityList = new List<CommodityModel>();
            selectedUpdateCommodityList = new List<CommodityModel>();
            selectedUpdateCommodityListDB = new List<CommodityModel>();

            commodityController = new CommodityController();

            this.totalPrice = purchaseOrder.TotalPrice;
            this.purchaseOrder = purchaseOrder;
            purchaseOrderController = new PurchaseOrderController();

            LoadProviders();
            LoadPurchaseOrderDetail();

            cb_commodity.DisplayMemberPath = "Name";
            cb_commodity.SelectedValuePath = "CommodityId";

            cb_provider.DisplayMemberPath = "Name";
            cb_provider.SelectedValuePath = "ProviderId";
     
           
            txt_message.Text = purchaseOrder.Message;


            order_date.Text = purchaseOrder.OrderDate;

            if(purchaseOrder.ExpectedDate == "----")
            {
                purchaseOrder.ExpectedDate = "";
            }

            if (purchaseOrder.ReceiveDate == "----")
            {
                purchaseOrder.ReceiveDate = "";
            }


            if(purchaseOrder.State == 0)
            {
                rb_pending.IsChecked = true;
            }else if(purchaseOrder.State == 1)
            {
                rb_waiting.IsChecked = true;
            }else if(purchaseOrder.State == 2)
            {
                rb_received.IsChecked = true;
            }else
            {
                rb_cancel.IsChecked = true;
            }

           
            expected_date.Text = purchaseOrder.ExpectedDate;
            receive_date.Text = purchaseOrder.ReceiveDate;


            txt_total_price.Content = "TOTAL: S/." +purchaseOrder.TotalPrice;
        }

        private async void LoadProviders()
        {
            providerController = new ProviderController();

            var dataResponse = await providerController.GetProviders(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                providerList = dataResponse["result"].ProviderList;
                cb_provider.ItemsSource = providerList;

                for (int i = 0; i < providerList.Count; i++)
                {
                    if(providerList[i].Name == purchaseOrder.ProviderName)
                    {
                        cb_provider.SelectedIndex = i;                        
                    }
                }                    
            }
        }

        private async void LoadPurchaseOrderDetail()
        {
            var dataResponse = await purchaseOrderController.GetPurchaseOrderDetail(purchaseOrder.PurchaseOrderId, UserData.getToken().TokenKey, 0, 1);
            if (dataResponse["ok"])
            {
                commodityList = dataResponse["result"].CommodityList;
                commodityListBox.ItemsSource = commodityList;
         

                selectedUpdateCommodityListDB = commodityList;
                for(int i=0; i< selectedUpdateCommodityListDB.Count; i++ )
                {                    
                    selectedUpdateCommodityListDB[i].StatePurchaseOrderDetail = 1;

                }


                selectedUpdateCommodityList = commodityList;
                for (int i = 0; i < selectedUpdateCommodityListDB.Count; i++)
                {
                    selectedUpdateCommodityList[i].StatePurchaseOrderDetail = 1;
                }

              
            }
        }

        private void AddQuantity_Click(object sender, RoutedEventArgs e)
        {
            CommodityModel commodity = cb_commodity.SelectedItem as CommodityModel;
            if (cb_commodity.Text.Trim() == null || commodity == null)
            {
                MessageBox.Show("Ingrese una mercacancía válida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int check = 0;
                for (int i = 0; i < selectedUpdateCommodityList.Count; i++)
                {
                    if (selectedUpdateCommodityList[i].Name == commodity.Name)
                    {
                        check = 1;
                    }
                }

                if (check == 1)
                {
                    MessageBox.Show("Ya agregó esta mercancía en su orden de pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    InsertCommodityQuantityForm insertCommodityQuantityForm = new InsertCommodityQuantityForm(commodity.CommodityId, cb_commodity.Text, 1);
                    insertCommodityQuantityForm.ShowDialog();
                    commodityListBox.Items.Refresh();
                    cb_commodity.Text = "";
                    totalPrice = 0;

                    for (int i = 0; i < selectedUpdateCommodityList.Count; i++)
                    {
                        totalPrice += selectedUpdateCommodityList[i].TotalPrice;
                    }

                    double roundTotalPrice = Math.Round(totalPrice, 2);
                    txt_total_price.Content = "TOTAL: S/" + roundTotalPrice;
                }
            }
        }


        private void cb_commodity_KeyDown(object sender, KeyEventArgs e)
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


        private void cb_commodity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                cb_commodity.IsDropDownOpen = true;
                cb_commodity.SelectedItem = true;
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
            else
            {
                return 3;
            }
        }


        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CommodityModel commodity = commodityListBox.SelectedItem as CommodityModel;

                if (commodity != null)
                {
                    EditDeleteCommodityQuantity editDeleteCommodityQuantityForm = new EditDeleteCommodityQuantity(commodity, 1);
                    editDeleteCommodityQuantityForm.ShowDialog();
                    commodityListBox.Items.Refresh();

                    totalPrice = 0;
                    for (int i = 0; i < selectedUpdateCommodityList.Count; i++)
                    {
                        totalPrice += selectedUpdateCommodityList[i].TotalPrice;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUpdateCommodityList.Count >= 1)
            {
                ProviderModel providerModel = cb_provider.SelectedItem as ProviderModel;
                if (providerModel != null)
                {
                    DateTime orderDateTime;
                    DateTime? receiveDateTime = null;
                    DateTime? expectedDateTime = null;

                    if (order_date.Text.Trim() != "")
                    {
                        if (!string.IsNullOrEmpty(expected_date.Text))
                        {
                            expectedDateTime = DateTime.ParseExact(expected_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);                           
                        }    

                        if (!string.IsNullOrEmpty(receive_date.Text))
                        {
                            receiveDateTime = DateTime.ParseExact(receive_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);                            
                        }

                        orderDateTime = DateTime.Parse(order_date.Text);

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
                            string convertExpected = "";
                            string convertReceive = "";

                            if (expectedDateTime != null)
                            {
                                convertExpected = expectedDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (receiveDateTime != null)
                            {
                                convertReceive = receiveDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }


                            purchaseOrder.ProviderId = providerModel.ProviderId;
                            purchaseOrder.OrderDate = convertOrder;
                            purchaseOrder.ExpectedDate = convertExpected;
                            purchaseOrder.ReceiveDate = convertReceive;
                            purchaseOrder.TotalPrice = totalPrice;                            
                            purchaseOrder.Message = txt_message.Text;
                            purchaseOrder.UpdatedBy = UserData.getEmployee().EmployeeId;
                            purchaseOrder.State = stateOfOrder();


                            var dataResponse = await purchaseOrderController.UpdatePurchaseOrder(purchaseOrder, selectedUpdateCommodityList, UserData.getToken().TokenKey);

                            if (dataResponse["ok"])
                            {
                                MessageBox.Show("El órden se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ingrese la fecha del pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Ingrese el proveedor!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese al menos 1 mercancía para crear un órden de pedido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}