using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using Interactables.Recruitment;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RecruitmentUI : MonoBehaviour
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
                var guildMember = _optionGuildMemberCombinations[HighlightedOption.GetComponent<RecruitmentOptionController>()];
                OnRecruit?.Invoke(guildMember);
            }
        });
    }
    
    // Update is called once per frame
    void Update()
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
        for (int i = 0; i < recruitmentOptions.Length; i++)
        {
            int index = i;
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
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
