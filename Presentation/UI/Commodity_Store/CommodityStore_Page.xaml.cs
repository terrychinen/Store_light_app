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

namespace Presentation.UI.Commodity_Store
{
    /// <summary>
    /// Lógica de interacción para Commodity_Store_Page.xaml
    /// </summary>
    public partial class Commodity_Store_Page : Page
    {
        StoreCommodityController storeCommodityController;
        List<StoreCommodityModel> storeCommodityList;


        public Commodity_Store_Page()
        {
            InitializeComponent();
            LoadStoresCommodities();
        }


        private async void LoadStoresCommodities()
        {
            storeCommodityController = new StoreCommodityController();

            var dataResponse = await storeCommodityController.GetStoresCommodities(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeCommodityList = dataResponse["result"].StoreCommodityList;     
                
                for(int i=0; i<storeCommodityList.Count; i++)
                {
                    if(storeCommodityList[i].State == 1)
                    {
                        storeCommodityList[i].StateString = "Activo";
                    }else
                    {
                        storeCommodityList[i].StateString = "Inactivo";
                    }
                }

                storeCommodityListBox.ItemsSource = storeCommodityList;
            }
        }


        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txt_search.Text.ToLower();

            int radioActive = 1;
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbCommodityName = rb_commodity.IsChecked.Value; //rbCommodityName=true (1)
            bool rbStoreName = rb_store.IsChecked.Value; //rbStore=true (2)


            if (rbId)
            {
                radioActive = 0;
            }
            else if (rbCommodityName)
            {
                radioActive = 1;
            }
            else if (rbStoreName)
            {
                radioActive = 2;
            }

            List<StoreCommodityModel> storeCommodityListFiltered = storeCommodityController.SearchStoreCommodity(storeCommodityList, search, radioActive);
            storeCommodityListBox.ItemsSource = storeCommodityListFiltered;

        }


        private void CommodityListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                StoreCommodityModel storeCommodity = storeCommodityListBox.SelectedItem as StoreCommodityModel;

                if (storeCommodity != null)
                {    
                    UpdateCommodityStoreForm updateCommodityStoreForm = new UpdateCommodityStoreForm(storeCommodity);
                    updateCommodityStoreForm.ShowDialog();
                    LoadStoresCommodities();
                }
                  
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CreateStoreCommodity_Click(object sender, RoutedEventArgs e)
        {
            CreateStoreCommodityForm createStoreCommodityForm = new CreateStoreCommodityForm();
            createStoreCommodityForm.ShowDialog();
            LoadStoresCommodities();
        }
    }
}
