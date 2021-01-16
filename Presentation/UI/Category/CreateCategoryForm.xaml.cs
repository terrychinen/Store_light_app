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

namespace Presentation.UI.Category
{
    /// <summary>
    /// Lógica de interacción para CreateCategoryForm.xaml
    /// </summary>
    public partial class CreateCategoryForm : Window
    {
        public CreateCategoryForm()
        {
            InitializeComponent();
        }


        private async void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryController categoryController = new CategoryController();
            CategoryModel category = new CategoryModel();

           if(txt_category_name.Text.Trim() != "")
            {
                category.Name = txt_category_name.Text;
                category.State = 1;

                var dataResponse = await categoryController.CreateCategory(category, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("La categoría se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Por favor complete el campo 'Nombre' !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
