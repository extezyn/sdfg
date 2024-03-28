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
using SmertLoham.BankDataSetTableAdapters;

namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для Admin_okno.xaml
    /// </summary>
    public partial class Admin_okno : Window
    {
        ClientsTableAdapter adapter = new ClientsTableAdapter();
        public Admin_okno()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = adapter.GetData();
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            
            adapter.InsertQuery(FN.Text, LN.Text, phone.Text, passport.Text, 5);
            SecondGrid.ItemsSource = adapter.GetData();
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object Id = 1;
                Id= (SecondGrid.SelectedItem as DataRowView).Row[0];

            adapter.UpdateQuery(FN.Text, LN.Text, phone.Text, passport.Text,1 ,Convert.ToInt32(Id) );
            SecondGrid.ItemsSource = adapter.GetData();
            }
            catch
            {
                MessageBox.Show("Мимо");
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
           
            if(SecondGrid.SelectedItem != null)
            {

            var Name = ((SecondGrid.SelectedItem as DataRowView).Row[1]).ToString(); 
                FN.Text = Name;
            var Surname = ((SecondGrid.SelectedItem as DataRowView).Row[2]).ToString(); 
                LN.Text = Surname;
            var Phone = ((SecondGrid.SelectedItem as DataRowView).Row[3]).ToString();
                phone.Text = Phone;
            var Passport = ((SecondGrid.SelectedItem as DataRowView).Row[4]).ToString();
                passport.Text = Passport;
            }
            
            }

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            QueriesTableAdapter querry = new QueriesTableAdapter();
            querry.BankBackup();
            MessageBox.Show("Бэкап успешно создан");
        }

        private void FN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(FN.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Имя должно содержать только буквы.");
                FN.Text = "";
            }
        }

        private void LN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(LN.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Фамилия должно содержать только буквы.");
                LN.Text = "";
            }
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(phone.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Телефон должен содержать только цифры.");
                phone.Text = "";
            }
        }

        private void passport_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(passport.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Паспорт должен содержать только цифры.");
                phone.Text = "";
            }
        }
    }
    }
