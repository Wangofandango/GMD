using System;
using Common.Core_Mechanics;
using UnityEngine;

namespace Interactables.Recruitment
{
    public class GuildMemberData
    {
        public ClassType ClassType { get; set; }

        public CharacterStats Stats { get; set; }
        
        
        public string Name { get; set; }
        
    }

    public class GuildMember : MonoBehaviour
    {
        public GuildMemberData Data { get; set; }
        
        private Health Health { get; set; }

        private void Awake()
        {
            Data = GetComponent<GuildMemberData>();
            Health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            Health.MaxHealth = Data.Stats.Health;
            
            //Subscribe to any other events
        }
    }
}