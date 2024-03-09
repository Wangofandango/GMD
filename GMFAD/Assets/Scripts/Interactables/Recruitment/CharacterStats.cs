namespace Interactables.Recruitment
{
    public class CharacterStats
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
            
        }
    }
}