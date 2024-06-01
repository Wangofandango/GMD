using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactables;
using Interactables.Recruitment;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RecruitmentUI : MonoBehaviour, IUserInterface
{
    
    
    [SerializeField] private Button recruitButton;
    [SerializeField] private RecruitmentOptionController[] recruitmentOptions;

    public event Action<GuildMemberData> OnRecruit;
    
    private GameObject HighlightedOption { get; set; }
    
    private HighlightingController[] _highlightingControllers;

    //Create hashmap with the recruitment options and the guildmembers
    private Dictionary<RecruitmentOptionController, GuildMemberData> _optionGuildMemberCombinations;
    
    void Awake()
    {
        _optionGuildMemberCombinations = new Dictionary<RecruitmentOptionController, GuildMemberData>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
   

    public void OnOptionClick(int index)
    {
        if (HighlightedOption != null)
        {
            //Make the imagetohightlight seethrough
            HighlightedOption.GetComponent<HighlightingController>().ImageToHightlight.color = Color.white;
        }
        
        HighlightedOption = _highlightingControllers[index].gameObject;
        //Make the image red
        HighlightedOption.GetComponent<HighlightingController>().ImageToHightlight.color = Color.red;
    }
    
    public void UpdateRecruitmentOptions(List<GuildMemberData> guildMembers)
    {
        _optionGuildMemberCombinations.Clear(); // Clear the dictionary when hiding the UI
        
        InitializeOptionGuildMemberCombinations();
        
        for (int i = 0; i < recruitmentOptions.Length; i++)
        {
            int index = i; // This needs to be done for some reason
            AssignGuildMemberToOption(guildMembers[index], recruitmentOptions[index]);
        }
    }

    private void AssignGuildMemberToOption(GuildMemberData guildMember, RecruitmentOptionController option)
    {
        option.SetGuildMember(guildMember);
        
        //Add combination to hashmap
        _optionGuildMemberCombinations.Add(option, guildMember);
    }
   
    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void InitializeOptionGuildMemberCombinations()
    {
        _highlightingControllers = GetComponentsInChildren<HighlightingController>();
        for (int i = 0; i < _highlightingControllers.Length; i++)
        {
            int index = i; // Create a local copy of i for closure
            _highlightingControllers[i].OnClick += () => OnOptionClick(index);
        }
        
        recruitButton.onClick.AddListener(() =>
        {
            if (HighlightedOption != null)
            {
                //Check if the player has enough gold.
                
                var guildMember = _optionGuildMemberCombinations[HighlightedOption.GetComponent<RecruitmentOptionController>()];
                OnRecruit?.Invoke(guildMember);
            }
        });
    }

    public void Hide()
    {
        if (HighlightedOption != null)
        {
            HighlightedOption.GetComponent<HighlightingController>().ImageToHightlight.color = Color.white;
            HighlightedOption = null;
        }
        gameObject.SetActive(false);
    }
}

