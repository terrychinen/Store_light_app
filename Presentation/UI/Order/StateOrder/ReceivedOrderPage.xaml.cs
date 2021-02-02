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

namespace Presentation.UI.Order.StateOrder
{
    /// <summary>
    /// Lógica de interacción para ReceivedOrderPage.xaml
    /// </summary>
    public partial class ReceivedOrderPage : Page
    {
        private PurchaseOrderController purchaseOrderController;
        private List<PurchaseOrder> purchaseOrdersList;

        public ReceivedOrderPage()
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

                if (dataResponse["ok"])
                {
                    purchaseOrdersList = dataResponse["result"].PurchaseOrderList;
                    for (int i = 0; i < purchaseOrdersList.Count; i++)
                    {
                        if (purchaseOrdersList[i].OrderDate != null)
                        {
                            DateTime orderDate = DateTime.ParseExact(purchaseOrdersList[i].OrderDate, "yyyy-MM-dd hh:mm:ss", null);
                            purchaseOrdersList[i].OrderDate = orderDate.ToString("dd/MM/yyyy hh:mm:ss");
                        }


                        if (purchaseOrdersList[i].ExpectedDate != null)
                        {
                            if (purchaseOrdersList[i].ExpectedDate != "0000-00-00 00:00:00" && purchaseOrdersList[i].ExpectedDate != "1969-12-31 07:00:00" && purchaseOrdersList[i].ExpectedDate != "1970-01-01 12:00:00")
                            {
                                DateTime expectedDate = DateTime.ParseExact(purchaseOrdersList[i].ExpectedDate, "yyyy-MM-dd hh:mm:ss", null);
                                purchaseOrdersList[i].ExpectedDate = expectedDate.ToString("dd/MM/yyyy hh:mm:ss");
                            }
                            else { purchaseOrdersList[i].ExpectedDate = "----"; }
                        }
                        else { purchaseOrdersList[i].ExpectedDate = "----"; }


                        purchaseOrdersList[i].StateColor = "Black";
                        purchaseOrdersList[i].StateName = "RECIBIDO / CANCELADO";
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