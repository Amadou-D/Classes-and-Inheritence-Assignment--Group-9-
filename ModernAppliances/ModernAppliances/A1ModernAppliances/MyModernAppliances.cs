﻿using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Authors: Amadou, Diallo, Alex Lam, Senketh Makala, Group 9</remarks>
    /// Program Description Classes and Inheritence: Our code implements the methods described in the MyModernAppliances Class to complete the ModernAppliances programs functionality. 
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.Write("Enter the item number of an appliance: ");

            long itemNumber;

            string userInput = Console.ReadLine();

            if (long.TryParse(userInput, out itemNumber))
            {
                Appliance foundAppliance = null;

                foreach (Appliance appliance in Appliances)
                {
                    if (appliance.ItemNumber == itemNumber)
                    {
                        foundAppliance = appliance;
                        break;
                    }
                }

                if (foundAppliance == null)
                {
                    Console.WriteLine("No appliances found with that item number.");
                }
                else
                {
                    if (foundAppliance.IsAvailable)
                    {
                        foundAppliance.Checkout();
                        Console.WriteLine($"Appliance \"{foundAppliance.ItemNumber}\" has been checked out.");
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid item number entered.");
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.Write("Enter brand to search for:");

            string brandToSearch;

            brandToSearch = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand.Equals(brandToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    foundAppliances.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Refrigerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");

            int numberOfDoors;

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out numberOfDoors))
            {
                List<Appliance> foundAppliances = new List<Appliance>();

                foreach (Appliance appliance in Appliances)
                {
                    if (appliance is Refrigerator refrigerator)
                    {
                        if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                        {
                            foundAppliances.Add(appliance);
                        }
                    }
                }

                DisplayAppliancesFromList(foundAppliances, 0);
            }
            else
            {
                Console.WriteLine("Invalid input for number of doors.");
            }
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");

            string voltageInput = Console.ReadLine();
            int voltage = 0;

            if (voltageInput == "18")
            {
                voltage = 18;
            }
            else if (voltageInput == "24")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if ((voltage == 0 || voltage == vacuum.BatteryVoltage))
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.Write("Room where the microwave will be installed: K (kitchen) or W (work site):");

            string roomTypeInput = Console.ReadLine();
            char roomType = ' ';

            if (roomTypeInput == "W")
            {
                roomType = 'W';
            }
            else if (roomTypeInput == "K")
            {
                roomType = 'K';
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave microwave)
                {
                    if (microwave.RoomType == roomType)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");

            string soundRatingInput = Console.ReadLine();
            string soundRating = "";

            if (soundRatingInput == "Qt")
            {
                soundRating = "Qt";
            }
            else if (soundRatingInput == "Qr")
            {
                soundRating = "Qr";
            }
            else if (soundRatingInput == "Qu")
            {
                soundRating = "Qu";
            }
            else if (soundRatingInput == "M")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher)
                {
                    if (soundRating == dishwasher.SoundRating)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Generates a random list of appliances
        /// </summary>
        /// <summary>
        /// Generates a random list of appliances
        /// </summary>
        public override void RandomList()
        {
            
            Random random = new Random();

            List<Appliance> foundAppliances = new List<Appliance>();

            Console.Write("Enter number of appliances: ");
            string numInput = Console.ReadLine();

            int num;
            if (int.TryParse(numInput, out num))
            {
                
                if (num < Appliances.Count)
                {
                  
                    List<int> randomPosition = new List<int>();
                    while (randomPosition.Count < num)
                    {
                        int randomIndex = random.Next(Appliances.Count);
                        randomPosition.Add(randomIndex);
                    }

                   
                    foreach (int position in randomPosition)
                   
                    {
                        foundAppliances.Add(Appliances[position]);
                    }

                   
                    DisplayAppliancesFromList(foundAppliances, num);
                }
                else
                {
                    Console.WriteLine("Not enough appliances available");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for the number of appliances.");
            }
        }

    }
}