using System;
using Characters.Guildmembers;
using Common.Core_Mechanics;
using Interactables.Recruitment;
using UnityEngine;
using UnityEngine.AI;

namespace Tavern
{
    public class TavernManager : MonoBehaviour
    {
        private GenericInventory inventoryManager;
        
        
        [SerializeField] public GameObject temporaryGuildMemberPrefab;
        
        [SerializeField] public Transform guildMemberBaseArea;
        
        private void Awake()
        {
            inventoryManager = GetComponent<GenericInventory>();
        }
        
        private void Start()
        {
            
        }

        public void AddMember(GuildMemberData guildMemberData)
        {
            // Create a new GuildMemberController instance
            guildMemberData.Prefab = temporaryGuildMemberPrefab;
            
            GameObject newGuildMember = Instantiate(guildMemberData.Prefab, guildMemberBaseArea.position, guildMemberBaseArea.rotation);
            
            
            // Initiate the StartWalkingAround coroutine
            GuildMemberController newMemberController = newGuildMember.GetComponent<GuildMemberController>();
            
            newMemberController.Data = guildMemberData;
            
            newMemberController.walkingArea = guildMemberBaseArea;
            
            //Add to my inventory
            inventoryManager.AddItem(newMemberController);
            
            newMemberController.OnAddedToInventory(); // Call OnAddedToInventory after instantiation
        }
    }
}