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
        public GameObject recruitmentUI;

        private List<GuildMemberData> _guildMembers;
        
        // Temporary method
        private ClassBlueprint[] _classBlueprints; //Must always be the same number as the number of recruitment options
        
        // Recruitment Options to show:
        private const int _recruitmentOptionsCount = 4;
        private List<GameObject> _recruitmentOptions = new List<GameObject>();
        
        private void Awake()
        {
            recruitmentUI = GameObject.Find("Recruitment Selection");
            _guildMembers = new List<GuildMemberData>();
            _classBlueprints = ClassBlueprint.Classes;

            foreach (Transform child in recruitmentUI.transform)
            {
                //Is this a recruitment option?
                if (child.CompareTag(ProjectData.Tags.UI_RecruitmentOption.Name))
                {
                    _recruitmentOptions.Add(child.gameObject);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            recruitmentUI.SetActive(false);
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

            for (int i = 0; i < _recruitmentOptionsCount; i++)
            {
                var guildMember = _guildMembers[i];
                var recruitmentOption = _recruitmentOptions[i];
                
                recruitmentOption.GetComponentInChildren<TextMeshProUGUI>().text = guildMember.Name;
                //recruitmentOption.GetComponentInChildren<Image>().sprite = guildMember.ClassType.Sprite;
            }
            
            recruitmentUI.SetActive(true);
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

