using System.Collections;
using Interactables.Recruitment;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Guildmembers
{
    public class GuildMemberController : MonoBehaviour
    {
        public GuildMemberData Data { get; set; }
        
        //private Health Health { get; set; }

        private NavMeshAgent agent;

        private void Awake()
        {
            //Health = GetComponent<Health>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            //Health.MaxHealth = Data.Stats.Health;
            
            //Subscribe to any other events
        }
        
        public void RecruitmentSuccess()
        {
            Debug.Log(Data.Name + ": Halleliujah! I have been recruited!");
        }

        public IEnumerator StartWalking(Transform area)
        {
            while (true)
            {
                // Choose a random position within the area
                Vector3 targetPosition = area.position + Random.insideUnitSphere * area.localScale.magnitude;

                // Check if the target position is valid on the NavMesh
                if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
                {
                    // Set the destination for the NavMeshAgent
                    agent.SetDestination(hit.position);

                    // Wait until the agent reaches the destination or gets close enough
                    while (agent.pathPending || (agent.remainingDistance > 0.5f))
                    {
                        yield return null;
                    }
                }

                // Wait for a random amount of time before choosing a new target
                yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
            }
        }
    }
}
