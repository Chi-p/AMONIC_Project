using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopApp.Entities
{
    public partial class Schedules
    {
        public decimal BusinessPrice
        {
            get
            {
                return EconomyPrice * (decimal)1.35;
            }
        }

        public decimal FirstClassPrice
        {
            get
            {
                return BusinessPrice * (decimal)1.3;
            }
        }

        public Brush Background
        {
            get
            {
                if (Confirmed == false)
                    return Brushes.Red;
                else
                    return Brushes.White;
            }
        }
        public Brush Foreground
        {
            get
            {
                if (Confirmed == false)
                    return Brushes.White;
                else
                    return Brushes.Black;
            }
        }
    }
}
