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


namespace Presentation.UI.Input
{
    /// <summary>
    /// Lógica de interacción para InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        InputController inputController;
        List<InputModel> inputList;

        public InputPage()
        {
            InitializeComponent();
            LoadInputs();
        }

        private void LoadInputs()
        {
            try
            {
                inputController = new InputController();

                var dataResponse = inputController.GetInputs(UserData.getToken().TokenKey, 0, 1);

                if (dataResponse["ok"])
                {
                    inputList = dataResponse["result"].InputList;
                    inputListBox.ItemsSource = inputList;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }


        private void CreateInput_Click(object sender, RoutedEventArgs e)
        {
           // CreateCategoryForm createCategoryForm = new CreateCategoryForm();
           // createCategoryForm.ShowDialog();
           // LoadCategories();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* string search = txt_search.Text.ToLower();

            int radioActive = 1;
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbName = rb_name.IsChecked.Value; //rbName=true (1)

            if (rbId)
            {
                radioActive = 0;
            }
            else if (rbName)
            {
                radioActive = 1;
            }


            var datatResponse = categoryController.SearchCategoriesAPI(search, radioActive, 1, UserData.getToken().TokenKey);

            if (datatResponse["ok"])
            {
                List<CategoryModel> categoryListFiltered = datatResponse["result"].CategoryList;
                categoryListBox.ItemsSource = categoryListFiltered;
            }
*/
        }


        private void InputListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                InputModel input = inputListBox.SelectedItem as InputModel;

                if (input != null)
                {
                   // UpdateCategoryForm updateCategoryForm = new UpdateCategoryForm(category);
                   // updateCategoryForm.ShowDialog();
                   // LoadCategories();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
