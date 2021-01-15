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

namespace Presentation.UI.Environment
{
    /// <summary>
    /// Lógica de interacción para CreateEnvironmentForm.xaml
    /// </summary>
    public partial class CreateEnvironmentForm : Window
    {
        public CreateEnvironmentForm()
        {
            InitializeComponent();
        }


        private async void CreateEnvironment_Click(object sender, RoutedEventArgs e)
        {
            EnvironmentController enviromentController = new EnvironmentController();
            EnvironmentModel environment = new EnvironmentModel();

            string environmentName = txt_environment_name.Text;

            environment.Name = environmentName;
            environment.State = 1;

            var dataResponse = await enviromentController.CreateEnvironment(environment, UserData.getToken().TokenKey);


            if (dataResponse["ok"])
            {
                MessageBox.Show("El ambiente se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
