using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Park_O_Meter
{

    public class Vehicle : ObservableObject
    {
        protected string registrationPlate;

        private DateTime entryTime;

        private string  type;

        public string RegistrationPlate
        {
            get { return registrationPlate; }
            set { registrationPlate = value;
            }
        }

        public DateTime EntryTime
        {
            get { return entryTime; }
            set { entryTime = value;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }

        public Vehicle(string registration, DateTime entryTime, string Type)
        {
            this.registrationPlate = registration;
            this.entryTime = entryTime;
            this.type = Type;
        }
        public Vehicle()
        {
            
        }

        virtual public double Prices(DateTime entryTime, int price)
        {
            TimeSpan interval = DateTime.Now - entryTime;

            return Math.Round(price + (price * interval.TotalHours) * 0.95, 2); ;
        }

    }
}
