using System;
using System.Collections.Generic;
using Characters.Guildmembers;
using Common;
using Common.Core_Mechanics;
using Common.Utils;
using Interactables.Recruitment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables
{
    public class RecruitmentTableController : MonoBehaviour, Iinteractable
    {
        [SerializeField]
        public RecruitmentUI recruitmentUI;

        [SerializeField] public GameObject TavernGameObject;
        [SerializeField] public InventoryManager TavernInventoryManager;

        [SerializeField]
        public GameObject guildmemberPrefab;
        
        private GameObject _interactor;
        
        
        private List<GuildMemberData> _guildMembers;
        
        // Temporary method
        private ClassBlueprint[] _classBlueprints; //Must always be the same number as the number of recruitment options
        
        
        public const int MaxRecruitmentOptions = 4;
        private void Awake()
        {
            _guildMembers = new List<GuildMemberData>();
            _classBlueprints = ClassBlueprint.Classes;
        }

        // Start is called before the first frame update
        void Start()
        {
            recruitmentUI.OnRecruit += (guildMemberData) => FinalizeRecruitment(guildMemberData);
            recruitmentUI.Hide();

            TavernGameObject = transform.parent.gameObject;
            TavernInventoryManager = GetComponentInParent<InventoryManager>();
        }

        private void FinalizeRecruitment(GuildMemberData guildMemberData)
        {
            GameObject newMember = Instantiate(guildmemberPrefab, GetInteractorPosition(), Quaternion.identity);

            GuildMemberController guildMemberScript = newMember.GetComponent<GuildMemberController>();
            
            guildMemberScript.Data = guildMemberData;
            
            TavernInventoryManager.AddGuildMember(guildMemberScript);
            
            
            Debug.Log("Recruiting " + guildMemberData.Name);
        }

        private Vector3 GetInteractorPosition()
        {
            // Spawning slightly to the right of the player
            return _interactor.transform.position + new Vector3(1, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void InitiateRecruitment()
        {
            //Generate some Guildmembers
            foreach (var classBlueprint in _classBlueprints)
            {
                _guildMembers.Add(GuildMemberFactory.GenerateGuildMember(classBlueprint));
            }

            recruitmentUI.UpdateRecruitmentOptions(_guildMembers);
            
            recruitmentUI.Show();
        }
        

        public void Interact(GameObject interactor)
        {
            if (interactor.CompareTag("Player"))
            {
                _interactor = interactor;
                InitiateRecruitment();
            }
        }
    }
}

