﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(FcsTb.Text))
                mes += t1.Foreground = Brushes.Red;
            if (string.IsNullOrWhiteSpace(LogTb.Text))
                mes += t2.Foreground = Brushes.Red;
            if (string.IsNullOrWhiteSpace(PassTb.Password))
                mes += t3.Foreground = Brushes.Red;
            if (string.IsNullOrWhiteSpace(PassTb2.Password))
                mes += t4.Foreground = Brushes.Red;

            if (mes != "")
            {
                mes = "";
                return;
            }

            var q = Helpers.BD.user.Authorization.Where(i => i.Nickname == LogTb.Text).FirstOrDefault();
            if (q == null)
            {
                Models.Authorization authorization = new Models.Authorization()
                {
                    FCs = FcsTb.Text,
                    Nickname = LogTb.Text,
                    Password = PassTb.Password,
                    Photo = fot
                };
                Helpers.BD.user.Authorization.Add(authorization);
                Helpers.BD.user.SaveChanges();
                AuthRegWindows.Authorization authorization1 = new Authorization();
                authorization1.Show();
                Close();
            }
            else
            {
                t21.Text = "Придумайте другой логин";
            }
        }

        private void PassTb2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassTb.Password != PassTb2.Password)
            {
                RegBtn.IsEnabled = false;
                PassTb2.Background = Brushes.LightCoral;
                PassTb2.BorderBrush = Brushes.Red;
            }
            else
            {
                RegBtn.IsEnabled = true;
                PassTb2.Background = Brushes.LightGreen;
                PassTb2.BorderBrush = Brushes.Green;
            }
        }

        public byte[] fot;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            var q = openFileDialog.FileName;
            fot = File.ReadAllBytes(q);

        }
    }
}
