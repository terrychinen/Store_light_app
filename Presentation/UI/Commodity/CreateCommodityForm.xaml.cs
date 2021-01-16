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
    /// Lógica de interacción para CreateCommodityForm.xaml
    /// </summary>
    public partial class CreateCommodityForm : Window
    {
        public CreateCommodityForm(List<CategoryModel> categoryList)
        {
            InitializeComponent();

            cb_category.ItemsSource = categoryList;
            cb_category.DisplayMemberPath = "Name";
            cb_category.SelectedValuePath = "CategoryId";

            cb_category.SelectedIndex = 0;
        }
      
      

        private async void CreateCommodity_Click(object sender, RoutedEventArgs e)
        {
            CategoryModel category = cb_category.SelectedItem as CategoryModel;

            if(category == null)
            {
                MessageBox.Show("Ingrese una categoría válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }else
            {
                if (txt_commodity_name.Text.Trim() != "")
                {
                    CommodityController commodityController = new CommodityController();
                    CommodityModel commodity = new CommodityModel();

                    commodity.Name = txt_commodity_name.Text;
                    commodity.CategoryId = category.CategoryId;
                    commodity.State = 1;

                    var dataResponse = await commodityController.CreateCommodity(commodity, UserData.getToken().TokenKey);
                    if (dataResponse["ok"])
                    {
                        MessageBox.Show("La mercancía se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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