﻿using System;
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

namespace Presentation.UI.Input
{
    /// <summary>
    /// Lógica de interacción para CreateInputPage.xaml
    /// </summary>
    public partial class CreateInputPage : Page
    {
        private PurchaseOrderController purchaseOrderController;
        private List<PurchaseOrder> purchaseOrdersList;

        private List<PurchaseOrder> purchaseOrdersListTemporal;

        public CreateInputPage()
        {
            InitializeComponent();
            LoadPurchaseOrder();
        }

        private async void LoadPurchaseOrder()
        {
            try
            {
                purchaseOrderController = new PurchaseOrderController();
                var dataResponse = await purchaseOrderController.GetPurchaseOrderWithState(UserData.getToken().TokenKey, 0, 2);
                var dataResponse1 = await purchaseOrderController.GetPurchaseOrderWithState(UserData.getToken().TokenKey, 0, 4);

                if (dataResponse["ok"] && dataResponse1["ok"])
                {
                    purchaseOrdersList = dataResponse["result"].PurchaseOrderList;
                    purchaseOrdersListTemporal = dataResponse1["result"].PurchaseOrderList;

                    for(int i = 0; i < purchaseOrdersListTemporal.Count; i++)
                    {
                        if(purchaseOrdersListTemporal[i].StateInput == 0)
                        {
                            purchaseOrdersList.Add(purchaseOrdersListTemporal[i]);
                        }                        
                    }

                    for (int i = 0; i < purchaseOrdersList.Count; i++)
                    {
                        if (purchaseOrdersList[i].StateInput == 1)
                        {
                            purchaseOrdersList.Remove(purchaseOrdersList[i]);
                        }
                    }

                    for (int i = 0; i < purchaseOrdersList.Count; i++)
                    {                             
                            if (purchaseOrdersList[i].OrderDate != null)
                            {
                                DateTime orderDate = DateTime.Parse(purchaseOrdersList[i].OrderDate);
                                purchaseOrdersList[i].OrderDate = orderDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }


                            if (purchaseOrdersList[i].ExpectedDate != null)
                            {
                                DateTime expectedDate = DateTime.Parse(purchaseOrdersList[i].ExpectedDate);
                                purchaseOrdersList[i].ExpectedDate = expectedDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else { purchaseOrdersList[i].ExpectedDate = "----"; }



                            if (purchaseOrdersList[i].ReceiveDate != null)
                            {
                                DateTime receiveDate = DateTime.Parse(purchaseOrdersList[i].ReceiveDate);
                                purchaseOrdersList[i].ReceiveDate = receiveDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else { purchaseOrdersList[i].ReceiveDate = "----"; }



                            if (purchaseOrdersList[i].WaitingDate != null)
                            {
                                DateTime waitingDate = DateTime.Parse(purchaseOrdersList[i].WaitingDate);
                                purchaseOrdersList[i].WaitingDate = waitingDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else { purchaseOrdersList[i].WaitingDate = "----"; }


                            if (purchaseOrdersList[i].CancelDate != null)
                            {
                                DateTime cancelDate = DateTime.Parse(purchaseOrdersList[i].CancelDate);
                                purchaseOrdersList[i].CancelDate = cancelDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else { purchaseOrdersList[i].CancelDate = "----"; }


                            if (purchaseOrdersList[i].PaidDate != null)
                            {
                                DateTime paidDate = DateTime.Parse(purchaseOrdersList[i].PaidDate);
                                purchaseOrdersList[i].PaidDate = paidDate.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else { purchaseOrdersList[i].PaidDate = "----"; }

                            if(purchaseOrdersList[i].State == 4)
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "RECIBIDO / PAGADO";
                            }else
                            {
                                purchaseOrdersList[i].StateColor = "Black";
                                purchaseOrdersList[i].StateName = "RECIBIDO";
                            }

                        
                    }

                    purchaseOrderListBox.ItemsSource = purchaseOrdersList;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PurchaseOrder selectedPurchaseOrder = purchaseOrderListBox.SelectedItem as PurchaseOrder;

                if (selectedPurchaseOrder != null)
                {
                    AddInputForm addInputForm = new AddInputForm(selectedPurchaseOrder);
                    addInputForm.ShowDialog();
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
