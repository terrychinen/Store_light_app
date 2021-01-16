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

namespace Presentation.UI.Store
{
    /// <summary>
    /// Lógica de interacción para CreateStoreForm.xaml
    /// </summary>
    public partial class CreateStoreForm : Window
    {
        public CreateStoreForm()
        {
            InitializeComponent();
        }

        private async void CreateStore_Click(object sender, RoutedEventArgs e)
        {
            StoreController storeController = new StoreController();
            StoreModel store = new StoreModel();


            if (txt_store_name.Text.Trim() != "")
            {
                store.Name = txt_store_name.Text;
                store.State = 1;

                var dataResponse = await storeController.CreateStore(store, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El almacén se creó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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
