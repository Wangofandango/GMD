using System;
using System.Collections.Generic;
using Characters.Guildmembers;
using Common;
using Common.Core_Mechanics;
using Common.Utils;
using Interactables.Recruitment;
using Tavern;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables
{
    public class RecruitmentTableController : MonoBehaviour, Iinteractable
    {
        [SerializeField]
        public RecruitmentUI recruitmentUI;

        //[SerializeField] public InventoryManager TavernInventoryManager;

        
        private GameObject _interactor;
        
        public TavernManager tavernManager;
        
        
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
            recruitmentUI.OnRecruit += FinalizeRecruitment;
            recruitmentUI.Hide();

            tavernManager = GetComponentInParent<TavernManager>();
            //TavernInventoryManager = GetComponentInParent<InventoryManager>();
        }

        private void FinalizeRecruitment(GuildMemberData guildMemberData)
        {
            tavernManager.AddMember(guildMemberData);
            
            _guildMembers.Clear();
            recruitmentUI.Hide();
            
            Debug.Log("Recruiting " + guildMemberData.Name);
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

