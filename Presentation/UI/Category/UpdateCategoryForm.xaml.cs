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
    /// Lógica de interacción para UpdateCategoryForm.xaml
    /// </summary>
    public partial class UpdateCategoryForm : Window
    {
        private CategoryModel category;

        public UpdateCategoryForm()
        {
            InitializeComponent();
        }

        public UpdateCategoryForm(CategoryModel category)
        {
            InitializeComponent();
            this.category = category;

            if(category.Name != null || category.Name != "")
            {
                txt_category_name.Text = category.Name;
            }
        }

        private async void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryController categoryController = new CategoryController();
            CategoryModel category = new CategoryModel();

            string categoryName = txt_category_name.Text;

            category.CategoryId = this.category.CategoryId;
            category.Name = categoryName;
            category.State = 1;

            var dataResponse = await categoryController.UpdateCategory(category, UserData.getToken().TokenKey);


            if (dataResponse["ok"])
            {
                MessageBox.Show("La categoría se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
