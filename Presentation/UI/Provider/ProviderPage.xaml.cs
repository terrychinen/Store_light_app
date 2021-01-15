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

namespace Presentation.UI.Provider
{
    /// <summary>
    /// Lógica de interacción para ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        ProviderController providerController;
        List<ProviderModel> providerList;

        public ProviderPage()
        {
            InitializeComponent();

            LoadProviders();

            rb_name.IsChecked = true;
        }

        private async void LoadProviders()
        {
            providerController = new ProviderController();

            var dataResponse = await providerController.GetProviders(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                providerList = dataResponse["result"].ProviderList;
                providerListBox.ItemsSource = providerList;
            }
        }

        private void CreateProvider_Click(object sender, RoutedEventArgs e)
        {
            CreateProviderForm createProviderForm = new CreateProviderForm();
            createProviderForm.ShowDialog();
            LoadProviders();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            int radioActive = 1;
            bool rbId = rb_id.IsChecked.Value; // rbID=true (0)
            bool rbName = rb_name.IsChecked.Value; //rbName=true (1)
            bool rbRuc = rb_ruc.IsChecked.Value; //rRuc=true (2)
            bool rbAddress = rb_address.IsChecked.Value; //rbAddress=true (3)
            bool rbPhone = rb_phone.IsChecked.Value; //rbPhone=true (4)

            if (rbId)
            {
                radioActive = 0;
            }else if (rbName)
            {
                radioActive = 1;
            }else if (rbRuc)
            {
                radioActive = 2;
            }else if (rbAddress)
            {
                radioActive = 3;
            }else if (rbPhone)
            {
                radioActive = 4;
            }

            string search = txt_search.Text.ToLower();
            List<ProviderModel> providerListFiltered = providerController.SearchProviders(providerList, search, radioActive);
            providerListBox.ItemsSource = providerListFiltered;
        }


        private void ProviderListBox_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                ProviderModel provider = providerListBox.SelectedItem as ProviderModel;

                UpdateProviderForm updateProviderForm = new UpdateProviderForm(provider);
                updateProviderForm.ShowDialog();
                LoadProviders();
            }
        }
    }
}
