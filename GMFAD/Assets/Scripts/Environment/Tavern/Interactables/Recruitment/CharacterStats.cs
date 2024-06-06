using UnityEngine;

namespace Interactables.Recruitment
{
    public class CharacterStats
    {
        public int Health { get; set; }
        public int Physical { get; set; }
        public int Magical { get; set; }
        
        public int MovementSpeed { get; set; }
        
        public CharacterStats(int health, int physical, int magical, int movementSpeed)
        {
            Health = health;
            Physical = physical;
            Magical = magical;
            MovementSpeed = movementSpeed;
        }
        
        public CharacterStats()
        {
            Health = 0;
            Physical = 0;
            Magical = 0;
            MovementSpeed = 0;
        }
    }
}