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

namespace Presentation.UI.Employee
{
    /// <summary>
    /// Lógica de interacción para CreateEmployeeForm.xaml
    /// </summary>
    public partial class CreateEmployeeForm : Window
    {
        public CreateEmployeeForm()
        {
            InitializeComponent();
        }


        private async void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeController employeeController = new EmployeeController();
            EmployeeModel employee = new EmployeeModel();

            if (txt_employee_name.Text.Trim() != null)
            {
                employee.Name = txt_employee_name.Text;
                employee.Username = txt_username.Text;
                employee.Password = txt_password.Text;
                employee.State = 1;

                var dataResponse = await employeeController.CreateEmployee(employee, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El empleado se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
