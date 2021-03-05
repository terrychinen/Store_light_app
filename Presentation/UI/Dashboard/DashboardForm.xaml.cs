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
using Presentation.UI.Order;
using Presentation.UI.Order.StateOrder;
using Presentation.UI.Input;
using Presentation.UI.Output;
using Presentation.UI.Stock_min;

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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            cleanOutput();
            cleanSelectOrderSubItems();
            cleanInputOutput();
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

            stock_min_item.IsSelected = false;
            pending_order_item.IsSelected = false;
            purchase_order_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

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

            stock_min_item.IsSelected = false;
            pending_order_item.IsSelected = false;
            purchase_order_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            Commodity_Store_Page commodityStorePage = new Commodity_Store_Page();
            parent_frame.Navigate(commodityStorePage);
         }

        private async void StockMin_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            commodity_store_item.IsSelected = false;
            pending_order_item.IsSelected = false;
            purchase_order_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            StockMinPage stockMin = new StockMinPage();
            parent_frame.Navigate(stockMin);
        }






        private async void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            OrderPage orderPage = new OrderPage();
            parent_frame.Navigate(orderPage);
        }



        private async void PendingOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            PendingOrderPage orderPage = new PendingOrderPage();
            parent_frame.Navigate(orderPage);
        }

        private async void WaitingOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            WaitingOrderPage orderPage = new WaitingOrderPage();
            parent_frame.Navigate(orderPage);
        }

        private async void ReceivedOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            ReceivedOrderPage orderPage = new ReceivedOrderPage();
            parent_frame.Navigate(orderPage);
        }

        private async void PaidOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            PaidOrderPage paidPage = new PaidOrderPage();
            parent_frame.Navigate(paidPage);
        }

        private async void ReceivePaidOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            ReceivePaidOrderPage receivePaidPage = new ReceivePaidOrderPage();
            parent_frame.Navigate(receivePaidPage);
        }

        private async void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanInputOutput();

            CancelOrderPage orderPage = new CancelOrderPage();
            parent_frame.Navigate(orderPage);
        }




        private async void Input_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

              stock_min_item.IsSelected = false;
              commodity_store_item.IsSelected = false;
              home_item.IsSelected = false;
              cleanOutput();
              cleanSelectSubItems();
              cleanSelectOrderSubItems();

             InputPage inputPage = new InputPage();
             parent_frame.Navigate(inputPage);
        }

        private async void Create_Input_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            cleanOutput();
            cleanSelectSubItems();
            cleanSelectOrderSubItems();

            CreateInputPage createInputPage = new CreateInputPage();
            parent_frame.Navigate(createInputPage);
        }

        private async void Output_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            stock_min_item.IsSelected = false;
            commodity_store_item.IsSelected = false;
              home_item.IsSelected = false;
                cleanInputOutput();
              cleanSelectSubItems();
              cleanSelectOrderSubItems();

             OutputPage outputPage = new OutputPage();
             parent_frame.Navigate(outputPage);
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


        private void cleanSelectOrderSubItems()
        {
            cancel_order_item.IsSelected = false;
            received_order_item.IsSelected = false;
            waiting_order_item.IsSelected = false;
            pending_order_item.IsSelected = false;
            paid_order_item.IsSelected = false;
            receive_paid_order_item.IsSelected = false;
            purchase_order_item.IsSelected = false;
        }


        private void cleanInputOutput()
        {
            input_item.IsSelected = false;
            create_input_item.IsSelected = false;          
        }

        private void cleanOutput()
        {
            output_item.IsSelected = false;
        }





        private bool ValidateToken()
        {
            return true;
        }

        private void Expander_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            commodity_store_item.IsSelected = false;
            home_item.IsSelected = false;
            purchase_order_item.IsSelected = false;
        }
    }
}
