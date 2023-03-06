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

namespace CreatureMonster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilWindow.xaml
    /// </summary>
    public partial class ProfilWindow : Window
    {
        public ProfilWindow()
        {
            InitializeComponent();
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.StartsWindow startsWindow = new Windows.StartsWindow();
            startsWindow.Show();
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            frm1.Navigate(new Histori());
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            frm1.Navigate(new Page1());
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            frm1.Navigate(new AccountPage());
        }
    }
}
