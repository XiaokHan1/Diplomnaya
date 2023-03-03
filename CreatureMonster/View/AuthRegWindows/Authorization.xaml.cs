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
            var qwe = Helpers.BD.user.Authorization.Where(i => i.Nickname == LogTb.Text && i.Password == PassTb.Password).FirstOrDefault();
            if (qwe == null)
            {
                t1.Text = "Введите логин*";
                t1.Foreground = Brushes.Red;
                t2.Text = "Введите пароль*";
                t2.Foreground = Brushes.Red;
                
            }
            else
            {
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

        private void TextBlock_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordWindow password = new PasswordWindow();
            password.Show();
            Close();
        }

        private void LogTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            t1.Text = "Введите логин";
            t1.Foreground = Brushes.Black;
            t2.Text = "Введите пароль";
            t2.Foreground = Brushes.Black;
        }

        private void PassTb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            t1.Text = "Введите логин";
            t1.Foreground = Brushes.Black;
            t2.Text = "Введите пароль";
            t2.Foreground = Brushes.Black;
        }
    }
}
