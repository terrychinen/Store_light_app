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

namespace Presentation.UI.Employee
{
    /// <summary>
    /// Lógica de interacción para EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeController employeeController;
        List<EmployeeModel> employeeList;

        public EmployeePage()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            employeeController = new EmployeeController();

            var dataResponse = await employeeController.GetEmployees(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                employeeList = dataResponse["result"].EmployeeList;
                employeeListBox.ItemsSource = employeeList;
            }
        }



        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeForm createEmployeeForm = new CreateEmployeeForm();
            createEmployeeForm.ShowDialog();
            LoadEmployees();
        }



        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            int radioActive = 1;
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbName = rb_name.IsChecked.Value; //rbName=true (1)
            bool rbUsername = rb_username.IsChecked.Value; //rbName=true (1)

            if (rbId)
            {
                radioActive = 0;
            }
            else if (rbName)
            {
                radioActive = 1;
            }else if(rbUsername)
            {
                radioActive = 2;
            }

            string search = txt_search.Text.ToLower();
            List<EmployeeModel> employeeListFiltered = employeeController.SearchEmployees(employeeList, search, radioActive);
            employeeListBox.ItemsSource = employeeListFiltered;
        }



        private void EmployeeListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EmployeeModel employee = employeeListBox.SelectedItem as EmployeeModel;

                if (employee != null)
                {
                    UpdateEmployeeForm updateEmployeeForm = new UpdateEmployeeForm(employee);
                    updateEmployeeForm.ShowDialog();
                    LoadEmployees();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
