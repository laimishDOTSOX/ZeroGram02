﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
namespace ZeroGram02
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public MainWindow mainWindow;
        public int ID;
        public Login(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
        }

        public class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public int ID { get; set; }
        }

        private void login_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void login_text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (login_text.Text == "Login") login_text.Text = "";
        }

        private void login_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (login_text.Text == "") login_text.Text = "Login";
        }

        private void password_text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (password_text.Text == "Password") password_text.Text = "";
        }

        private void password_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password_text.Text == "") password_text.Text = "Password";
        }

        private void log_inBTN_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.GetFullPath(@"..\\..\\data\data.xlsx");
            Excel.Application data_applicants = new Excel.Application(); //открыть эксель
            Excel.Workbook WorkBook = data_applicants.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)data_applicants.Sheets[1]; //получить 1 лист
            data_applicants.Visible = false;
            data_applicants.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)WorkBook.Sheets[1];
            string[] titleName = new string[] { "ID:", "Login:", "Password:" };
            string[] search = new string[titleName.Length];

            List<User> users = new List<User>();
            int i = 2;
            while (sheet.Cells[i, 1 ].Text != "")
            {
                users.Add(new User
                {
                    ID = Convert.ToInt32(sheet.Cells[i, 1].Text),
                    Login = sheet.Cells[i, 2].Text,
                    Password = sheet.Cells[i, 3].Text
                }) ;
                i++;
            }

            foreach (var item in users)
            {
                if (item.Login == login_text.Text && item.Password == password_text.Text)
                {
                    WorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
                    data_applicants.Quit(); // выйти из экселя
                    ID = item.ID;
                    User_Info user_Info = new User_Info(mainWindow);
                    user_Info.ID = ID;
                    mainWindow.OpenPage(MainWindow.pages.maininterface);
                }
            }
        }

        private void sign_inBTN_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
    }
}
