using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private List<Pet> allPets = new List<Pet>();
        private List<Pet> searchedPets = new List<Pet>();

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet GetPetInstance()
        {
            return new Pet();
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public Pet AddPet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public void DeletePet(int Id)
        {
            _petRepository.DeletePet(Id);
        }

        public List<Pet> FindPets(string searchCriteria)
        {
            return _petRepository.ReadSearchedPets(searchCriteria).ToList();
        }

        public Pet EditPet(int Id)
        {
            return _petRepository.UpdatePet(Id);
        }

        public List<Pet> ShowFiveCheapestPets()
        {
            return _petRepository.ReadCheapestPets().ToList();
        }

        public List<Pet> OrderPetsListByPrice()
        {
            return _petRepository.ReadSortedPets().ToList();
        }
    }
}