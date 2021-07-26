using _03_KomodoOutingsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoOutings
{
    public class ProgramUI
    {
        private readonly OutingsRepo _outing = new OutingsRepo();

        public bool _isRunning = true;
        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            while(_isRunning == true)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Outings Listing, please select from the menu: \n"+
                                  "1. Display All Outings\n"+
                                  "2. Add an outing event to the list \n"+
                                  "3. Display the cost of all events\n"+
                                  "4. Show event by cost\n"+
                                  "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllOutings();
                        break;
                    case "2":
                        AddEventToList();
                        break;
                    case "3":
                        DisplayEventCost();
                        break;
                    case "4":
                        ShowEventsByCost();
                        break;
                    case "5":
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }               
            }
        }
        public void DisplayAllOutings()
        {
            Console.Clear();

            List<Outings> outingList = _outing.GetOutings();

            foreach (Outings eventList in outingList)
            {
                Console.WriteLine($"Name of event: {eventList.Events}\n" +
                    $"Number of People Attending: {eventList.NumberOfAttendies}\n" +
                    $"Date of event: {eventList.Date}\n" +
                    $"Total Cost of Event: {eventList.CostPerPerson}\n" +
                    $"Total Cost per Person: {eventList.TotalCostEvent}\n");
            }
            Console.WriteLine("Press any key to return to the menu");

            Console.ReadLine();
        }

        public void AddEventToList()
        {
            Console.Clear();

            Outings options = new Outings();

            Console.WriteLine("To add an event, please enter the following details");
            Console.Write("Enter the name of the event: \n" +
                          "Golf / Bowling / AmusmentPark / Concert: ");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "golf":
                    options.Events = Event.Golf;
                    break;
                case "bowling":
                    options.Events = Event.Bowling;
                    break;
                case "amusementpark":
                    options.Events = Event.AmusmentPark;
                    break;
                case "concert":
                    options.Events = Event.Concert;
                    break;
                default:
                    Console.WriteLine("Sorry your input was incorrect or not recognized");
                    break;
            }

            Console.Write("Now, how many people will be attending: ");
            int numberOfAttendies = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a date (ex: 10/22/2020): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("What will be the cost of this event: ");
            double totalCost = Convert.ToDouble(Console.ReadLine());

            double costPerPerson = totalCost / numberOfAttendies;
            Console.WriteLine("The total cost per person will be " + costPerPerson);

            Outings outing = new Outings(options.Events, numberOfAttendies, date, totalCost, costPerPerson);
            _outing.AddOuting(outing);
        }

        public void DisplayEventCost()
        {
            Console.WriteLine($"The total cost of all outings: ${_outing.TotalCostOfAllOutings()}");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowEventsByCost()
        {
            Console.Clear();
            Console.Write("Enter the event type you would like to know the total cost of: ");
            
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "golf":
                    Console.WriteLine($"Total Golf Outing Costs: ${_outing.CostByType(Event.Golf)}");
                    break;
                case "bowling":
                    Console.WriteLine($"Total Bowling Outing Costs: ${_outing.CostByType(Event.Bowling)}");
                    break;
                case "amusementpark":
                    Console.WriteLine($"Total Amusement Park Outing Costs: ${_outing.CostByType(Event.AmusmentPark)}");
                    break;
                case "concert":
                    Console.WriteLine($"Total Concert Outing Costs: ${_outing.CostByType(Event.Concert)}");
                    break;
                default:
                    Console.WriteLine("Invalid input, only enter golf / bowling / amusmentpark / concert");
                    break;
            }

            Console.ReadLine();
        }
    }
}
