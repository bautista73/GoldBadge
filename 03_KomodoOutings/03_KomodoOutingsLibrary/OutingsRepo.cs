using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoOutingsLibrary
{
    public class OutingsRepo
    {
        public List<Outings> _outing = new List<Outings>();

        public List<Outings> GetOutings()
        {
            return _outing;
        }
        public List<Outings> GetListOfOutings() => _outing;

        public void AddOuting(Outings outings)
        {
            _outing.Add(outings);
        }

        public double TotalCostOfAllOutings()
        {
            double totalCost = 0.00d;

            foreach (Outings outing in _outing)
            {
                totalCost += outing.TotalCostEvent;
            }
            return totalCost;
        }

        public double CostByType(Event eventType)
        {
            List<Outings> _outing = OutingByType(eventType);

            double totalCost = 0.0d;

            foreach (Outings outing in _outing)
            {
                totalCost += outing.CostPerPerson;
            }
            return totalCost;
        }

        private List<Outings> OutingByType(Event outingType)
        {
            List<Outings> outingList = new List<Outings>();

            foreach (Outings eventType in _outing)
            {
                if (eventType.Events == outingType)
                {
                    outingList.Add(eventType);
                }
            }
            return (outingList);
        }
    }
}
