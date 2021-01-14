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
using Domain.Models;
using Domain;

namespace Presentation.UI.Environment
{
    /// <summary>
    /// Lógica de interacción para EnvironmentPage.xaml
    /// </summary>
    public partial class EnvironmentPage : Page
    {
        public EnvironmentPage()
        {
            InitializeComponent();

            LoadEnvironments();
        }

        private async void LoadEnvironments()
        {
            EnvironmentController environmentController = new EnvironmentController();

            var dataResponse = await environmentController.GetEnviroments(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                List<EnvironmentModel> environmentList = dataResponse["result"].EnvironmentList;
                environmentListBox.ItemsSource = environmentList;
            }
        }
    }
}
