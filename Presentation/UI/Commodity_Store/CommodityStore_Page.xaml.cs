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
using Domain.Models.DataGridModel;

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
                List<StoreCommodityModel> storeCommodityNotRepeatList = new List<StoreCommodityModel>();
                List<string> nameList = new List<string>();

                for(int i=0; i<storeCommodityList.Count(); i++)
                {
                    StoreCommodityModel storeCommodity = storeCommodityList[i];


                    if (nameList.Contains(storeCommodity.CommodityName))
                    {
                        int index = storeCommodityNotRepeatList.FindIndex((sc) =>
                            storeCommodity.CommodityName.Contains(sc.CommodityName)
                        );

                        storeCommodityNotRepeatList[index].StoreName += ", " +storeCommodity.StoreName;
                    }
                    else
                    {
                        nameList.Add(storeCommodity.CommodityName);
                        storeCommodityNotRepeatList.Add(storeCommodity);
                    }              
                }

                /*           storeCommodityList.ForEach((storeCommodity) => {
                               if (nameList.Contains(storeCommodity.CommodityName)) {

                               }else
                               {
                                   nameList.Add(storeCommodity.CommodityName);
                                   newList.Add(storeCommodity);
                               }
                           });    */

                storeCommodityListBox.ItemsSource = storeCommodityNotRepeatList;
            }
        }


        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txt_search.Text.ToLower();
           // List<CommodityModel> commodityListFiltered = storeCommodityController.SearchCommodities(commodityList, search, radioActive);
            // commodityListBox.ItemsSource = commodityListFiltered;
        }


        private async void CommodityListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CommodityModel commodity = storeCommodityListBox.SelectedItem as CommodityModel;

                if (commodity != null)
                {
/*                    await LoadCategories();
                    UpdateCommodityForm updateCommodityForm = new UpdateCommodityForm(commodity, categoryList);
                    updateCommodityForm.ShowDialog();*/
                    LoadStoresCommodities();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
