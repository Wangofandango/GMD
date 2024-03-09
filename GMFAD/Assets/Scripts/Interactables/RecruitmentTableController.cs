using System;
using System.Collections.Generic;
using Common;
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
            recruitmentUI.Hide();
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
                InitiateRecruitment();
            }
        }
    }
}

