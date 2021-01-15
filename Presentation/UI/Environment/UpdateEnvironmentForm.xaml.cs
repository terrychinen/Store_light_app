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
    /// Lógica de interacción para UpdateEnvironmentForm.xaml
    /// </summary>
    public partial class UpdateEnvironmentForm : Window
    {
        private EnvironmentModel environment;

        public UpdateEnvironmentForm()
        {
            InitializeComponent();
        }

        public UpdateEnvironmentForm(EnvironmentModel environment)
        {
            InitializeComponent();
            this.environment = environment;

            txt_environment_name.Text = environment.Name;
        }

        private async void UpdateEnvironment_Click(object sender, RoutedEventArgs e)
        {
            EnvironmentController enviromentController = new EnvironmentController();
            EnvironmentModel environment = new EnvironmentModel();

            string environmentName = txt_environment_name.Text;

            environment.EnvironmentId = this.environment.EnvironmentId;
            environment.Name = environmentName;
            environment.State = 1;

            var dataResponse = await enviromentController.UpdateEnvironment(environment, UserData.getToken().TokenKey);


            if (dataResponse["ok"])
            {
                MessageBox.Show("El ambiente se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
