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
using System.Globalization;

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
            outputController = new OutputController();
            LoadOutput();
        }

        private void LoadOutput()
        {
            try
            {              
                var dataResponse = outputController.GetOutputs(UserData.getToken().TokenKey, 0, 1);

                if (dataResponse["ok"])
                {
                    outputList = dataResponse["result"].OutputList;

                    for (int i = 0; i < outputList.Count; i++)
                    {
                          DateTime orderDate = DateTime.Parse(outputList[i].DateOutput);
                          outputList[i].DateOutput = orderDate.ToString("dd/MM/yyyy HH:mm:ss");
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
            string search = txt_search.Text.ToLower();

            if(search.Trim().Length >= 3)
            {
                int radioActive = 1;
                bool rbCommodity = rb_commodity.IsChecked.Value; // rbCommodity=true (0)
                bool rbEnvironment = rb_environment.IsChecked.Value; //rbEnvironment=true (1)

                if (rbCommodity)
                {
                    radioActive = 0;
                }
                else if (rbEnvironment)
                {
                    radioActive = 1;
                }


                var datatResponse = outputController.SearchOutputAPI(search, radioActive, 1, UserData.getToken().TokenKey);              

                if (datatResponse["ok"])
                {
                    List<OutputModel> outputListFiltered = datatResponse["result"].OutputList;

                    for (int i = 0; i < outputListFiltered.Count; i++)
                    {
                        DateTime orderDate = DateTime.Parse(outputListFiltered[i].DateOutput);
                        outputListFiltered[i].DateOutput = orderDate.ToString("dd/MM/yyyy hh:mm:ss");
                    }

                    outputListBox.ItemsSource = outputListFiltered;
                }
            } else if(search.Trim().Length == 0) {
                LoadOutput();
            } 

          
 
        }


        private void OutputListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OutputModel output = outputListBox.SelectedItem as OutputModel;

                if (output != null)
                {
                    StoreModel store = new StoreModel();
                    store.StoreId = output.StoreId;
                    store.Name = output.StoreName;

                    EnvironmentModel environment = new EnvironmentModel();
                    environment.EnvironmentId = output.EnvironmentId;
                    environment.Name = output.EnvironmentName;

                    CommodityModel commodity = new CommodityModel();
                    commodity.CommodityId = output.CommodityId;
                    commodity.Name = output.CommodityName;


                    OptionForm optionForm = new OptionForm(output, store, environment, commodity);
                    optionForm.ShowDialog();
                    LoadOutput();
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
