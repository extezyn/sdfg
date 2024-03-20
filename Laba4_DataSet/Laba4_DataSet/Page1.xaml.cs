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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        MembersTableAdapter members = new MembersTableAdapter();
        public Page1()
        {
            InitializeComponent();
            datagrid.ItemsSource = members.GetData();
            CB.ItemsSource = members.GetData();
            CB.DisplayMemberPath = "Email";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                datagrid.ItemsSource = members.SearchByName(SearchBox.Text);
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = members.GetData();
        }

     

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB.SelectedItem != null)
            {
                var id = (CB.SelectedItem as DataRowView).Row[3];
                datagrid.ItemsSource = members.FilterByTrainer(id.ToString());
            }

        }
    }
}
