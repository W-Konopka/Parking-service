using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace Park_O_Meter
{
    public class DatabaseConnection
    {
        public static void CreateDatabase(string connectionString, string databasePath)
        {
            if (!File.Exists(databasePath))
            {
                try
                {
                    // Create a new SQLiteConnection using the specified connection string
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();

                        // Create a new SQLiteCommand
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            // SQL command to create a table named 'Users'
                            command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Vehicle (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Type TEXT NOT NULL,
                                RegistrationPlate TEXT NOT NULL UNIQUE,
                                EntryTime DATETIME NOT NULL
                            )";

                            // Execute the SQL command
                            command.ExecuteNonQuery();
                        }

                        // Close the connection
                        connection.Close();
                    }

                    MessageBox.Show("Database created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
          

        }
        public static void AddVehicle(string connectionString, string RegistrationPlate, string Type, DateTime EntryTime)
        {
            try
            {
                string insertStatement = "INSERT INTO Vehicle (Type, RegistrationPlate, EntryTime) VALUES(@Type, @RegistrationPlate, @EntryTime)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(insertStatement, connection))
                    {
                        command.Parameters.AddWithValue("@Type", Type);
                        command.Parameters.AddWithValue("@RegistrationPlate", RegistrationPlate);
                        command.Parameters.AddWithValue("@EntryTime", EntryTime);
 

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show($"Vehicle registered, registration plate: {RegistrationPlate}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static ObservableCollection<Vehicle> DataCheck(string connectionString)
        {
            ObservableCollection<Vehicle> dataItems = new ObservableCollection<Vehicle>();
            try
            {
                string insertStatement = "SELECT * FROM Vehicle";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(insertStatement, connection))
                    {
                        // Execute the SQL command
                        command.ExecuteNonQuery();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string registrationPlate = reader.GetString(reader.GetOrdinal("RegistrationPlate"));
                                DateTime entryTime = reader.GetDateTime(reader.GetOrdinal("EntryTime"));
                                string Type = reader.GetString(reader.GetOrdinal("Type"));

                                dataItems.Add(new Vehicle { RegistrationPlate = registrationPlate, EntryTime = entryTime,Type =Type});
                            }
                         
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dataItems;
        }
        public static void RemoveVehicle(string connectionString, string RegistrationPlate)
        {
            try
            {
                string deleteStatement = "DELETE FROM Vehicle WHERE RegistrationPlate = (@RegistrationPlate)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(deleteStatement, connection))
                    {
                        command.Parameters.AddWithValue("@RegistrationPlate", RegistrationPlate);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Vehicle removed", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
    

}
   


