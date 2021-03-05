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
    /// Lógica de interacción para EditInputForm.xaml
    /// </summary>
    public partial class UpdateInputForm : Window
    {
        private InputController inputController;
        private PurchaseOrderController purchaseOrderController;

        private List<InputDetailModel> inputDetailList;
        private List<CommodityModel> commodityList;

        public static List<StoreCommodityModel> storeCommodityList;
        public static List<StoreCommodityModel> visualStoreCommodityList;

        public static List<CommodityModel> selectedUpdateCommodityListDB;
        public static List<CommodityModel> selectedUpdateCommodityList;

        private InputModel input;

        public UpdateInputForm(InputModel input)
        {
            InitializeComponent();

            this.input = input;

            inputController = new InputController();
            purchaseOrderController = new PurchaseOrderController();

            selectedUpdateCommodityList = new List<CommodityModel>();
            selectedUpdateCommodityListDB = new List<CommodityModel>();

            storeCommodityList = new List<StoreCommodityModel>();
            visualStoreCommodityList = new List<StoreCommodityModel>();

            txt_message.Text = input.Notes+"";

            input_date.Text = input.InputDate;


            LoadInputDetail();
            LoadPurchaseOrderDetail();          
            
        }

        private async void LoadInputDetail()
        {
            var dataResponse = await inputController.GetInputDetail(input.PurchaseOrderID, UserData.getToken().TokenKey, 0, 1);
            if (dataResponse["ok"])
            {
                inputDetailList = dataResponse["result"].InputDetailList;

                for(int i=0; i<inputDetailList.Count; i++)
                {
                    StoreCommodityModel storeCommodity = new StoreCommodityModel();
                    storeCommodity.CommodityId = inputDetailList[i].CommodityId;
                    storeCommodity.CommodityName = inputDetailList[i].CommodityName;
                    storeCommodity.StoreId = inputDetailList[i].StoreId;
                    storeCommodity.StoreName = inputDetailList[i].StoreName;
                    storeCommodity.Stock = inputDetailList[i].Quantity;
                    storeCommodity.StockTotal = inputDetailList[i].Quantity;
                    storeCommodity.DeleteState = 0;

                    storeCommodityList.Add(storeCommodity);
                    visualStoreCommodityList.Add(storeCommodity);
                }
                                         
                commodityStoreListBox.ItemsSource = visualStoreCommodityList;
            }
        }

        private async void LoadPurchaseOrderDetail()
        {
            var dataResponse = await purchaseOrderController.GetPurchaseOrderDetail(input.PurchaseOrderID, UserData.getToken().TokenKey, 0, 1);
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
                    TransformCommodityForm transformCommodityForm = new TransformCommodityForm(commodity, 1);
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
                    EditAddInputForm editAddInputForm = new EditAddInputForm(index, storeCommodity, 1);
                    editAddInputForm.ShowDialog();

                    commodityStoreListBox.Items.Refresh();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (input_date.Text.Trim() != "")
                {
                    if (storeCommodityList.Count > 0)
                    {
                        DateTime inputDateTime = DateTime.ParseExact($"{input_date.Text}", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        string convertInput = inputDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        InputModel newInput = new InputModel();
                        newInput.PurchaseOrderID = input.PurchaseOrderID;
                        newInput.EmployeeId = UserData.getEmployee().EmployeeId;
                        newInput.InputDate = convertInput;
                        newInput.Notes = txt_message.Text;
                        newInput.State = 1;

                        var dataResponse = await inputController.UpdateInput(newInput, storeCommodityList, UserData.getToken().TokenKey);

                        if (dataResponse["ok"])
                        {
                            MessageBox.Show("La entrada se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese todas las mercancías de su órden de pedido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese una fecha válida !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
