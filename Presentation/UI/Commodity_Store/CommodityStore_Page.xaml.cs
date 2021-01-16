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
        CommodityController commodityController;
        List<CommodityModel> commodityList;

        public Commodity_Store_Page()
        {
            InitializeComponent();
            LoadCommodities();
        }

        private async void LoadCommodities()
        {
            commodityController = new CommodityController();

            var dataResponse = await commodityController.GetCommodities(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                commodityList = dataResponse["result"].CommodityList;
                commodityListBox.ItemsSource = commodityList;
            }
        }


        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            int radioActive = 1;
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbName = rb_name.IsChecked.Value; //rbName=true (1)
            bool rbCategory = rb_category.IsChecked.Value; //rbCategory=true (2)


            if (rbId)
            {
                radioActive = 0;
            }
            else if (rbName)
            {
                radioActive = 1;
            }
            else if (rbCategory)
            {
                radioActive = 2;
            }

            string search = txt_search.Text.ToLower();
            List<CommodityModel> commodityListFiltered = commodityController.SearchCommodities(commodityList, search, radioActive);
            commodityListBox.ItemsSource = commodityListFiltered;
        }


        private async void CommodityListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CommodityModel commodity = commodityListBox.SelectedItem as CommodityModel;

                if (commodity != null)
                {
/*                    await LoadCategories();
                    UpdateCommodityForm updateCommodityForm = new UpdateCommodityForm(commodity, categoryList);
                    updateCommodityForm.ShowDialog();*/
                    LoadCommodities();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
