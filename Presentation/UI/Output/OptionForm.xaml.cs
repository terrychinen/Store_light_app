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

namespace Presentation.UI.Output
{
    /// <summary>
    /// Lógica de interacción para OptionForm.xaml
    /// </summary>
    public partial class OptionForm : Window
    {
        private OutputModel output;
        private StoreModel store;
        private EnvironmentModel environment;
        private CommodityModel commodity;

        public OptionForm(OutputModel output, StoreModel store, EnvironmentModel environment, CommodityModel commodity)
        {
            InitializeComponent();

            this.output = output;
            this.store = store;
            this.environment = environment;
            this.commodity = commodity;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutputForm updateOutputForm = new UpdateOutputForm(output.OutputId, store, environment, commodity, output.EmployeeGivesId, output.EmployeeReceivesId,
                        output.DateOutput, output.Notes, output.Quantity);
            updateOutputForm.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReturnCommodityForm returnCommodityForm = new ReturnCommodityForm(output);
            returnCommodityForm.ShowDialog();

        }
    }
}
