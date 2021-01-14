﻿using System;
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
using Domain.Models;
using Domain;
using Presentation.UI.Dashboard;


namespace Presentation.SignIn
{
    /// <summary>
    /// Lógica de interacción para SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void ButtonSignInLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Password;

            if (username.TrimEnd() == "" || password.TrimEnd() == "") 
            {
                _ = MessageBox.Show("Por favor complete todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                Login(username, password);
            }

        }

        private void ButtonSignInClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }



        private async void Login(string username, string password)
        {
            spin.Spin = true;
            spin.Opacity = 100;

            DashboardForm dashBoardForm = new DashboardForm();
            EmployeeController employeeController = new EmployeeController();
            var login = await employeeController.SignIn(username, password);

            spin.Opacity = 0;
            spin.Spin = false;

            if (login["ok"] == true)
            {
                UserData.setEmployee(login["result"].User);
                UserData.setToken(login["token"]);

                dashBoardForm.Show();
                this.Close();
            }
            else
            {
                var message = login["result"];
                _ = MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
