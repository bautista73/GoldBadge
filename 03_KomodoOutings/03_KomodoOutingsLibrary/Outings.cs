using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoOutingsLibrary
{
    public class Outings
    {
        public Event Events { get; set; }
        public int NumberOfAttendies { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostEvent { get; set; }

        public Outings()
        {

        }

        public Outings(Event events, int numberOfAttendies, DateTime date, double costPerPerson, double totalCostEvent)
        {
            Events = events;
            NumberOfAttendies = numberOfAttendies;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCostEvent = totalCostEvent;
        }
    }
    public enum Event { Golf = 1, Bowling, AmusmentPark, Concert }
}
