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
    /// Lógica de interacción para UpdateCommodityStoreForm.xaml
    /// </summary>
    public partial class UpdateCommodityStoreForm : Window
    {
        StoreCommodityModel storeCommodity;
        StoreCommodityController storeCommodityController;

        public UpdateCommodityStoreForm(StoreCommodityModel storeCommodity)
        {
            InitializeComponent();

            storeCommodityController = new StoreCommodityController();

            this.storeCommodity = storeCommodity;         
            
            if(storeCommodity.State == 1)
            {
                rb_active.IsChecked = true;
            }else
            {
                rb_inactive.IsChecked = true;
            }

            txt_commodity.Content = storeCommodity.CommodityName;
            txt_store.Content = storeCommodity.StoreName;
            txt_stock.Text = storeCommodity.Stock.ToString();
            txt_stock_min.Text = storeCommodity.StockMin.ToString();
        }

        private async void UpdateCommodityStore_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                btn_create.IsEnabled = false;
                bool rbActive = rb_active.IsChecked.Value;

                if (txt_stock.Text.Trim() != "" && txt_stock_min.Text.Trim() != "")
                {
                    if (rbActive) { storeCommodity.State = 1; } else { storeCommodity.State = 0; }

                    storeCommodity.Stock = Double.Parse(txt_stock.Text);
                    storeCommodity.StockMin = Double.Parse(txt_stock_min.Text);
                    var dataResponse = await storeCommodityController.UpdateStoreCommodity(storeCommodity, UserData.getToken().TokenKey);

                    if (dataResponse["ok"])
                    {
                        MessageBox.Show("La asosiación se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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
            catch(Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btn_create.IsEnabled = true;
            }
           


        }
    }
}
