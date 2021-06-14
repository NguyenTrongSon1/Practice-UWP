using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Practice_UWP.Adapters;
using Practice_UWP.Models;
using SQLitePCL;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Practice_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Question2 : Page
    {
        public Question2()
        {
            this.InitializeComponent();
            AddToDatabase(1, "abc");
            AddToDatabase(2, "mothai");
            AddToDatabase(3, "forrest");
        }
        public void AddToDatabase(int id, string password)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "insert into User (id,password) values(?,?)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, id);
            statement.Bind(2, password);
            var rs = statement.Step();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "select * from User where (id = ? and password = ?)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, userBox.Text);
            statement.Bind(2, passwordBox.Password.ToString());
            if (SQLiteResult.ROW == statement.Step())
            {
                successFail.Text = "Login successfully";
                successFail.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                successFail.Text = "Login failed!";
                successFail.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
