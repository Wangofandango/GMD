using UnityEngine;

namespace Interactables.Recruitment
{
    public class CharacterStats : MonoBehaviour
    {
        public int Health { get; set; }
        public int Physical { get; set; }
        public int Magical { get; set; }
        
        public CharacterStats(int health, int physical, int magical)
        {
            Health = health;
            Physical = physical;
            Magical = magical;
        }
        
        public CharacterStats()
        {
            Health = 0;
            Physical = 0;
            Magical = 0;
        }
    }
}