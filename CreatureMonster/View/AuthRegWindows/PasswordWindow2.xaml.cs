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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CreatureMonster.View.AuthRegWindows
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow2.xaml
    /// </summary>
    public partial class PasswordWindow2 : Window
    {
        public PasswordWindow2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var q = Helpers.BD.entities.Authorization.Where(i => i.Password == PassTb.Text).FirstOrDefault();
            if(q == null)
            {
                t1.Text = "Старый пароль неверный";
            }
            else
            {
                if (NewPassTb.Password == NewPassTb2.Password)
                {
                    Helpers.BD.entities.Authorization.Remove(q);
                    Helpers.BD.entities.SaveChanges();
                    Helpers.Authorization authorization = new Helpers.Authorization()
                    {
                        FCs = "HanXiaok",
                        Nikname = "Han",
                        Password = NewPassTb.Password,
                        Photo = null
                    };
                    Helpers.BD.entities.Authorization.Add(authorization);
                    Helpers.BD.entities.SaveChanges();
                }
            }
        }
    }
}
