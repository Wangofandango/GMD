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
        
        [SerializeField] public WalkableArea guildMemberBaseArea;
        
        private void Awake()
        {
            inventoryManager = GetComponent<GenericInventory>();
        }
        
        private void Start()
        {
            
        }

        public void AddMember(GuildMemberData guildMemberData)
        {
            guildMemberData.Prefab = temporaryGuildMemberPrefab;
            
            
            GameObject newGuildMember = Instantiate(guildMemberData.Prefab, guildMemberBaseArea.GetCenter(), Quaternion.identity);
            
            
            // Initiate the StartWalkingAround coroutine
            GuildMemberController newMemberController = newGuildMember.GetComponent<GuildMemberController>();
            
            newMemberController.Data = guildMemberData;
            
            newMemberController.walkingArea = guildMemberBaseArea;

            newMemberController.PassOnData();
            
            //Add to my inventory
            inventoryManager.AddItem(newMemberController);
            
            newMemberController.OnAddedToInventory(); // Call OnAddedToInventory after instantiation
        }
    }
}