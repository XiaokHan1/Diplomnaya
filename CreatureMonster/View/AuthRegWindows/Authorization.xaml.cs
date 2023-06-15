using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CreatureMonster.View.AuthRegWindows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var qwe = Helpers.BD.entities.Authorization.Where(i => i.Nikname == LogTb.Text && i.Password == PassTb.Password).FirstOrDefault();
            if (qwe == null)
            {
                t1.Text = "Введите логин*";
                t1.Foreground = Brushes.Red;
                t2.Text = "Введите пароль*";
                t2.Foreground = Brushes.Red;
                PassTb.Password = "";
            }
            else
            {
                Helpers.BD.Authorization = qwe;
                Windows.StartsWindow starts = new Windows.StartsWindow();
                starts.Show();
                Close();
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthRegWindows.Registration registration = new Registration();
            registration.Show();
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow password = new PasswordWindow();
            password.Show();
            Close();
        }
    }
}
