using Calendar.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Day> Days { get; set; } = new ObservableCollection<Day>();

        public MainWindow()
        {
            InitializeComponent();
            GenerateWeekFromDay(DateTime.Now);
            //ScrollList.ScrollIntoView(ScrollList.Items[ScrollList.Items.Count - 2]);

            MyScroll.ScrollChanged += ListView_ScrollChanged;
        }

        public void GenerateWeekFromDay(DateTime date)
        {


            for (int i = 1; i < (int)date.DayOfWeek + 1; i++)
            {
                Days.Add(new Day() { Date = date.AddDays(-((int)date.DayOfWeek - i)) });
            }
            var counter = 1;
            for (int i = (int)date.DayOfWeek; i < 7; i++)
            {
                Days.Add(new Day() { Date = date.AddDays(counter) });
                counter++;
            }
        }
        public void GenerateWeekFromDayToBegin(DateTime date)
        {


            for (int i = 1; i < (int)date.DayOfWeek + 1; i++)
            {
                Days.Add(new Day() { Date = date.AddDays(-((int)date.DayOfWeek - i)) });
            }
            var counter = 1;
            for (int i = (int)date.DayOfWeek; i < 7; i++)
            {
                Days.Insert(0, new Day() { Date = date.AddDays(-counter) });
                counter++;
            }
            MyScroll.ScrollToHorizontalOffset(1000);
        }

        private void ListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

            if (Convert.ToInt32(e.ExtentWidth) == Convert.ToInt32(e.HorizontalOffset + e.ViewportWidth) && e.HorizontalChange != 0)
            {
                GenerateWeekFromDay(Days.Last().Date.AddDays(1));
            }
            else if ( Convert.ToInt32(e.ExtentWidth) == Convert.ToInt32(e.HorizontalOffset + e.ViewportWidth) && e.HorizontalChange == 0)
            {

                GenerateWeekFromDayToBegin(Days.First().Date.AddDays(-1));
                
               
                 
            }

        }
    }
}
