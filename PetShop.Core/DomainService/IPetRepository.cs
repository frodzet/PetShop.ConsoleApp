using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet CreatePet(Pet pet);

        void DeletePet(int Id);

        IEnumerable<Pet> ReadSearchedPets(string searchCriteria);

        Pet UpdatePet(int id);

        IEnumerable<Pet> ReadCheapestPets();

        IEnumerable<Pet> ReadSortedPets();
    }
}