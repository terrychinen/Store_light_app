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
        CategoryController categoryController;
        List<CategoryModel> categoryList;

        public CategoryPage()
        {
            InitializeComponent();
            LoadCategories();
        }


        private async void LoadCategories()
        {
            categoryController = new CategoryController();

            var dataResponse = await categoryController.GetCategories(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                categoryList = dataResponse["result"].CategoryList;
                categoryListBox.ItemsSource = categoryList;
            }
        }



        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            CreateCategoryForm createCategoryForm = new CreateCategoryForm();
            createCategoryForm.ShowDialog();
            LoadCategories();
        }





        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            int radioActive = 1;  
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbName = rb_name.IsChecked.Value; //rbName=true (1)

            if(rbId)
            {
                radioActive = 0;
            }
            else if(rbName)
            {
                radioActive = 1;
            }

            string search = txt_search.Text.ToLower();
            List<CategoryModel> categoryListFiltered = categoryController.SearchCategories(categoryList, search, radioActive);
            categoryListBox.ItemsSource = categoryListFiltered;
        }


        private void CategoryListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CategoryModel category = categoryListBox.SelectedItem as CategoryModel;

                if (category != null)
                {
                    UpdateCategoryForm updateCategoryForm = new UpdateCategoryForm(category);
                    updateCategoryForm.ShowDialog();
                    LoadCategories();
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
