using Interactables.Recruitment;
using UnityEngine;

namespace Characters.Guildmembers
{
    public class GuildMemberController : MonoBehaviour
    {
        public GuildMemberData Data { get; set; }
        
        //private Health Health { get; set; }

        private void Awake()
        {
            //Health = GetComponent<Health>();
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
    }
}
