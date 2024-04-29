using System;
using Common.Core_Mechanics;
using UnityEngine;

namespace Interactables.Recruitment
{
    public class GuildMemberData : ScriptableObject
    {
        public ClassType ClassType { get; set; }

        public CharacterStats Stats { get; set; }
        
        public string Name { get; set; }
    }
}