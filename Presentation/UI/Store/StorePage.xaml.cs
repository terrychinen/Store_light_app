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

namespace Presentation.UI.Store
{
    /// <summary>
    /// Lógica de interacción para StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        StoreController storeController;
        List<StoreModel> storeList;

        public StorePage()
        {
            InitializeComponent();

            LoadStores();
        }

        private async void LoadStores()
        {
            storeController = new StoreController();

            var dataResponse = await storeController.getStores(UserData.getToken().TokenKey, 0, 1);


            if (dataResponse["ok"])
            {
                storeList = dataResponse["result"].StoreList;
                storeListBox.ItemsSource = storeList;
            }
        }

        private void CreateStore_Click(object sender, RoutedEventArgs e)
        {
            CreateStoreForm createStoreForm = new CreateStoreForm();
            createStoreForm.ShowDialog();
            LoadStores();
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
            List<StoreModel> storeListFiltered = storeController.SearchStores(storeList, search, radioActive);
            storeListBox.ItemsSource = storeListFiltered;
        }


        private void StoreListBox_Click(object sender, MouseButtonEventArgs e)
        {
            StoreModel store = storeListBox.SelectedItem as StoreModel;

            if (store != null)
            {
                UpdateStoreForm updateStoreForm = new UpdateStoreForm(store);
                updateStoreForm.ShowDialog();
                LoadStores();
            }
        }

    }
}
