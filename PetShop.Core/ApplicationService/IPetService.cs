using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet GetPetInstance();

        List<Pet> GetPets();

        Pet AddPet(Pet pet);

        void DeletePet(int id);

        List<Pet> FindPets(string searchCriteria);

        Pet EditPet(int id);

        List<Pet> ShowFiveCheapestPets();

        List<Pet> OrderPetsListByPrice();
    }
}