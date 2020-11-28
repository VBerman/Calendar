using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Classes
{
    public class Day
    {
        public DateTime Date { get; set; }
        //public BaseDateDefinition {}
        public ObservableCollection<DayEvent> DayEvents { get; set; }
        public List<String> Hours { get; set; } = new List<string>() {"", "00.00", "01.00", "02.00", "03.00", "04.00", "05.00", "06.00", "07.00", "08.00", "09.00", "10.00", "11.00", "12.00", "13.00", "14.00", "15.00", "16.00", "17.00", "18.00", "19.00", "20.00", "21.00", "22.00", "23.00"};

    }
}
