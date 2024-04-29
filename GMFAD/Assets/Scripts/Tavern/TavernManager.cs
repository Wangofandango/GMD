using System;
using Characters.Guildmembers;
using Common.Core_Mechanics;
using UnityEngine;

namespace Tavern
{
    public class TavernManager : MonoBehaviour
    {
        [SerializeField] private GenericInventory<GuildMemberController> inventoryManager;
        
        
        private void Awake()
        {
            inventoryManager = GetComponent<GenericInventory<GuildMemberController>>();
        }

        private void Start()
        {
            inventoryManager.OnItemAdded += OnGuildMemberRecruited;
            
        }
        
        private void OnGuildMemberRecruited(GuildMemberController guildMember)
        {
            guildMember.RecruitmentSuccess();
        }
        
    }
}