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
        EnvironmentController environmentController;
        List<EnvironmentModel> environmentList;

        public EnvironmentPage()
        {
            InitializeComponent();

            LoadEnvironments();
        }

        private async void LoadEnvironments()
        {
            environmentController = new EnvironmentController();

            var dataResponse = await environmentController.GetEnviroments(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                environmentList = dataResponse["result"].EnvironmentList;
                environmentListBox.ItemsSource = environmentList;
            }
        }

        private void CreateEnvironment_Click(object sender, RoutedEventArgs e)
        {
            CreateEnvironmentForm createEnvironmentForm = new CreateEnvironmentForm();
            createEnvironmentForm.ShowDialog();
            LoadEnvironments();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
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

            string search = txt_search.Text.ToLower();
            List<EnvironmentModel> environmentListFiltered = environmentController.SearchEnvironments(environmentList, search, radioActive);
            environmentListBox.ItemsSource = environmentListFiltered;
        }


        private void EnvironmentListBox_Click(object sender, MouseButtonEventArgs e)
        {
            EnvironmentModel environment = environmentListBox.SelectedItem as EnvironmentModel;

            if (environment != null)
            {
                UpdateEnvironmentForm updateEnvironmentForm = new UpdateEnvironmentForm(environment);
                updateEnvironmentForm.ShowDialog();
                LoadEnvironments();
            }
        }
    }
}
