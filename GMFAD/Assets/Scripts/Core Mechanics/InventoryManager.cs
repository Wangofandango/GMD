using System;
using System.Collections.Generic;
using Characters.Guildmembers;
using Interactables.Recruitment;
using UnityEngine;

namespace Common.Core_Mechanics
{
    public class InventoryManager : MonoBehaviour
    {
        public List<GuildMemberController> GuildMembers { get; set; }

        private void Awake()
        {
            GuildMembers = new List<GuildMemberController>();
        }
        
        public void AddGuildMember(GuildMemberController guildMember)
        {
            GuildMembers.Add(guildMember);
        }
        
        public void RemoveGuildMember(GuildMemberController guildMember)
        {
            GuildMembers.Remove(guildMember);
        }
        
        
        public List<GuildMemberController> GetGuildMembers()
        {
            return GuildMembers;
        }
    }
}