using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static List<Pet> Pets;

        public static int PetId { get; set; }
        private static Random r = new Random();

        public static void InitData()
        {
            PetId = 1;
            Pets = new List<Pet>();
            for (int i = 0; i < 50; i++)
            {
                var pet = new Pet();
                pet.Id = PetId++;
                pet.Name = GenerateName(12);
                pet.Type = GenerateType();
                pet.Color = GenerateColor();
                pet.Birthdate = GenerateDate(new DateTime(1990, 1, 1));
                pet.PreviousOwner = GenerateName(12);
                pet.SoldDate = GenerateDate(pet.Birthdate);

                pet.Price = GeneratePrice(pet.Type);
                Pets.Add(pet);

            }
        }

        private static string GenerateName(int maxLength)
        {
            string[] consonants = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "w", "x"};
            string[] vowels = {"a", "e", "i", "o", "u", "y"};

            string name = "";
            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < r.Next(maxLength))
            {
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return name;
        }

        private static string GenerateType()
        {
            string[] petType = { "Dog", "Cat", "Whale", "Fish", "Snake", "Bear", "Rabbit", "Bird", "Goat", "Pig" };

            int len = r.Next(petType.Length);

            return petType[len];
        }

        private static string GenerateColor()
        {
            string[] petColor = { "Black", "Brown", "Red", "White with Black stribes", "Pink", "Purple", "Blue", "Yellow" };

            int len = r.Next(petColor.Length);

            return petColor[len];
        }

        private static double GeneratePrice(string petType)
        {
            int minPrice = 0;
            int maxPrice = 0;
            switch (petType)
            {
                case "Dog":
                    minPrice = 500;
                    maxPrice = 25000;
                    break;
                case "Cat":
                    minPrice = 100;
                    maxPrice = 5000;
                    break;
                case "Whale":
                    minPrice = 15000;
                    maxPrice = 5000000;
                    break;
                case "Fish":
                    minPrice = 20;
                    maxPrice = 1000;
                    break;
                case "Snake":
                    minPrice = 200;
                    maxPrice = 8000;
                    break;
                case "Bear":
                    minPrice = 5000;
                    maxPrice = 500000;
                    break;
                case "Rabbit":
                    minPrice = 50;
                    maxPrice = 2500;
                    break;
                case "Bird":
                    minPrice = 50;
                    maxPrice = 800;
                    break;
                case "Goat":
                    minPrice = 200;
                    maxPrice = 12000;
                    break;
                case "Pig":
                    minPrice = 1200;
                    maxPrice = 25000;
                    break;
                default:
                    break;

            }

           return r.Next(minPrice, maxPrice);

        }

        private static DateTime GenerateDate(DateTime fromDate)
        {
            DateTime start = fromDate;
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }
    }


}