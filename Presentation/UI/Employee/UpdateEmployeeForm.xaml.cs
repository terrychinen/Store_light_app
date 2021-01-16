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
    /// Lógica de interacción para UpdateEmployeeForm.xaml
    /// </summary>
    public partial class UpdateEmployeeForm : Window
    {
        private EmployeeModel employee;

        public UpdateEmployeeForm(EmployeeModel employee)
        {
            InitializeComponent();

            this.employee = employee;

            txt_employee_name.Text = employee.Name;
            txt_username.Text = employee.Username;
        }


        private async void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeController employeeController = new EmployeeController();
            EmployeeModel employee = new EmployeeModel();

            if (txt_employee_name.Text.Trim() != "")
            {
                employee.EmployeeId = this.employee.EmployeeId;
                employee.Name = txt_employee_name.Text;
                employee.Username = txt_username.Text;
                employee.State = 1;

                var dataResponse = await employeeController.UpdateEmployee(employee, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El empleado se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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
