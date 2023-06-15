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
using System.Windows.Threading;

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

            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { TimeT.Content = DateTime.Now.ToString("HH:mm:ss"); };
            timer.Tick += (o, e) => { TimeY.Content = DateTime.Now.ToString("dd MMMM yyyy"); };
            timer.Start();

            Cmb1.ItemsSource = Helpers.BD.entities.Body.ToList();

            Cmb4.SelectedValuePath = "Id";
            Cmb4.DisplayMemberPath = "Name";
            Cmb4.ItemsSource = Helpers.BD.entities.Tail.ToList();

            Cmb2.SelectedValuePath = "Id";
            Cmb2.DisplayMemberPath = "Name";
            Cmb2.ItemsSource = Helpers.BD.entities.Head.ToList();

            Cmb3.SelectedValuePath = "Id";
            Cmb3.DisplayMemberPath = "Name";
            Cmb3.ItemsSource = Helpers.BD.entities.Legs.ToList();
            this.DataContext = Helpers.BD.Authorization;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

            if(mes != "")
            {
                mes = "";
                return;
            }
            Helpers.Creature creature = new Helpers.Creature()
            {
                Body = Cmb1.SelectedItem as Helpers.Body,
                Tail = Cmb4.SelectedItem as Helpers.Tail,
                Head = Cmb2.SelectedItem as Helpers.Head,
                Legs = Cmb3.SelectedItem as Helpers.Legs,
                Name_creature = NameTb.Text,
                Id_authorization = 4
            };
            Helpers.BD.entities.Creature.Add(creature);
            Helpers.BD.entities.SaveChanges();
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
