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


namespace Presentation.UI.Input
{
    /// <summary>
    /// Lógica de interacción para addInputForm.xaml
    /// </summary>
    public partial class AddInputForm : Window
    {
        private PurchaseOrder purchaseOrder;
        private PurchaseOrderController purchaseOrderController;

        private List<CommodityModel> commodityList;

        public static List<CommodityModel> selectedUpdateCommodityListDB;
        public static List<CommodityModel> selectedUpdateCommodityList;

        public static List<StoreCommodityModel> storeCommodityList;


        public AddInputForm(PurchaseOrder purchaseOrder)
        {
            InitializeComponent();

            this.purchaseOrder = purchaseOrder;

            purchaseOrderController = new PurchaseOrderController();

            commodityList = new List<CommodityModel>();
            selectedUpdateCommodityList = new List<CommodityModel>();
            selectedUpdateCommodityListDB = new List<CommodityModel>();

            storeCommodityList = new List<StoreCommodityModel>();

            LoadPurchaseOrderDetail();

            cb_provider.Content = "Proveedor:     " +purchaseOrder.ProviderName;


            input_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            txt_total_price.Content = "TOTAL: S/" + Math.Round(purchaseOrder.TotalPrice, 2);


            commodityStoreListBox.ItemsSource = storeCommodityList;

        }

        private async void LoadPurchaseOrderDetail()
        {
            var dataResponse = await purchaseOrderController.GetPurchaseOrderDetail(purchaseOrder.PurchaseOrderId, UserData.getToken().TokenKey, 0, 1);
            if (dataResponse["ok"])
            {
                commodityList = dataResponse["result"].CommodityList;
                commodityListBox.ItemsSource = commodityList;


                selectedUpdateCommodityListDB = commodityList;
                for (int i = 0; i < selectedUpdateCommodityListDB.Count; i++)
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

        private void commodityListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CommodityModel commodity = commodityListBox.SelectedItem as CommodityModel;

                if (commodity != null)
                {
                    TransformCommodityForm transformCommodityForm = new TransformCommodityForm(commodity);
                    transformCommodityForm.ShowDialog();                        

                    commodityStoreListBox.Items.Refresh();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void commodityStoreListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                StoreCommodityModel storeCommodity = commodityStoreListBox.SelectedItem as StoreCommodityModel;

                if (storeCommodity != null)
                {
                    int index = commodityStoreListBox.Items.IndexOf(storeCommodity);
                    EditAddInputForm editAddInputForm = new EditAddInputForm(index, storeCommodity);
                    editAddInputForm.ShowDialog();

                    commodityStoreListBox.Items.Refresh();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
