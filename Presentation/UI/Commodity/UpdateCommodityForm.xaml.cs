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

namespace Presentation.UI.Commodity
{
    /// <summary>
    /// Lógica de interacción para UpdateCommodityForm.xaml
    /// </summary>
    public partial class UpdateCommodityForm : Window
    {
        private CommodityModel commodity;
        

        public UpdateCommodityForm(CommodityModel commodity, List<CategoryModel> categoryList)
        {
            InitializeComponent();

            this.commodity = commodity;

            txt_commodity_name.Text = commodity.Name;

            cb_category.ItemsSource = categoryList;
            cb_category.DisplayMemberPath = "Name";
            cb_category.SelectedValuePath = "CategoryId";

            cb_category.Text = commodity.CategoryName;

        }


        private async void UpdateCommodity_Click(object sender, RoutedEventArgs e)
        {
            CategoryModel category = cb_category.SelectedItem as CategoryModel;

            if (category == null)
            {
                MessageBox.Show("Ingrese una categoría válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (txt_commodity_name.Text.TrimEnd() != "")
                {
                    CommodityController commodityController = new CommodityController();
                    CommodityModel commodity = new CommodityModel();

                    commodity.CommodityId = this.commodity.CommodityId;
                    commodity.CategoryId = category.CategoryId;
                    commodity.Name = txt_commodity_name.Text;
                    commodity.State = 1;

                    var dataResponse = await commodityController.UpdateCommodity(commodity, UserData.getToken().TokenKey);


                    if (dataResponse["ok"])
                    {
                        MessageBox.Show("La mercancía se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete el campo 'Nombre' !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
