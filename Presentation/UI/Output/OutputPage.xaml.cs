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


namespace Presentation.UI.Output
{
    /// <summary>
    /// Lógica de interacción para OutputPage.xaml
    /// </summary>
    public partial class OutputPage : Page
    {
        OutputController outputController;
        List<OutputModel> outputList;

        public OutputPage()
        {
            InitializeComponent();
            LoadOutput();
        }

        private void LoadOutput()
        {
            try
            {
                outputController = new OutputController();

                var dataResponse = outputController.GetOutputs(UserData.getToken().TokenKey, 0, 1);

                if (dataResponse["ok"])
                {
                    outputList = dataResponse["result"].OutputList;

                    for (int i = 0; i < outputList.Count; i++)
                    {
                        DateTime orderDate = DateTime.ParseExact(outputList[i].DateOutput, "yyyy-MM-dd hh:mm:ss", null);
                        outputList[i].DateOutput = orderDate.ToString("dd/MM/yyyy hh:mm:ss");
                    }  

                    outputListBox.ItemsSource = outputList;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
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


        private void OutputListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                InputModel input = outputListBox.SelectedItem as InputModel;

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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOutputForm addOutputPage = new AddOutputForm();
            addOutputPage.ShowDialog();

            LoadOutput();
        }
    }
}
