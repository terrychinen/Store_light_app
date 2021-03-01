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
    /// Lógica de interacción para EditOutputForm.xaml
    /// </summary>
    public partial class UpdateOutputForm : Window
    {
        private StoreCommodityController storeCommodityController;

        private EnvironmentController environmentController;
        private List<EnvironmentModel> environmentList;

        private EmployeeController employeeController;
        private List<EmployeeModel> employeeList;

        private OutputController outputController;
        private double stock = 0.0;

        private EnvironmentModel environment;
        private StoreModel store;
        private CommodityModel commodity;

        private int employeeGivesID;
        private int employeeReceivesID;

        private int outputID;
        private string outputDate;



        public UpdateOutputForm(int outputID, StoreModel store, EnvironmentModel environment, CommodityModel commodity, int employeeGivesID, int employeeReceivesID,  
            string outputDate, string notes, double quantity)
        {
            InitializeComponent();
            outputController = new OutputController();
            this.store = store;
            this.environment = environment;
            this.commodity = commodity;
            this.outputID = outputID;


            cb_store.Text = store.Name;
            cb_commodity.Text = commodity.Name;
            txt_quantity.Text = $"{quantity}";


            cb_environment.DisplayMemberPath = "Name";
            cb_environment.SelectedValuePath = "EnvironmentId";

            cb_employee_gives.DisplayMemberPath = "Username";
            cb_employee_gives.SelectedValuePath = "EmployeeId";

            cb_employee_receives.DisplayMemberPath = "Username";
            cb_employee_receives.SelectedValuePath = "EmployeeId";

            this.employeeGivesID = employeeGivesID;
            this.employeeReceivesID = employeeReceivesID;

            this.outputDate = outputDate;

            txt_message.Text = notes;

            txt_output.Text = outputDate;


            DateTime data = DateTime.ParseExact($"{outputDate}", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);




            LoadEnvironments();
            LoadCommodityStock();
            LoadEmployees();
        }


        private async void LoadEnvironments()
        {
            environmentController = new EnvironmentController();

            var dataResponse = await environmentController.GetEnviroments(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                environmentList = dataResponse["result"].EnvironmentList;
                cb_environment.ItemsSource = environmentList;

                for (int i = 0; i < environmentList.Count; i++)
                {
                    if (environmentList[i].Name == environment.Name)
                    {
                        cb_environment.SelectedIndex = i;
                    }
                }
            }
        }


        private void LoadCommodityStock()
        {
            try
            {
                storeCommodityController = new StoreCommodityController();
                var dataResponse = storeCommodityController.SearchCommoditiesByStoreIDAndCommodityID(store.StoreId, commodity.CommodityId, UserData.getToken().TokenKey);
                List<StoreCommodityModel> storeCommodityList = dataResponse["result"].StoreCommodityList;

                stock = storeCommodityList[0].Stock;

                lb_stock.Content = $"Stock: {stock}";
            } catch (Exception error) {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].EmployeeId == employeeGivesID)
                    {
                        cb_employee_gives.SelectedIndex = i;
                    }

                    if (employeeList[i].EmployeeId == employeeReceivesID)
                    {
                        cb_employee_receives.SelectedIndex = i;
                    }
                }
            }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+[.[0-9]+]?");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                EmployeeModel employeeGivesModel = cb_employee_gives.SelectedItem as EmployeeModel;
                EmployeeModel employeeReceivesModel = cb_employee_receives.SelectedItem as EmployeeModel;
                EnvironmentModel environmetModel = cb_environment.SelectedItem as EnvironmentModel;

                string orderDate = txt_output.Text.Trim().ToString();

                if (employeeGivesModel == null || employeeReceivesModel == null || orderDate == null || orderDate == ""
                    || environmetModel == null)
                {
                    MessageBox.Show("Ingrese una fecha, un ambiente y los empleados válidos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (txt_quantity.Text != null)
                    {
                        double quantity = Double.Parse(txt_quantity.Text);

                        string data = DateTime.ParseExact($"{orderDate}", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                        var dataResponse = outputController.UpdateOutput(outputID, environmetModel.EnvironmentId, employeeGivesModel.EmployeeId, 
                            employeeReceivesModel.EmployeeId, data, txt_message.Text.ToString(), 1, "");

                           if (dataResponse["ok"])
                           {
                               MessageBox.Show("La salida se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                               this.Close();
                           }
                           else
                           {
                               MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                           }
                    }
                    else
                    {
                        MessageBox.Show("Complete el campo cantidad", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

