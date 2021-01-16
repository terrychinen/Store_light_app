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
using Domain;
using Domain.Models;
using Domain.Controllers;
using Presentation.UI.Provider;
using Presentation.UI.Environment;
using Presentation.UI.Category;
using Presentation.UI.Home;
using Presentation.UI.Store;
using Presentation.UI.Commodity;
using Presentation.UI.Employee;
using Presentation.UI.Commodity_Store;

namespace Presentation.UI.Dashboard
{
    /// <summary>
    /// Lógica de interacción para DashboardForm.xaml
    /// </summary>
    public partial class DashboardForm : Window
    {
        TokenController tokenController;

        public DashboardForm()
        {
            InitializeComponent();

            tokenController = new TokenController();

            HomePage homePage = new HomePage();
            parent_frame.Navigate(homePage);
        }

      
        private async void Category_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            CategoryPage categoryPage = new CategoryPage();
            parent_frame.Navigate(categoryPage);
        }

         private async void Commodity_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }

            CommodityPage commodityPage = new CommodityPage();
            parent_frame.Navigate(commodityPage);
         }

         private async void Environment_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }

            EnvironmentPage environmentPage = new EnvironmentPage();
            parent_frame.Navigate(environmentPage);
         }


         private async void Store_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }

            StorePage storePage = new StorePage();
            parent_frame.Navigate(storePage);
         }


         private async void Provider_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }
            
            ProviderPage providerPage = new ProviderPage();
            parent_frame.Navigate(providerPage);
         }


         private async void Employee_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }

            EmployeePage employeePage = new EmployeePage();
            parent_frame.Navigate(employeePage);
         }



        private async void Home_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            cleanSelectSubItems();

            HomePage homePage = new HomePage();
            parent_frame.Navigate(homePage);
        }



        private async void CommodityStore_Click(object sender, RoutedEventArgs e)
         {
             if (!ValidateToken())
             {
                 var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                 UserData.setToken(refreshToken["result"]);
             }

            cleanSelectSubItems();

            Commodity_Store_Page commodityStorePage = new Commodity_Store_Page();
            parent_frame.Navigate(commodityStorePage);
         }



        private void cleanSelectSubItems()
        {
            employee_item.IsSelected = false;
            store_item.IsSelected = false;
            category_item.IsSelected = false;
            provider_item.IsSelected = false;
            environment_item.IsSelected = false;
            commodity_item.IsSelected = false;
        }


        private bool ValidateToken()
        {
            return true;
        }

        private void Expander_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
        }
    }
}
