using System.Collections;
using Common.Core_Mechanics;
using Interactables.Recruitment;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Characters.Guildmembers
{
    public class GuildMemberController : MonoBehaviour, IInventoryItem
    {
        public GuildMemberData Data { get; set; }
        
        
        public Transform walkingArea;
        
        //private Health Health { get; set; }

       // private NavMeshAgent agent;

        
        private void Awake()
        {
            //Health = GetComponent<Health>();
            //agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            //Health.MaxHealth = Data.Stats.Health;
            
            //Subscribe to any other events
        }
        
        public void RecruitmentSuccess()
        {
        }

        public IEnumerator StartWalking()
        {
            while (true)
            {
                // Choose a random position within the walking area bounds (2D)

                //Get a random point within the walking area
                var localScale = walkingArea.localScale;
                
                Vector3 randomoffset = new Vector2(Random.Range(-localScale.x, localScale.x), Random.Range(-localScale.y, localScale.y));

                Vector3 randomPoint = walkingArea.transform.TransformPoint(randomoffset);
                
                
                // Move towards the chosen position
                while (Vector3.Distance(transform.position, randomPoint) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, randomoffset, Time.deltaTime * Data.Stats.MovementSpeed);
                    yield return null;
                }

                // Wait behavior can be added here if desired (commented out)
                float waitTime = Random.Range(2.0f, 5.0f);
                float elapsedTime = 0f;
                while (elapsedTime < waitTime)
                {
                    elapsedTime += Time.deltaTime;
                   yield return null;
                }
            }
        }




        public void OnAddedToInventory()
        {
            Debug.Log(Data.Name + ": Halleliujah! I have been recruited!");
            StartCoroutine(StartWalking()); // (assuming StartWalking exists)
        }

        public void OnRemovedFromInventory()
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
