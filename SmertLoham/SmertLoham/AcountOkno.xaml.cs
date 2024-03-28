using SmertLoham.BankDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Shapes;

namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для AcountOkno.xaml
    /// </summary>
    public partial class AcountOkno : Window
    {
        AccountsTableAdapter adapter = new AccountsTableAdapter();
        public AcountOkno()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = adapter.GetData();

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
            adapter.InsertQuery(Convert.ToInt32(Id), AT.Text, Convert.ToInt32(Balance.Text));
            SecondGrid.ItemsSource = adapter.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
            try
            {

                adapter.UpdateQuery(Convert.ToInt32(Id),AT.Text, Convert.ToInt32(Balance.Text),  Convert.ToInt32(Id));
                SecondGrid.ItemsSource = adapter.GetData();
            }
            catch
            {
                MessageBox.Show("Паспорт не уникальный");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SecondGrid.SelectedItem as DataRowView != null)
                {
                    object id = (SecondGrid.SelectedItem as DataRowView).Row[0];
                    adapter.DeleteQuery(Convert.ToInt32(id));
                    SecondGrid.ItemsSource = adapter.GetData();

                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить так как есьт Внешний ключ");
            }

        }

        private void Vsetablicy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SecondGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SecondGrid.SelectedItem != null)
            {
                var Name = ((SecondGrid.SelectedItem as DataRowView).Row[2]).ToString(); AT.Text = Name;
                var Surname = ((SecondGrid.SelectedItem as DataRowView).Row[3]).ToString(); Balance.Text = Surname;
            }
        }

        private void AT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(AT.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("операция должна содержать только буквы.");
               AT.Text = "";
            }
        }

        private void Balance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(Balance.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("баланс должен содержать только цифры.");
                Balance.Text = "";
            }
        }
    }
}
