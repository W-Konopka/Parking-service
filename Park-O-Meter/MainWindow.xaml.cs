using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using FileLibrary;
using System.IO;
using System.Collections.ObjectModel;

namespace Park_O_Meter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> prices = new List<int>();

        // Specify the path for the SQLite database file
        public static string databaseName = "DB.db";
        public static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);

        // Connection string for SQLite
        public static string connectionString = $"Data Source={databasePath};Version=3;";

        


        public MainWindow()
        {
            InitializeComponent();
            clock();
            DatabaseConnection.CreateDatabase(connectionString,databasePath);
            prices = FileSaver.ReadFromXml<int>("Prices.xml");
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool check = true;
            ObservableCollection<Vehicle> parkedVehicles = DatabaseConnection.DataCheck(connectionString);
            Vehicle Vehicle = parkedVehicles.FirstOrDefault(item => item.RegistrationPlate == Registration.Text);
            foreach (var item in parkedVehicles)
            {
                    if (item.RegistrationPlate == Registration.Text)
                    {
                        MessageBox.Show("Vehicle is already parked");
                        check= false;
                    }
                
            }

            if (check)
            {

                if (Registration.Text == "")
                {
                    MessageBox.Show("Type registration number!");
                }
                else
                {
                    if (Motorbike.IsChecked == true)
                    {
                        Vehicle Motorbike = new Vehicle(Registration.Text, DateTime.Now,"Motorbike");
                        
                        DatabaseConnection.AddVehicle(connectionString, Registration.Text, "Motorbike", DateTime.Now);
                        
                    }
                    else if (Car.IsChecked == true)
                    {
                        Vehicle Car = new Vehicle(Registration.Text, DateTime.Now, "Car");
                        
                        DatabaseConnection.AddVehicle(connectionString, Registration.Text, "Car", DateTime.Now);
                        
                    }
                    else if (Bus.IsChecked == true)
                    {
                        Vehicle Bus = new Vehicle(Registration.Text, DateTime.Now, "Bus");
                        DatabaseConnection.AddVehicle(connectionString, Registration.Text, "Bus", DateTime.Now);
                    }
                    else
                    {
                        MessageBox.Show("Select type of vehicle");
                    }
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            
            ObservableCollection<Vehicle> parkedVehicles = DatabaseConnection.DataCheck(connectionString);
            Vehicle Vehicle = parkedVehicles.FirstOrDefault(item => item.RegistrationPlate == Registration.Text);

            if (Vehicle.Type == "Motorbike")
            {
                
                MessageBox.Show($"To pay: {Vehicle.Prices(Vehicle.EntryTime, prices[0])} zł");
                DatabaseConnection.RemoveVehicle(connectionString, Registration.Text);
                
            }
            
            if (Vehicle.Type == "Car")
            {
                MessageBox.Show($"To pay: {Vehicle.Prices(Vehicle.EntryTime, prices[1])} zł");
                DatabaseConnection.RemoveVehicle(connectionString, Registration.Text);
            }
            if (Vehicle.Type == "Bus")
            {
                MessageBox.Show($"To pay: {Vehicle.Prices(Vehicle.EntryTime, prices[2])} zł");
                DatabaseConnection.RemoveVehicle(connectionString, Registration.Text);

            }
        }

        public void clock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
            Application.Current.Shutdown();
        }

        private void CurrentState_Click(object sender, RoutedEventArgs e)
        {
            CurrentState currentState = new CurrentState();
            currentState.ShowDialog();

        }
    }

    
}
