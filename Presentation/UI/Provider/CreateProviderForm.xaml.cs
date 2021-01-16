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
using System.Text.RegularExpressions;
using Domain.Controllers;
using Domain;
using Domain.Models;

namespace Presentation.UI.Provider
{
    /// <summary>
    /// Lógica de interacción para CreateProviderForm.xaml
    /// </summary>
    public partial class CreateProviderForm : Window
    {
        public CreateProviderForm()
        {
            InitializeComponent();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void CreateProvider_Click(object sender, RoutedEventArgs e)
        {
            ProviderController providerController = new ProviderController();
            ProviderModel provider = new ProviderModel();

            if (txt_provider_name.Text.Trim() != "")
            {
                provider.Name = txt_provider_name.Text;
                provider.Ruc = txt_ruc.Text;
                provider.Address = txt_address.Text;
                provider.Phone = txt_phone.Text;
                provider.State = 1;


                var dataResponse = await providerController.CreateProvider(provider, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El proveedor se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else
            {
                MessageBox.Show("Por favor complete el campo 'Nombre' !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
