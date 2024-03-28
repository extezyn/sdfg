using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using SmertLoham.BankDataSetTableAdapters;
namespace SmertLoham
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthorizedDataTableAdapter adapter = new AuthorizedDataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == Login.Text && allLogins[i][3].ToString() == Password.Password)
                {
                    int RoleID = (int) allLogins[i][4];

                    switch (RoleID)
                    {
                        case 1: Perevodchik per = new Perevodchik();
                            Close();
                            per.ShowDialog();
                            break;

                        case 2: AdminOknoReal adm = new AdminOknoReal();
                            Close();
                            adm.ShowDialog();
                            break;
                        
                        

                    }
                }
               
            }
            MessageBox.Show("Бам бам");
           
        }

       
    }
}
