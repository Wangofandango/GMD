using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactables;
using Interactables.Recruitment;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RecruitmentUI : MonoBehaviour, IUserInterface
{
    
    [SerializeField] private RecruitmentOptionController[] recruitmentOptions;

    public event Action<GuildMemberData> OnRecruit;
    

    [SerializeField]
    private Button _exitButton;

    //Create hashmap with the recruitment options and the guildmembers
    private Dictionary<RecruitmentOptionController, GuildMemberData> _optionGuildMemberCombinations;
    
    private GoldCounter _goldCounter;
    void Awake()
    {
        _optionGuildMemberCombinations = new Dictionary<RecruitmentOptionController, GuildMemberData>();
        _goldCounter = FindObjectOfType<GoldCounter>();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var option in recruitmentOptions)
        {
            option.GuildMemberRecruited += HandleMemberSelection;
        }
        
        _exitButton.onClick.AddListener(Exit);
    }


    public void UpdateRecruitmentOptions(List<GuildMemberData> guildMembers)
    {
        _optionGuildMemberCombinations.Clear(); // Clear the dictionary when hiding the UI
        
       
        
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

    private void HandleMemberSelection(GuildMemberData guildMember)
    {
        // Check gold and potentially call BuyCharacter here
        if (_goldCounter.CanBuy(10))
        {
            OnRecruit?.Invoke(guildMember);
            _goldCounter.SpendGold(10);
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void Exit()
    {
        Hide();
        OnRecruit?.Invoke(null);

    }
}

