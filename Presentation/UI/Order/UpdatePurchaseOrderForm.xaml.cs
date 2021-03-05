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

            receive_date.Text = "";
            waiting_date.Text = "";
            expected_date.Text = "";
            paid_date.Text = "";
            cancel_date.Text = "";


            if (purchaseOrder.WaitingDate == "----")
            {
                purchaseOrder.WaitingDate = "";
            }

            if (purchaseOrder.ExpectedDate == "----")
            {
                purchaseOrder.ExpectedDate = "";
            }

            if (purchaseOrder.ReceiveDate == "----")
            {
                purchaseOrder.ReceiveDate = "";
            }

            if (purchaseOrder.PaidDate == "----")
            {
                purchaseOrder.PaidDate = "";
            }
                
            if (purchaseOrder.CancelDate == "----")
            {
                purchaseOrder.CancelDate = "";
            }



            waiting_date.Text = purchaseOrder.WaitingDate;
            expected_date.Text = purchaseOrder.ExpectedDate;
            receive_date.Text = purchaseOrder.ReceiveDate;
            paid_date.Text = purchaseOrder.PaidDate;
            cancel_date.Text = purchaseOrder.CancelDate;


            txt_total_price.Content = "TOTAL: S/" + Math.Round(purchaseOrder.TotalPrice, 2);
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
                    DateTime? orderDateTime;
                    DateTime? waitingDateTime = null;
                    DateTime? receiveDateTime = null;
                    DateTime? expectedDateTime = null;
                    DateTime? paidDateTime = null;
                    DateTime? cancelDateTime = null;

                    string waitingDateString = waiting_date.Text;
                    string receiveDateString = receive_date.Text;
                    string paidDateString = paid_date.Text;
                    string expectedDateString = expected_date.Text;
                    string cancelDateString = cancel_date.Text;

                    if (order_date.Text.Trim() != "")
                    {
                        if (waitingDateString.Trim() != "")
                        {
                            waitingDateTime = DateTime.ParseExact(waiting_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        if (receiveDateString.Trim() != "")
                        {
                            receiveDateTime = DateTime.ParseExact(receive_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                        if (paidDateString.Trim() != "")
                        {
                            paidDateTime = DateTime.ParseExact(paid_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                        if (expectedDateString.Trim() != "")
                        {
                            expectedDateTime = DateTime.ParseExact(expected_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                        if (cancelDateString.Trim() != "")
                        {
                            cancelDateTime = DateTime.ParseExact(cancel_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                        orderDateTime = DateTime.ParseExact(order_date.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        if (orderDateTime > expectedDateTime)
                        {
                            MessageBox.Show("La fecha de llegada tiene que ser mayor que la fecha de orden!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if(orderDateTime > waitingDateTime)
                        {
                            MessageBox.Show("La fecha en curso tiene que ser mayor que la fecha de orden!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
                            string convertOrder = orderDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            string convertWaiting = "null";
                            string convertExpected = "null";
                            string convertReceive = "null";
                            string convertPaid = "null";
                            string convertCancel = "null";
                            int state = 0;

                            if (waitingDateTime != null || waitingDateTime.HasValue)
                            {
                                convertWaiting = waitingDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                                state = 1;
                            }
                            else
                            {
                                convertWaiting = "null";
                            }

                            if (expectedDateTime != null || expectedDateTime.HasValue)
                            {
                                convertExpected = expectedDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else {
                                convertExpected = "null";
                            }
                                                       

                            if (receiveDateTime != null || receiveDateTime.HasValue)
                            {
                                if (paidDateTime != null || paidDateTime.HasValue)
                                {
                                    state = 4;
                                }
                                else
                                {
                                    state = 2;
                                }
                                convertReceive = receiveDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else {
                                convertReceive = "null";
                            }

                            if (paidDateTime != null || paidDateTime.HasValue)
                            {
                                if (receiveDateTime != null || receiveDateTime.HasValue)
                                {
                                    state = 4;
                                }
                                else
                                {
                                    state = 3;
                                }
                                convertPaid = paidDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                convertPaid = "null";
                            }

                            if (cancelDateTime != null || cancelDateTime.HasValue)
                            {
                                convertCancel = cancelDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                                state = 5;
                            }
                            else
                            {
                                convertCancel = "null";
                            }


                            purchaseOrder.ProviderId = providerModel.ProviderId;
                            purchaseOrder.OrderDate = convertOrder;
                            purchaseOrder.WaitingDate = convertWaiting;
                            purchaseOrder.ExpectedDate = convertExpected;
                            purchaseOrder.ReceiveDate = convertReceive;
                            purchaseOrder.PaidDate = convertPaid;
                            purchaseOrder.CancelDate = convertCancel;
                            purchaseOrder.TotalPrice = totalPrice;                            
                            purchaseOrder.Message = txt_message.Text;
                            purchaseOrder.UpdatedBy = UserData.getEmployee().EmployeeId;
                            purchaseOrder.State = state;


                            var dataResponse = await purchaseOrderController.UpdatePurchaseOrder(purchaseOrder, selectedUpdateCommodityList, UserData.getToken().TokenKey);

                            if (dataResponse["ok"])
                            {
                                MessageBox.Show("El órden se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(dataResponse["result"].ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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