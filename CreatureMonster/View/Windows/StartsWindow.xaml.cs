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

namespace CreatureMonster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartsWindow.xaml
    /// </summary>
    public partial class StartsWindow : Window
    {
        public StartsWindow()
        {
            InitializeComponent();
            Text1.DataContext = Helpers.BD.user.Authorization.ToList();
            Text2.DataContext = Helpers.BD.user.Authorization.ToList();

            Cmb1.SelectedValuePath= "Id";
            Cmb1.DisplayMemberPath = "Name";
            Cmb1.ItemsSource = Helpers.BD.user.Body.ToList();

            Cmb4.SelectedValuePath = "Id";
            Cmb4.DisplayMemberPath = "Name";
            Cmb4.ItemsSource = Helpers.BD.user.Tail.ToList();

            Cmb2.SelectedValuePath = "Id";
            Cmb2.DisplayMemberPath = "Name";
            Cmb2.ItemsSource = Helpers.BD.user.Head.ToList();

            Cmb3.SelectedValuePath = "Id";
            Cmb3.DisplayMemberPath = "Name";
            Cmb3.ItemsSource = Helpers.BD.user.Legs.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthRegWindows.Authorization authorization = new AuthRegWindows.Authorization();
            authorization.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(NameTb.Text))
                mes += t1.Foreground = Brushes.Red;

            if(mes == null)
            {
                mes = "";
                MessageBox.Show(mes);
                return;
            }
            Models.Creature creature = new Models.Creature()
            {
                Body = Cmb1.SelectedItem as Models.Body,
                Tail = Cmb4.SelectedItem as Models.Tail,
                Head = Cmb2.SelectedItem as Models.Head,
                Legs = Cmb3.SelectedItem as Models.Legs,
                Name_creature = NameTb.Text,
                Id_authorization = 4
            };
            Helpers.BD.user.Creature.Add(creature);
            Helpers.BD.user.SaveChanges();
            MessageBox.Show("Yes");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Pages.ProfilWindow profilWindow = new Pages.ProfilWindow();
            profilWindow.Show();
            Close();
        }
    }
}
