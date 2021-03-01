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
using System.Text.RegularExpressions;
using System.Globalization;



namespace Presentation.UI.Output
{
    /// <summary>
    /// Lógica de interacción para AddOutputForm.xaml
    /// </summary>
    public partial class AddOutputForm : Window
    {
        private StoreController storeController;
        private List<StoreModel> storeList;

        private EnvironmentController environmentController;
        private List<EnvironmentModel> environmentList;

        private StoreCommodityController storeCommodityController;
        //  private List<StoreCommodityModel> storeCommodityList;

        private EmployeeController employeeController;
        private List<EmployeeModel> employeeList;

        private OutputController outputController;

        private double stock = 0.0;

        public AddOutputForm()
        {
            InitializeComponent();

            outputController = new OutputController();


            txt_order.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            //txt_date.Texx = DateTim                

            cb_store.DisplayMemberPath = "Name";
            cb_store.SelectedValuePath = "StoreId";

            cb_environment.DisplayMemberPath = "Name";
            cb_environment.SelectedValuePath = "EnvironmentId";

            cb_commodity.DisplayMemberPath = "CommodityName";
            cb_commodity.SelectedValuePath = "CommodityId";

            cb_employee_gives.DisplayMemberPath = "Username";
            cb_employee_gives.SelectedValuePath = "EmployeeId";

            cb_employee_receives.DisplayMemberPath = "Username";
            cb_employee_receives.SelectedValuePath = "EmployeeId";

            LoadStores();
            LoadEnvironments();
            LoadEmployees();

            storeCommodityController = new StoreCommodityController();

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+[.[0-9]+]?");
            e.Handled = regex.IsMatch(e.Text);
        }


        private async void LoadStores()
        {
            storeController = new StoreController();

            var dataResponse = await storeController.getStores(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeList = dataResponse["result"].StoreList;
                cb_store.ItemsSource = storeList;
            }
        }


        private async void LoadEnvironments()
        {
            environmentController = new EnvironmentController();

            var dataResponse = await environmentController.GetEnviroments(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                environmentList = dataResponse["result"].EnvironmentList;
                cb_environment.ItemsSource = environmentList;
            }
        }


        private async void LoadEmployees()
        {
            employeeController = new EmployeeController();

            var dataResponse = await employeeController.GetEmployees(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                employeeList = dataResponse["result"].EmployeeList;
                cb_employee_gives.ItemsSource = employeeList;
                cb_employee_receives.ItemsSource = employeeList;
            }
        }




        private void cb_commodity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                StoreModel store = cb_store.SelectedItem as StoreModel;

                if (cb_store.Text.Trim() == null || store == null)
                {
                    MessageBox.Show("Ingrese un almacén válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else
                {
                    if (cb_commodity.Text.Trim().Length >= 2)
                    {
                        var dataResponse = storeCommodityController.SearchCommoditiesByStoreID(cb_commodity.Text, store.StoreId, UserData.getToken().TokenKey, 0, 1);
                        cb_commodity.ItemsSource = dataResponse["result"].StoreCommodityList;

                        lb_stock.Content = $"Stock: ";

                    }

                    else if (cb_commodity.Text.Trim().Length <= 2)
                    {
                        cb_commodity.ItemsSource = null;
                        cb_commodity.IsDropDownOpen = false;
                        lb_stock.Content = $"Stock: ";
                    }
                }


            }
            catch (Exception error)
            {

            }
        }


        private void cb_commodity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                cb_commodity.IsDropDownOpen = true;
                cb_commodity.SelectedItem = true;

                StoreCommodityModel storeCommodity = cb_commodity.SelectedItem as StoreCommodityModel;
                if (cb_commodity.Text.Trim() == null || storeCommodity == null)
                {
                    lb_stock.Content = $"Stock: ";
                    stock = 0;
                }
                else
                {
                    stock = storeCommodity.Stock;                      
                    lb_stock.Content = $"Stock: {stock}";
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StoreModel store = cb_store.SelectedItem as StoreModel;
                EnvironmentModel environment = cb_environment.SelectedItem as EnvironmentModel;
                StoreCommodityModel storeCommodity = cb_commodity.SelectedItem as StoreCommodityModel;

                EmployeeModel employeeGives = cb_employee_gives.SelectedItem as EmployeeModel;
                EmployeeModel employeeReceives = cb_employee_receives.SelectedItem as EmployeeModel;

                string orderDate = txt_order.Text.Trim().ToString();


                if (storeCommodity == null || store == null || environment == null || employeeGives == null || employeeReceives == null ||
                    orderDate == null || orderDate == "")
                {
                    MessageBox.Show("Ingrese un almaén, mercancía, ambiente, fecha y empleados válidos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (txt_quantity.Text != null)
                    {
                        double quantity = Double.Parse(txt_quantity.Text);
                        if (stock >= quantity)
                        {
                            string data = DateTime.ParseExact($"{txt_order.Text}", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                            var dataResponse = outputController.CreateOutput(store.StoreId, environment.EnvironmentId, 
                                    storeCommodity.CommodityId, quantity, employeeGives.EmployeeId, employeeReceives.EmployeeId, data, 
                                    txt_message.Text.ToString(), 1, UserData.getToken().TokenKey);

                            if (dataResponse["ok"])
                            {
                                MessageBox.Show("La salida se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad tiene que ser menor o igual que el stock", "Error", MessageBoxButton.OK, MessageBoxImage.Error);                            
                        }

                    }
                    else
                    {
                        MessageBox.Show("Complete el campo cantidad", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
