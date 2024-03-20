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

namespace Laba4_Entity
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private FitnessClub1Entities1 context = new FitnessClub1Entities1();

        public Page2()
        {
        InitializeComponent();
            datagrid2.ItemsSource = context.Trainers.ToList();
            CB2.ItemsSource = context.Trainers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid2.ItemsSource = context.Trainers.ToList().Where(item => item.FirstName.Contains(SearchBox2.Text));
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB2.SelectedItem != null)
            {
                var selected = CB2.SelectedItem as Trainers;
                datagrid2.ItemsSource = (context.Trainers.ToList().Where(item => item == selected));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid2.ItemsSource = context.Trainers.ToList();
        }
    }
}
