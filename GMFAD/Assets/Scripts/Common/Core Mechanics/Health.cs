using System;
using UnityEngine;

namespace Common.Core_Mechanics
{
    public class Health : MonoBehaviour
    {
        public int MaxHealth { get; set; }
        private int CurrentHealth { get; set; }
        public event Action<int> OnDamage;
        public event Action OnDeath;


        private void Start()
        {
            CurrentHealth = MaxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            OnDamage?.Invoke(damage);
            
            if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
    
}