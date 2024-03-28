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
    /// Логика взаимодействия для AuthorizedOkno.xaml
    /// </summary>
    public partial class AuthorizedOkno : Window
    {
        AuthorizedDataTableAdapter adapter = new AuthorizedDataTableAdapter();
        public AuthorizedOkno()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = adapter.GetData();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
            adapter.InsertQuery(Convert.ToInt32(Id), FN.Text, LN.Text, Convert.ToInt32(Id));
            SecondGrid.ItemsSource = adapter.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];
            try
            {
                adapter.UpdateQuery(Convert.ToInt32(Id), FN.Text, LN.Text, Convert.ToInt32(Id), Convert.ToInt32(Id));
                SecondGrid.ItemsSource = adapter.GetData();
            }
            catch (Exception ex) { }
            
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

            var Name = ((SecondGrid.SelectedItem as DataRowView).Row[2]).ToString(); FN.Text = Name;
            var Surname = ((SecondGrid.SelectedItem as DataRowView).Row[3]).ToString(); LN.Text = Surname;
            }
        }

        private void FN_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void LN_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
