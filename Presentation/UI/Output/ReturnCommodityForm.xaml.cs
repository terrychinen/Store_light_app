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


namespace Presentation.UI.Output
{
    /// <summary>
    /// Lógica de interacción para ReturnCommodityPage.xaml
    /// </summary>
    public partial class ReturnCommodityForm : Window
    {
        private OutputModel output;
        private OutputController outputController;


        public ReturnCommodityForm(OutputModel output)
        {
            InitializeComponent();

            this.outputController = new OutputController();
            this.output = output;

            lb_quantity.Content = $"Ha sacado {output.Quantity} - {output.CommodityName}";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+[.[0-9]+]?");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double quantity = Double.Parse(txt_quantity.Text);


                if (quantity <= output.Quantity && quantity >= 0)
                {
                    double leftQuantity = output.Quantity - quantity;
                    var dataResponse = outputController.UpdateStock(output.OutputId, output.StoreId, output.CommodityId, quantity, leftQuantity, "");

                    if (dataResponse["ok"])
                    {
                        MessageBox.Show("La  devolución se actualizó correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + dataResponse["result"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No puede devolver un número mayor de lo que ha sacado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            catch(Exception error)
            {
                MessageBox.Show("Ingrese un formato correcto!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
