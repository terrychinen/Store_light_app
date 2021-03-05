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
using System.Globalization;


namespace Presentation.UI.Input
{
    /// <summary>
    /// Lógica de interacción para InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        InputController inputController;
        List<InputModel> inputList;

        public InputPage()
        {
            InitializeComponent();

            input_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            LoadInputs();
        }

        private void LoadInputs()
        {
            try
            {
                inputController = new InputController();

                var dataResponse = inputController.GetInputs(UserData.getToken().TokenKey, 0, 1);

                if (dataResponse["ok"])
                {
                    inputList = dataResponse["result"].InputList;
                    for (int i = 0; i < inputList.Count; i++) {
                        DateTime inputDate = DateTime.Parse(inputList[i].InputDate);
                        inputList[i].InputDate = inputDate.ToString("dd/MM/yyyy HH:mm:ss");

                        if(inputList[i].State == 1)
                        {
                            inputList[i].StateName = "Confirmado";
                            inputList[i].StateColor = "Green";
                        }
                        else
                        {
                            inputList[i].StateName = "Anulado";
                            inputList[i].StateColor = "Red";
                        } 
                    }
                    
                    inputListBox.ItemsSource = inputList;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }


        private void InputListBox_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                InputModel input = inputListBox.SelectedItem as InputModel;

                if (input != null)
                {
                    UpdateInputForm updateInputForm = new UpdateInputForm(input);
                    updateInputForm.ShowDialog();
                    LoadInputs();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string search = txt_search.Text.ToLower();

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


            var datatResponse = inputController.SearchInputAPI(search, radioActive, 1, UserData.getToken().TokenKey);

            if (datatResponse["ok"])
            {
                List<InputModel> inputListFiltered = datatResponse["result"].InputList;

                for (int i = 0; i < inputListFiltered.Count; i++)
                {
                    DateTime inputDate = DateTime.Parse(inputList[i].InputDate);
                    inputListFiltered[i].InputDate = inputDate.ToString("dd/MM/yyyy HH:mm:ss");

                    if (inputListFiltered[i].State == 1)
                    {
                        inputListFiltered[i].StateName = "Confirmado";
                        inputListFiltered[i].StateColor = "Green";
                    }
                    else
                    {
                        inputListFiltered[i].StateName = "Anulado";
                        inputListFiltered[i].StateColor = "Red";
                    }
                }

                inputListBox.ItemsSource = inputListFiltered;
            }

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txt_search.Text.ToLower();

            if(search.Length == 0)
            {
                LoadInputs();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {         
            if(input_date.Text.Trim() != "")
            {
                DateTime inputDateTime = DateTime.ParseExact($"{input_date.Text}", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string convertInput = inputDateTime.ToString("yyyy-MM-dd");

                var datatResponse = inputController.SearchInputByDateAPI(convertInput, 1, UserData.getToken().TokenKey);

                if (datatResponse["ok"])
                {
                    List<InputModel> inputListFiltered = datatResponse["result"].InputList;

                    for (int i = 0; i < inputListFiltered.Count; i++)
                    {
                        DateTime inputDate = DateTime.Parse(inputList[i].InputDate);
                        inputListFiltered[i].InputDate = inputDate.ToString("dd/MM/yyyy HH:mm:ss");

                        if (inputListFiltered[i].State == 1)
                        {
                            inputListFiltered[i].StateName = "Confirmado";
                            inputListFiltered[i].StateColor = "Green";
                        }
                        else
                        {
                            inputListFiltered[i].StateName = "Anulado";
                            inputListFiltered[i].StateColor = "Red";
                        }
                    }

                    inputListBox.ItemsSource = inputListFiltered;
                }

            }
            else
            {
                LoadInputs();
            }
        }
    }
}
