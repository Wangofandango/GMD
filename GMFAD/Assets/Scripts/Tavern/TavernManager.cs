using System;
using Characters.Guildmembers;
using Common.Core_Mechanics;
using UnityEngine;
using UnityEngine.AI;

namespace Tavern
{
    public class TavernManager : MonoBehaviour
    {
        private GenericInventory<GuildMemberController> inventoryManager;
        
        [SerializeField] public GameObject temporaryGuildMemberPrefab;
        
        [SerializeField] public Transform guildMemberBaseArea;
        
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
            
            //Instansiate the guild member in the tavern
            var tavernTransform = transform;
            
            // Temporary solution
            guildMember.Data.Prefab = temporaryGuildMemberPrefab;
            
            GameObject newGuildMember = Instantiate(guildMember.Data.Prefab, transform.position, transform.rotation);
            newGuildMember.GetComponent<NavMeshAgent>().enabled = true; // Enable NavMeshAgent

            // Initiate the StartWalkingAround coroutine
            GuildMemberController newMemberController = newGuildMember.GetComponent<GuildMemberController>();
            StartCoroutine(newMemberController.StartWalking(guildMemberBaseArea));
        }
        
    }
}