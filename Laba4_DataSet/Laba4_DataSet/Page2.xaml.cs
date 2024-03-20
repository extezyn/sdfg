using System;
using System.Collections.Generic;
using System.Data;
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
using Laba4_DataSet.FitnessClub1DataSetTableAdapters;

namespace Laba4_DataSet
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        TrainersTableAdapter trainers = new TrainersTableAdapter();
        MembersTableAdapter mem = new MembersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            datagrid2.ItemsSource = trainers.GetData();
            CB.ItemsSource = mem.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

                datagrid2.ItemsSource = trainers.SearchByName(SearchBox2.Text);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid2.ItemsSource = trainers.GetData();
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var id = (CB.SelectedItem as DataRowView).Row[1];
            datagrid2.ItemsSource = trainers.FilterByName(id.ToString());
        }
    }
}
