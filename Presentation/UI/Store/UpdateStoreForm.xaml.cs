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
    /// Lógica de interacción para UpdateStoreForm.xaml
    /// </summary>
    public partial class UpdateStoreForm : Window
    {
        private StoreModel store;

        public UpdateStoreForm()
        {
            InitializeComponent();
        }

        public UpdateStoreForm(StoreModel store)
        {
            InitializeComponent();
            this.store = store;

            txt_store_name.Text = store.Name;
        }

        private async void UpdateStore_Click(object sender, RoutedEventArgs e)
        {
            StoreController storeController = new StoreController();
            StoreModel store = new StoreModel();

            if (txt_store_name.Text.Trim() != "")
            {
                store.StoreId = this.store.StoreId;
                store.Name = txt_store_name.Text;
                store.State = 1;

                var dataResponse = await storeController.UpdateStore(store, UserData.getToken().TokenKey);


                if (dataResponse["ok"])
                {
                    MessageBox.Show("El almacén se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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
