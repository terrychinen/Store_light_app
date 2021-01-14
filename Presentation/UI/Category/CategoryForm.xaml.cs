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
    /// Lógica de interacción para CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : Window
    {
        public CategoryForm()
        {
            InitializeComponent();

            LoadCategories();
        }

        private void CloseCategoryForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void LoadCategories()
        {
            CategoryController categoryController = new CategoryController();

            var dataResponse = await categoryController.GetCategories(UserData.getToken().TokenKey, 0, 1);


            if(dataResponse["ok"])
            {
                Console.WriteLine("=============");
                // List<CategoryModel> categoryList = dataResponse["result"].CategoryList;
                List<CategoryModel> categoryList = new List<CategoryModel>();
                categoryList.Add(new CategoryModel() {CategoryId=1, Name="Leche", State=1});
                categoryList.Add(new CategoryModel() { CategoryId=2, Name="Frutas", State = 1 });
                categoryList.Add(new CategoryModel() { CategoryId=3, Name="Envase", State = 1 });

                categoryListBox.ItemsSource = categoryList;
                Console.WriteLine("=============");
            }

            Console.WriteLine("NOPPPPPPPPPPPPPPPPPPPPPPP");
        }
    }
}
