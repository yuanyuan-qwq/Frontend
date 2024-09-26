using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Model
{
    public class AggregatedData
    {
        public DateTime IntervalStart { get; set; }
        public int TotalQuantity { get; set; }
        public int ParkedCars { get; set; }
        public int RemainingPeople { get; set; }

        public string TimeOnly => IntervalStart.ToString("HH:mm");
    }

}
