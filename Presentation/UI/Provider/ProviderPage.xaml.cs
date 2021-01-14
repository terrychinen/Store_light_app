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
        public ProviderPage()
        {
            InitializeComponent();

            LoadProviders();
        }

        private async void LoadProviders()
        {
            ProviderController providerController = new ProviderController();

            var dataResponse = await providerController.GetProviders(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                List<ProviderModel> providerList = dataResponse["result"].ProviderList;
                providerListBox.ItemsSource = providerList;
            }
        }
    }
}
