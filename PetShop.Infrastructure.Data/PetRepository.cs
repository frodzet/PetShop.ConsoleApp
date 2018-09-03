using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private readonly List<Pet> pets = FakeDB.Pets.ToList();

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public IEnumerable<Pet> ReadSearchedPets(string searchCriteria)
        {
            return pets.Where(p =>
                p.Name.ToLower().Contains(searchCriteria.ToLower()) ||
                p.Type.ToLower().Contains(searchCriteria.ToLower()));
        }

        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public Pet UpdatePet(int Id)
        {
            var pet = pets.FirstOrDefault(p => p.Id == Id);
            FakeDB.Pets = pets;
            return pet;
        }

        public IEnumerable<Pet> ReadCheapestPets()
        {
            return pets.OrderBy(p => p.Price).Take(5);
        }

        public IEnumerable<Pet> ReadSortedPets()
        {
            return pets.OrderBy(p => p.Price);
        }

        public void DeletePet(int Id)
        {
            var pet = pets.FirstOrDefault(p => p.Id == Id);
            pets.Remove(pet);
            FakeDB.Pets = pets;
        }
    }
}