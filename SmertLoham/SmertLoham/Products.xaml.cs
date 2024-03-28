using SmertLoham.BankDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        ProductsTableAdapter adapter = new ProductsTableAdapter();
        public Products()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = adapter.GetData();
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
            adapter.InsertQuery( namee.Text, typee.Text ,Convert.ToInt32(rating.Text));
            SecondGrid.ItemsSource = adapter.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
           

                adapter.UpdateQuery(namee.Text, typee.Text, Convert.ToInt32(rating.Text), Convert.ToInt32(Id));
                SecondGrid.ItemsSource = adapter.GetData();
            
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
                var Name = ((SecondGrid.SelectedItem as DataRowView).Row[1]).ToString(); namee.Text = Name;
                var Surname = ((SecondGrid.SelectedItem as DataRowView).Row[2]).ToString(); typee.Text = Surname;
                var biba = (SecondGrid.SelectedItem as DataRowView).Row[3].ToString(); rating.Text = biba;
            }
        }

        private void namee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(namee.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Имя должно содержать только буквы.");
                namee.Text = "";
            }
        }

        private void typee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(typee.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("typee должно содержать только буквы.");
                typee.Text = "";
            }
        }

        private void rating_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(rating.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("rating должно содержать только цифры.");
                rating.Text = "";
            }
        }

       
    }
}
