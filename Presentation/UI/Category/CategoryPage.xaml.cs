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

namespace Presentation.UI.Category
{
    /// <summary>
    /// Lógica de interacción para CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            LoadCategories();
        }


        private async void LoadCategories()
        {
            CategoryController categoryController = new CategoryController();

            var dataResponse = await categoryController.GetCategories(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                List<CategoryModel> categoryList = dataResponse["result"].CategoryList;
                categoryListBox.ItemsSource = categoryList;
            }
        }



        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            CreateCategoryForm createCategoryForm = new CreateCategoryForm();
            createCategoryForm.ShowDialog();
        }
    }
}
