using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml.Linq;
using SmertLoham.BankDataSetTableAdapters;

namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для Perevodchik.xaml
    /// </summary>
    public partial class Perevodchik : Window
    {
        CheckkTableAdapter adapter = new CheckkTableAdapter();
       
        ClientsTableAdapter acc = new ClientsTableAdapter();
        public Perevodchik()
        {
           
            InitializeComponent();
            dg.ItemsSource = adapter.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adapter.InsertQuery(Convert.ToInt32(Sum.Text), id.Text.ToString(), Convert.ToInt32(Reciever.Text),1);
            MessageBox.Show("Перевод выполнен");
            
            
            // Текст чека
            string receiptText = $@"
Bank prikolov
Кассовый чек №{id.Text}

Получатель: {Reciever.Text}

Сумма перевода: {Sum.Text}

";
            try
            {

            string receiptPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Чек_Номер_{id.Text}.txt");
            File.WriteAllText(receiptPath, receiptText, Encoding.UTF8);
            MessageBox.Show("Ехала, перевод выполнен");
                Console.Beep(789,1000);
            }
            catch {
                MessageBox.Show("бим бим бам бам, чек не создался");
            }
        }

        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (!Regex.IsMatch(id.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("ФИО должно содержать только буквы.");
                id.Text = "";
            }*/
        }

        private void Sum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(Sum.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("rating должно содержать только цифры.");
                Sum.Text = "";
            }
        }

        private void Reciever_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(Reciever.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("rating должно содержать только цифры.");
                Reciever.Text = "";
            }
        }
    }
}
