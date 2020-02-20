using _02_BadgesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgesUI.UI
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgesRepo = new BadgeRepo();
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        GetAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddABadge()
        {
            List<string> doorsToAccess = new List<string>();
            int idToAdd = 0;

            bool numberNeed = true;
            while (numberNeed)
            {
                Console.Clear();
                Console.WriteLine("What is the number on the badge: ");
                string userID = Console.ReadLine();
                int id;
                Int32.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    idToAdd = id;
                    numberNeed = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }

            bool moreDoor = true;
            while (moreDoor)
            {
                Console.WriteLine("\nWrite a door that it needs access to: ");
                doorsToAccess.Add(Console.ReadLine());

                bool moreQuestion = true;
                while (moreQuestion)
                {
                    Console.WriteLine("\nAny other dooors? (y/n)");
                    string moreInput = Console.ReadLine();
                    switch (moreInput)
                    {
                        case "y":
                            moreQuestion = false;
                            break;
                        case "n":
                            moreDoor = false;
                            moreQuestion = false;
                            break;
                        default:
                            Console.WriteLine("Please type y or n");
                            break;
                    }
                }
            }

            Badge newBadge = new Badge(idToAdd, doorsToAccess);
            _ = _badgesRepo.AddBadgeToRepo(newBadge);
        }

        public void GetAllBadges()
        {
            Console.WriteLine("Key\tDoors");
            Dictionary<int, List<string>> currentList = _badgesRepo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> current in currentList)
            {
                Console.WriteLine($"{current.Key}\t{string.Join(",", current.Value)}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }

        public void UpdateBadge()
        {
            int updateBadge = 0;
            bool numberNeed = true;
            while (numberNeed)
            {
                Console.Clear();
                Console.WriteLine("What badge number would you like to update?");
                string userID = Console.ReadLine();
                int id;
                Int32.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    updateBadge = id;
                    numberNeed = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            Dictionary<int, List<string>> allDoors = _badgesRepo.GetAllBadges();
    


            bool addRemove = true;
            int userChoice = 0;
            while (addRemove)
            {
                Console.Clear();
                Console.WriteLine($"{updateBadge} has {string.Join(",", allDoors[updateBadge])}\n" +
                $"\n What would you like to do?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door\n" +
                $"3. Remove all doors");
                string userID = Console.ReadLine();
                int id;
                Int32.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    userChoice = id;
                    addRemove = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            //Console.WriteLine
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("What door would you like to remove?");
                    string doorToRemove = Console.ReadLine();
                    allDoors[updateBadge].Remove(doorToRemove);
                    break;
                case 2:
                    Console.WriteLine("What door would you like to add?");
                    string doorToAdd = Console.ReadLine();
                    allDoors[updateBadge].Add(doorToAdd);
                    break;
                case 3:
                    Console.WriteLine("Removing all door access");
                    foreach(string door in allDoors[updateBadge])
                    {
                        allDoors[updateBadge].Remove(door);
                    }
                    Console.WriteLine("Access removed");
                    break;
                default:
                    Console.WriteLine("Please enter 1 or 2");
                    break;
            }
            

            //Console.ReadKey();
            //use add to ad one
            //use remove to take out the value from the lsit
        }
    }
}
