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
  
    public partial class Page1 : Page
    {
      private FitnessClub1Entities1 context = new FitnessClub1Entities1();
        public Page1()
        {
            InitializeComponent();
            datagrid.ItemsSource = context.Members.ToList();
            CB.ItemsSource = context.Trainers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = context.Members.ToList().Where(item => item.FirstName.Contains(SearchBox.Text));
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB.SelectedItem != null)
            {
                var selected = CB.SelectedItem as Trainers;
                datagrid.ItemsSource = context.Trainers.ToList().Where(item => item == selected);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = context.Members.ToList();
        }
    }
}
