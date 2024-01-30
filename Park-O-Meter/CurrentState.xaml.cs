using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;


namespace Park_O_Meter
{
   
    public partial class CurrentState : Window
    {
        MainWindow MainWindow = new MainWindow();
        // Specify the path for the SQLite database file
        public static string databaseName = "DB.db";
        public static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);

        // Connection string for SQLite
        public string connectionString = $"Data Source={databasePath};Version=3;";


        public CurrentState()
        {

            InitializeComponent();

        }
        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListView.ItemsSource = DatabaseConnection.DataCheck(connectionString);
        }
    }
}
