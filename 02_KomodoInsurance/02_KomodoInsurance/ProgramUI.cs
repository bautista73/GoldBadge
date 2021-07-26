using _02_KomodoInsuranceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoInsurance
{
    class ProgramUI
    {
        BadgesRepo _badgesRepo = new BadgesRepo();

        private bool _isRunning = true;

        public void Run()
        {
            OpenMenu();
        }

        public void OpenMenu()
        {
            bool startingMenu = true;
            while (startingMenu && _isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Insurance Badge System.\n" +
                                  "Please make a selection from the options below\n" +
                                  "1. Add a new badge\n" +
                                  "2. Edit an existing badge\n" +
                                  "3. List all badges\n" +
                                  "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditExistingBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        _isRunning = false;
                        break;
                }
            }
        }

        public void AddNewBadge()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the badge creation section");

            Console.Write("Enter a badge ID: ");
            Badges newBadgeID = new Badges(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter a badge Name: ");
            newBadgeID.Name = Console.ReadLine();

            Console.WriteLine("List all doors this badge requires access to, separating with commas: ");
            newBadgeID.BadgeDoorAccess = Console.ReadLine().Split(',').ToList();

            if (_badgesRepo.CreateBadge(newBadgeID))
            {
                Console.WriteLine("New badge has been created");
            }
            else
            {
                Console.WriteLine("No badge was created");
            }
        }

        public void EditExistingBadge()
        {
            Console.Clear();

            Console.Write("Enter the badge number you would like to edit: ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            _badgesRepo.DisplayBadgeID(badgeNumber);

            Console.WriteLine("Badge edit options:\n" +
                              "1. Add door access\n" +
                              "2. Remove door access\n" +
                              "3. Remove access to all doors\n" +
                              "4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ApplyDoorAccess();
                    break;
                case "2":
                    RemoveDoorAccess();
                    break;
                case "3":
                    Console.WriteLine("Are you sure you want to delete all doors off this badg? (Y / N)");

                    input = Console.ReadLine().ToLower();

                    switch (input)
                    {
                        case "Y":
                            _badgesRepo.DeleteBadgeDoorAccess(badgeNumber);
                            break;
                        case "N":
                            break;
                    }                   
                    break;
                case "4":
                    _isRunning = false;
                    break;
            }


        }

        public List<string> ApplyDoorAccess()
        {
            List<string> doorAccess = new List<string>();

            Console.WriteLine("Enter a new door this badge has access to");

            doorAccess.Add(Console.ReadLine());

            return doorAccess;
        }

        public List<string> RemoveDoorAccess()
        {
            List<string> doorAccess = new List<string>();

            Console.WriteLine("Enter the door you want to remove access to");

            doorAccess.Remove(Console.ReadLine());

            return doorAccess;
        }

        public void ListAllBadges()
        {
            Console.Clear();

            Console.WriteLine("Here are the current badges to display: ");

            Dictionary<int, Badges> badgeList = new Dictionary<int, Badges>();

            Console.WriteLine(badgeList);
        }
    }
}
