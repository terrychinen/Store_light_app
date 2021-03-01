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

namespace Presentation.UI.Commodity_Store
{
    /// <summary>
    /// Lógica de interacción para CreateStoreCommodityForm.xaml
    /// </summary>
    public partial class CreateStoreCommodityForm : Window
    {
        StoreCommodityModel storeCommodity;
        StoreCommodityController storeCommodityController;

        StoreController storeController;
        List<StoreModel> storeList;

        CommodityController commodityController;
        List<CommodityModel> commodityList;


        public CreateStoreCommodityForm()
        {
            InitializeComponent();

            storeCommodityController = new StoreCommodityController();
            storeController = new StoreController();
            storeCommodity = new StoreCommodityModel();

            commodityList = new List<CommodityModel>();
            commodityController = new CommodityController();

            LoadStores();
            LoadCommodities();
        }

        private async void LoadStores()
        {
            var dataResponse = await storeController.getStores(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeList = dataResponse["result"].StoreList;
                cb_store.ItemsSource = storeList;

                cb_store.DisplayMemberPath = "Name";
                cb_store.SelectedValuePath = "StoreId";

                cb_store.SelectedIndex = 0;
            }
        }


        private async void LoadCommodities()
        {
            var dataResponse = await commodityController.GetCommodities(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                commodityList = dataResponse["result"].CommodityList;
                cb_commodity.ItemsSource = commodityList;

                cb_commodity.DisplayMemberPath = "Name";
                cb_commodity.SelectedValuePath = "CommodityId";

                cb_commodity.SelectedIndex = 0;
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btn_create.IsEnabled = false;

                bool rbActive = rb_active.IsChecked.Value;

                StoreModel store = cb_store.SelectedItem as StoreModel;
                CommodityModel commodity = cb_commodity.SelectedItem as CommodityModel;

                if (store == null || commodity == null)
                {
                    MessageBox.Show("Ingrese un almaén y una mercancía válida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    btn_create.IsEnabled = true;
                }
                else
                {
                    if (txt_stock.Text.Trim() != "" && txt_stock_min.Text.Trim() != "")
                    {
                        if (rbActive)
                        {
                            storeCommodity.State = 1;
                        }
                        else
                        {
                            storeCommodity.State = 0;
                        }

                        storeCommodity.Stock = Double.Parse(txt_stock.Text);
                        storeCommodity.StockMin = Double.Parse(txt_stock_min.Text);
                        storeCommodity.StoreId = store.StoreId;
                        storeCommodity.CommodityId = commodity.CommodityId;
                        var dataResponse = await storeCommodityController.CreateStoreCommodity(storeCommodity, UserData.getToken().TokenKey);

                        if (dataResponse["ok"])
                        {
                            MessageBox.Show("La asosiación se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                            btn_create.IsEnabled = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            btn_create.IsEnabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete el campo 'Stock' - 'Stock min' !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        btn_create.IsEnabled = true;
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btn_create.IsEnabled = true;
            }
           
        }     

    }
}
