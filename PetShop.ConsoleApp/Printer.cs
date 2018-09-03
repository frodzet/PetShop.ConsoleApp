using System;
using System.Collections.Generic;
using System.Globalization;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.ConsoleApp
{
    public class Printer
    {
        private readonly IPetService _petService;
        private readonly List<Pet> listOfPets;

        public Printer(IPetService petService)
        {
            _petService = petService;
            listOfPets = _petService.GetPets();
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Console.WriteLine("Welcome to your favorite Pet Shop.\n\nWhat would you like to do?\n",
                Console.ForegroundColor = ConsoleColor.Blue);

            var menuItems = new List<string>
            {
                "List all pets",
                "Search for a pet",
                "Sort pets by price", // We want a ascending and descending order for this one.
                "Get 5 cheapest pets",
                "Add a pet",
                "Delete a pet",
                "Update pet info",
                "Exit"
            };
            var menuId = 1;

            foreach (var menuItem in menuItems)
                Console.WriteLine("{0} - {1}", menuId++, menuItem, Console.ForegroundColor = ConsoleColor.Green);

            var canSelect = int.TryParse(Console.ReadLine(), out var selection);
            if (canSelect)
                switch (selection)
                {
                    case 1:
                        PrintPets(listOfPets);
                        break;
                    case 2:
                        SearchPets();
                        break;
                    case 3:
                        SortPets();
                        break;
                    case 4:
                        ShowCheapestPets();
                        break;
                    case 5:
                        AddPet();
                        break;
                    case 6:
                        DeletePet();
                        break;
                    case 7:
                        EditPet();
                        break;
                    case 8:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Please select a proper category.");
                        break;
                }
            else
                Console.WriteLine("Please select a proper category.");
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void EditPet()
        {
            var pet = _petService.EditPet(Convert.ToInt32(Console.ReadLine()) - 1);
            SetPetDetails(pet);
            Console.WriteLine("Pet {0} has been successfully changed.", pet.Id);
        }

        private void ShowCheapestPets()
        {
            Console.WriteLine("Here is a list of your 5 cheapest pets.");
            var cheapestPets = _petService.ShowFiveCheapestPets();
            PrintPets(cheapestPets);
        }

        private void SortPets()
        {
            var orderedPets = _petService.OrderPetsListByPrice();
            PrintPets(orderedPets);
        }

        private void DeletePet()
        {
            PrintPets(listOfPets);
            Console.WriteLine("\nDelete pet by Id:");
            var input = Console.ReadLine();
            int parsedInput;
            while (!int.TryParse(input, out parsedInput))
            {
                Console.WriteLine("Delete pet by Id:");
                input = Console.ReadLine();
            }

            _petService.DeletePet(parsedInput);
            Console.WriteLine("Pet with Id {0} has been successfully deleted from the list.", parsedInput);
        }

        private void AddPet()
        {
            var pet = _petService.GetPetInstance();

            SetPetDetails(pet);

            _petService.AddPet(pet);
        }

        private void SetPetDetails(Pet pet)
        {
            Console.WriteLine("Name:");
            pet.Name = Console.ReadLine();

            Console.WriteLine("Type:");
            pet.Type = Console.ReadLine();

            Console.WriteLine("Color:");
            pet.Color = Console.ReadLine();

            Console.WriteLine("Birthdate (yyyy/mm/dd):");
            var birthdate = Console.ReadLine();
            DateTime parsedBirthdate;
            while (!DateTime.TryParse(birthdate, out parsedBirthdate))
            {
                Console.WriteLine("\nWrong format. Try again.\n\nBirthdate (yyyy/mm/dd):");
                birthdate = Console.ReadLine();
            }

            pet.Birthdate = parsedBirthdate;

            Console.WriteLine("Previous owner:");
            var previousOwner = Console.ReadLine();

            Console.WriteLine("Sold (yyyy/mm/dd):");
            var soldDate = Console.ReadLine();
            DateTime parsedSellDate;
            while (!DateTime.TryParse(soldDate, out parsedSellDate))
            {
                Console.WriteLine("\nWrong format. Try again.\n\nSold (yyyy/mm/dd):");
                soldDate = Console.ReadLine();
            }

            pet.SoldDate = parsedSellDate;

            Console.WriteLine("Price:");
            var price = Console.ReadLine();
            double parsedPrice;
            while (!double.TryParse(price, out parsedPrice))
            {
                Console.WriteLine("\nWrong format. Try again.\n\nPrice:");
                price = Console.ReadLine();
            }

            pet.Price = parsedPrice;
        }

        private void SearchPets()
        {
            Console.WriteLine("Search for a pet, either by name or type:");
            var searchedPets = _petService.FindPets(Console.ReadLine());
            PrintPets(searchedPets);
        }

        public void PrintPets(List<Pet> petsList)
        {
            Console.Clear();

            foreach (var pet in petsList)
                Console.WriteLine(
                    "\nID: {0}\n" +
                    "Name: {1}\n" +
                    "Type: {2}\n" +
                    "Color: {3}\n" +
                    "Birthdate: {4}\n" +
                    "Previous owner: {5}\n" +
                    "Sold: {6}\n" +
                    "Price: " + string.Format(CultureInfo.InvariantCulture, "{0:#,#}", pet.Price) + "kr.", pet.Id, pet.Name, pet.Type, pet.Color, pet.Birthdate.ToShortDateString(),
                    pet.PreviousOwner, pet.SoldDate.ToShortDateString());
        }
    }
}