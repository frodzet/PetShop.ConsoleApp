using System;

namespace PetShop.Core.Entities
{
    /// <summary>
    /// </summary>
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public DateTime Birthdate { get; set; }
        public string PreviousOwner { get; set; }
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
    }
}