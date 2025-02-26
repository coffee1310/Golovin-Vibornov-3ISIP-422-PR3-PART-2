using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _3ISIP_422_Vybornov_Golovin_PR3._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandManager.AddPreviewExecutedHandler(hours, OnPreviewExecuted);
        }

        private void OnPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true; 
            }
        }

        private void hours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (rad1.IsChecked == false && rad2.IsChecked == false && rad3.IsChecked == false)
            {
                MessageBox.Show("Выберите должность преподавателя!");
                return;
            }


            if (!int.TryParse(hours.Text, out int hour) || hour <= 0)
            {
                MessageBox.Show("Введите количество часов!");
                return;
            }

            int price = 0;

            if (rad1.IsChecked == true)
            {
                price = 150;
            }
            else if (rad2.IsChecked == true)
            {
                price = 250;
            }
            else if (rad3.IsChecked==true)
            {
                price = 350;
            }

            double salary = price * hour;
            double tax;

            if (hour <= 10000)
            {

                if (check_tax.IsChecked == true)
                {
                    tax = salary * 0.13;
                    salary -= tax;
                    salarybox.Text = salary.ToString();
                    taxbox.Text = tax.ToString();
                }
                salarybox.Text = salary.ToString();
            }
            else
            {
                MessageBox.Show("Слишком большое значение!");
                return;
            }
        }
    }
}
