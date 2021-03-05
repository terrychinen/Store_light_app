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
    /// Lógica de interacción para TransformCommodityForm.xaml
    /// </summary>
    public partial class TransformCommodityForm : Window
    {
        StoreCommodityModel storeCommodity;
        CommodityModel commodity;


        List<StoreModel> storeList;
        List<StoreCommodityModel> storeCommodityList;

        StoreCommodityController storeCommodityController;
        StoreController storeController;
        CommodityController commodityController;

        int verify;

        public TransformCommodityForm(CommodityModel commodity, int verify)
        {
            InitializeComponent();

            this.commodity = commodity;
            this.verify = verify;

            this.storeCommodity = new StoreCommodityModel();
            this.storeCommodity.CommodityId = commodity.CommodityId;
            this.storeCommodity.CommodityName = commodity.Name;

            this.storeCommodityList = new List<StoreCommodityModel>();
            this.storeList = new List<StoreModel>();

            this.storeCommodityController = new StoreCommodityController();
            this.storeController = new StoreController();
            this.commodityController = new CommodityController();

            cb_commodity.DisplayMemberPath = "Name";
            cb_commodity.SelectedValuePath = "CommodityId";


            LoadStores();           


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

                LoadCommodities();
            }
        }


        private void LoadCommodities()
        {
            StoreModel store = cb_store.SelectedItem as StoreModel;
            string commodityName = commodity.Name;
            string[] commodityNameCut = commodityName.Split(' ');
            var dataResponse = storeCommodityController.SearchCommoditiesByStoreID(commodityNameCut[0], store.StoreId, UserData.getToken().TokenKey, 0, 1);


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
                
                if(txt_quantity.Text.Trim() != "")
                {
                    StoreCommodityModel commodity = cb_commodity.SelectedItem as StoreCommodityModel;
                    StoreModel store = cb_store.SelectedItem as StoreModel;

                    if (commodity != null)
                    {                 
                        if(verify == 0)
                        {
                            for (int i = 0; i < AddInputForm.storeCommodityList.Count; i++)
                            {
                                string commodityName = AddInputForm.storeCommodityList[i].CommodityName;
                                string storeName = AddInputForm.storeCommodityList[i].StoreName;

                                if (commodity.CommodityName == commodityName && store.Name == storeName)
                                {
                                    check = 1;
                                }
                            }
                        }else
                        {
                            for (int i = 0; i < UpdateInputForm.storeCommodityList.Count; i++)
                            {
                                string commodityName = UpdateInputForm.storeCommodityList[i].CommodityName;
                                string storeName = UpdateInputForm.storeCommodityList[i].StoreName;

                                if (commodity.CommodityName == commodityName && store.Name == storeName)
                                {
                                    check = 1;
                                }
                            }
                        }
                       

                        if(check == 0)
                        {
                            double quantity = double.Parse(txt_quantity.Text);

                            if(quantity > 0)
                            {
                                StoreCommodityModel newStoreCommodity = new StoreCommodityModel();
                                newStoreCommodity.CommodityId = commodity.CommodityId;
                                newStoreCommodity.CommodityName = commodity.CommodityName;
                                newStoreCommodity.StoreId = store.StoreId;
                                newStoreCommodity.StoreName = store.Name;
                                newStoreCommodity.Stock = quantity;

                                if(verify == 0)
                                {
                                    AddInputForm.storeCommodityList.Add(newStoreCommodity);
                                }else
                                {
                                    UpdateInputForm.visualStoreCommodityList.Add(newStoreCommodity);
                                    UpdateInputForm.storeCommodityList.Add(newStoreCommodity);
                                }                               

                                this.Close();
                            }else
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
                } else
                {
                    MessageBox.Show("Ingresee el campo de la cantidad por favor");
                }               
            }catch(Exception error)
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
