using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Entities
{
    public partial class Schedules
    {
        public string FlightNumbers
        {
            get
            {
                return "";
            }
        }

        public decimal CabinPrice
        {
            get
            {
                switch (CabinPriceName)
                {
                    case "Economy":
                        return EconomyPrice;
                    case "Business":
                        return EconomyPrice * (decimal)1.35;
                    case "First Class":
                        return EconomyPrice * (decimal)1.35 * (decimal)1.3;
                    default:
                        return 0;
                }
            }
        }
        public string CabinPriceName { get; set; }

        public int NumberOfStops
        {
            get
            {
                return 0;
            }
        }
    }
}
