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
using System.Windows.Shapes;

namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для AdminOknoReal.xaml
    /// </summary>
    public partial class AdminOknoReal : Window
    {
        public AdminOknoReal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno okno = new Admin_okno();
            okno.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AcountOkno okno = new AcountOkno();
            okno.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AuthorizedOkno okno = new AuthorizedOkno();
            okno.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Products okno = new Products();
            okno.ShowDialog();
        }

        
    }
}
