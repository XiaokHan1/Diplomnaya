﻿using System;
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
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = Helpers.BD.entities.Authorization.Where(i => i.FCs == NameTb.Text && i.Nikname == NickTb.Text).FirstOrDefault();
            if(a == null)
            {
                t1.Text = "Проверьте данные*";
            }
            else
            {
                PasswordWindow2 passwordWindow = new PasswordWindow2();
                passwordWindow.Show();
                Close();
            }
        }
    }
}
