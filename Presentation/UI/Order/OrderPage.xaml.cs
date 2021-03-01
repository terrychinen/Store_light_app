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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Controllers;
using Domain;
using Domain.Models;

namespace Presentation.UI.Order
{
    /// <summary>
    /// Lógica de interacción para OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private PurchaseOrderController purchaseOrderController;
        private List<PurchaseOrder> purchaseOrdersList;

        public OrderPage()
        {
            InitializeComponent();

            LoadPurchaseOrder();
        }

        private async void LoadPurchaseOrder()
        {
            try
            {
                purchaseOrderController = new PurchaseOrderController();
                var dataResponse = await purchaseOrderController.GetPurchaseOrder(UserData.getToken().TokenKey, 0, 1);

                if (dataResponse["ok"])
                {
                    purchaseOrdersList = dataResponse["result"].PurchaseOrderList;
                    for (int i = 0; i < purchaseOrdersList.Count; i++)
                    {
                        if (purchaseOrdersList[i].OrderDate != null || purchaseOrdersList[i].OrderDate != "")
                        {
                            DateTime orderDate = DateTime.Parse(purchaseOrdersList[i].OrderDate);
                            purchaseOrdersList[i].OrderDate = orderDate.ToString("dd/MM/yyyy HH:mm:ss");

                            purchaseOrdersList[i].StateColor = "Orange";
                            purchaseOrdersList[i].StateName = "POR ATENDER";
                        }


                        string waitingDateString = purchaseOrdersList[i].WaitingDate;
                        string expectedDateString = purchaseOrdersList[i].ExpectedDate;
                        string receiveDateString = purchaseOrdersList[i].ReceiveDate;
                        string paidDateString = purchaseOrdersList[i].PaidDate;
                        string cancelDateString = purchaseOrdersList[i].CancelDate;

                        if (waitingDateString != null)
                        {
                            DateTime waitingDate = DateTime.Parse(purchaseOrdersList[i].WaitingDate);
                            purchaseOrdersList[i].WaitingDate = waitingDate.ToString("dd/MM/yyyy HH:mm:ss");

                            purchaseOrdersList[i].StateColor = "Green";
                            purchaseOrdersList[i].StateName = "EN CURSO";

                        }
                        else { purchaseOrdersList[i].WaitingDate = "----"; }

                     

                        if (expectedDateString != null)
                        {
                            DateTime expectedDate = DateTime.Parse(purchaseOrdersList[i].ExpectedDate);
                            purchaseOrdersList[i].ExpectedDate = expectedDate.ToString("dd/MM/yyyy HH:mm:ss");

                        }
                        else { purchaseOrdersList[i].ExpectedDate = "----"; }


                     

                        if (receiveDateString != null)
                        {
                            if (paidDateString != null)
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "RECIBIDO-PAGADO";
                            }
                            else
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "RECIBIDO";
                            }
                            
                         

                            DateTime receiveDate = DateTime.Parse(purchaseOrdersList[i].ReceiveDate);
                            purchaseOrdersList[i].ReceiveDate = receiveDate.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        else { purchaseOrdersList[i].ReceiveDate = "----"; }



                       

                        if (paidDateString != null)
                        {
                            if (receiveDateString != null)
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "RECIBIDO-PAGADO";
                            }else
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "PAGADO";
                            }

                          

                            DateTime paidDate = DateTime.Parse(purchaseOrdersList[i].PaidDate);
                            purchaseOrdersList[i].PaidDate = paidDate.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        else { purchaseOrdersList[i].PaidDate = "----"; }


                    


                        if (cancelDateString != null)
                        {
                            purchaseOrdersList[i].StateColor = "Red";
                            purchaseOrdersList[i].StateName = "ANULADO";

                            DateTime cancelDate = DateTime.Parse(purchaseOrdersList[i].CancelDate);
                            purchaseOrdersList[i].CancelDate = cancelDate.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        else { purchaseOrdersList[i].CancelDate = "----"; }
                    }

                    purchaseOrderListBox.ItemsSource = purchaseOrdersList;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }


        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {            
            CreateOrderForm createOrderForm = new CreateOrderForm();
            createOrderForm.ShowDialog();
            LoadPurchaseOrder();
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PurchaseOrder purchaseOrder = purchaseOrderListBox.SelectedItem as PurchaseOrder;

                if (purchaseOrder != null)
                {
                    UpdatePurchaseOrderForm updatePurchaseOrderForm = new UpdatePurchaseOrderForm(purchaseOrder);
                    updatePurchaseOrderForm.ShowDialog();
                    LoadPurchaseOrder();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
