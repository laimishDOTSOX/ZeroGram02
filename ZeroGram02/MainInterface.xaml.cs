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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeroGram02
{
    /// <summary>
    /// Логика взаимодействия для mainInterface.xaml
    /// </summary>
    public partial class mainInterface : Page
    {
        public MainWindow mainWindow;
        public int ID;
        public mainInterface(MainWindow _mainWindow, int id)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            ZeroTwo.Height += 100;
            ID = id;
        }

        private void UserMenu_Click(object sender, RoutedEventArgs e)
        {
            //User_Info user_Info = new User_Info(mainWindow, ID);
            mainWindow.OpenPage(MainWindow.pages.user_info, ID);
        }

        private void Mob_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (hp.Value != 0) hp.Value -= 10;
            else hp.Value = 100;
        }

        private void ZeroTwoDancing_MediaEnded(object sender, RoutedEventArgs e)
        {
            ZeroTwoDancing.Play();
        }
    }
}
