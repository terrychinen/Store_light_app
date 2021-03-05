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
using Presentation.UI.Commodity_Store;

namespace Presentation.UI.Stock_min
{
    /// <summary>
    /// Lógica de interacción para StockMinPage.xaml
    /// </summary>
    public partial class StockMinPage : Page
    {
        StoreCommodityController storeCommodityController;
        List<StoreCommodityModel> storeCommodityList;

        public StockMinPage()
        {
            InitializeComponent();
            LoadStoresCommodities();
        }


        private async void LoadStoresCommodities()
        {
            storeCommodityController = new StoreCommodityController();

            var dataResponse = await storeCommodityController.GetStoresCommoditiesWithStockMin(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeCommodityList = dataResponse["result"].StoreCommodityList;

                for (int i = 0; i < storeCommodityList.Count; i++)
                {
                    if (storeCommodityList[i].State == 1)
                    {
                        storeCommodityList[i].StateString = "Activo";
                    }
                    else
                    {
                        storeCommodityList[i].StateString = "Inactivo";
                    }
                }

                storeCommodityListBox.ItemsSource = storeCommodityList;
            }
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


    }
}
