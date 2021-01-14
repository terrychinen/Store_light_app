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
using Presentation.UI.Category;

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
        }


        private async void Category_Click(object sender, RoutedEventArgs e)
        {
            if(!ValidateToken())
            {
                var refreshToken = await tokenController.RefreshToken(UserData.getToken(), UserData.getEmployee().EmployeeId);
                UserData.setToken(refreshToken["result"]);
            }

            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }


        private bool ValidateToken()
        {
            Token token = UserData.getToken();
            tokenController = new TokenController();
            var checkToken = tokenController.ValidateToken(token);

            if (checkToken) {return true;} 
            return false;       
        }
    }
}
