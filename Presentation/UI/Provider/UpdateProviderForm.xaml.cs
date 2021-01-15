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
using System.Text.RegularExpressions;


namespace Presentation.UI.Provider
{
    /// <summary>
    /// Lógica de interacción para UpdateProviderForm.xaml
    /// </summary>
    public partial class UpdateProviderForm : Window
    {
        private ProviderModel provider;

        public UpdateProviderForm()
        {
            InitializeComponent();
        }

        public UpdateProviderForm(ProviderModel provider)
        {
            InitializeComponent();
            this.provider = provider;

            txt_provider_name.Text = provider.Name;
            txt_ruc.Text = provider.Ruc;
            txt_address.Text = provider.Address;
            txt_phone.Text = provider.Phone;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void UpdateProvider_Click(object sender, RoutedEventArgs e)
        {
            if(txt_provider_name.Text.TrimEnd() == "")
            {
                MessageBox.Show("Por favor complete el campo 'Nombre' !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }else
            {
                ProviderController providerController = new ProviderController();
                ProviderModel provider = new ProviderModel();


                provider.ProviderId = this.provider.ProviderId;
                provider.Name = txt_provider_name.Text;
                provider.Ruc = txt_ruc.Text;
                provider.Address = txt_address.Text;
                provider.Phone = txt_phone.Text;
                provider.State = 1;

                var dataResponse = await providerController.UpdateProvider(provider, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El proveedor se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }           
        }
    }
}
