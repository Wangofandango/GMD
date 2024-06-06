using System.Collections;
using Common.Core_Mechanics;
using GameLogic;
using Interactables.Recruitment;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Characters.Guildmembers
{
    public class GuildMemberController : MonoBehaviour, IInventoryItem
    {
        public GuildMemberData Data { get; set; }


        public WalkableArea walkingArea;
        
        public bool shouldMoveToPortal = false;


        //private Health Health { get; set; }

        // private NavMeshAgent agent;

        public GuildmemberInteractor Interactor { get; set; }
        private void Awake()
        {
            //Health = GetComponent<Health>();
            //agent = GetComponent<NavMeshAgent>();
            Interactor = GetComponent<GuildmemberInteractor>();
        }

        private void OnEnable()
        {
            
            //Health.MaxHealth = Data.Stats.Health;
        }

        public void BeginWalking()
        {
            StartCoroutine(StartWalking());
        }

        public IEnumerator StartWalking()
        {
            while (true)
            {
                
                if (shouldMoveToPortal)
                {
                    StopAllCoroutines();
                    PortalManager.PortalProgress randomPortal = GameManager.Instance.PortalManager.GetRandomPortalPosition();
                    
                    StartCoroutine(MoveToPortal(randomPortal.PortalData));
                    break;
                }
                
                // Get a random position within the walkable area
                Vector3 randomPosition = walkingArea.GetRandomPosition();

                // Begin walking to the random position
                while (Vector3.Distance(transform.position, randomPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, randomPosition,
                        Data.Stats.MovementSpeed * Time.deltaTime);
                    yield return null;
                }

                // Wait for a few seconds before moving to the next random position
                yield return new WaitForSeconds(2);
            }
        }
        
        private IEnumerator MoveToPortal(PortalManager.PortalData portalData)
        {
            while (Vector3.Distance(transform.position, portalData.Position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, portalData.Position,
                    Data.Stats.MovementSpeed * Time.deltaTime);
                yield return null;
            }

            // Reached portal
            shouldMoveToPortal = false;
            gameObject.SetActive(false);
            GameManager.Instance.PortalManager.GuildmemberReachedPortal(gameObject, portalData.Location, Data.Stats);
        }


        public void OnAddedToInventory()
        {
            Debug.Log(Data.Name + ": Halleliujah! I have been recruited!");
            BeginWalking();
        }

        public void OnRemovedFromInventory()
        {
            //GetComponent<NavMeshAgent>().enabled = false;
        }

        public void PassOnData()
        {
            Interactor.Data = Data;
        }
    }
}