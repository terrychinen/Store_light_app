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
    /// Lógica de interacción para EditAddInputForm.xaml
    /// </summary>
    public partial class EditAddInputForm : Window
    {
        int index; 

        StoreCommodityModel storeCommodity;
        CommodityModel commodity;


        List<StoreModel> storeList;
        List<StoreCommodityModel> storeCommodityList;

        StoreCommodityController storeCommodityController;
        StoreController storeController;
        CommodityController commodityController;

        public EditAddInputForm(int index, StoreCommodityModel storeCommodity)
        {
            InitializeComponent();

            this.index = index;

            this.storeCommodity = storeCommodity;

            this.commodity = new CommodityModel();
            this.commodity.CommodityId = storeCommodity.CommodityId;
            this.commodity.Name = storeCommodity.CommodityName;

            this.storeCommodityList = new List<StoreCommodityModel>();
            this.storeList = new List<StoreModel>();

            this.storeCommodityController = new StoreCommodityController();
            this.storeController = new StoreController();
            this.commodityController = new CommodityController();

            LoadStores();
            LoadCommodities();

            txt_quantity.Text = storeCommodity.Stock.ToString();
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


                for (int i = 0; i < storeList.Count; i++)
                {
                    if (storeList[i].Name == storeCommodity.StoreName)
                    {
                        cb_store.SelectedIndex = i;
                    }
                }


            }
        }


        private void LoadCommodities()
        {
            string commodityName = commodity.Name;
            string[] commodityNameCut = commodityName.Split(' ');
            var dataResponse = storeCommodityController.SearchCommoditiesByStoreID(commodityNameCut[0], storeCommodity.StoreId, UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeCommodityList = dataResponse["result"].StoreCommodityList;
                cb_commodity.ItemsSource = storeCommodityList;

                cb_commodity.DisplayMemberPath = "CommodityName";
                cb_commodity.SelectedValuePath = "CommodityId";

                cb_commodity.SelectedIndex = 0;
                cb_commodity.Text = "No hay datos";
                for (int i = 0; i < storeCommodityList.Count; i++)
                {
                    if (storeCommodityList[i].CommodityName == commodity.Name)
                    {
                        cb_commodity.SelectedIndex = i;
                        break;
                    }                    
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int check = 0;

                if (txt_quantity.Text.Trim() != "")
                {
                    StoreCommodityModel storeCommodity = cb_commodity.SelectedItem as StoreCommodityModel;
                    StoreModel store = cb_store.SelectedItem as StoreModel;

                    if (storeCommodity != null)
                    {
                        for (int i = 0; i < AddInputForm.storeCommodityList.Count; i++)
                        {
                            string commodityName = AddInputForm.storeCommodityList[i].CommodityName;
                            string storeName = AddInputForm.storeCommodityList[i].StoreName;

                            if (storeCommodity.CommodityName == commodityName && store.Name == storeName)
                            {
                                check += 1;
                            }
                        }

                        if (check == 1 || check == 0)
                        {
                            double quantity = double.Parse(txt_quantity.Text);

                            if (quantity > 0)
                            {
                                StoreCommodityModel newStoreCommodity = new StoreCommodityModel();
                                newStoreCommodity.CommodityId = storeCommodity.CommodityId;
                                newStoreCommodity.CommodityName = storeCommodity.CommodityName;
                                newStoreCommodity.StoreId = store.StoreId;
                                newStoreCommodity.StoreName = store.Name;
                                newStoreCommodity.Stock = quantity;

                                AddInputForm.storeCommodityList[index] = newStoreCommodity;

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un número mayor que 0 !");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Ya existe este registro en su conversión, modifique o elimine el que tiene !");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ingrese una mercancía válida");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresee el campo de la cantidad por favor");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cb_store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StoreModel store = cb_store.SelectedItem as StoreModel;
            storeCommodity.StoreId = store.StoreId;
            storeCommodity.StoreName = store.Name;
            LoadCommodities();
        }
      
    }
}
