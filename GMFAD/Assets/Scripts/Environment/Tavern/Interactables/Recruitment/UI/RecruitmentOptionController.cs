using System;
using System.Collections;
using System.Collections.Generic;
using Interactables.Recruitment;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecruitmentOptionController : MonoBehaviour
{
    private GuildMemberData _guildMember;

    [SerializeField]
    private TextMeshProUGUI _name;
    
    [SerializeField]
    private TextMeshProUGUI _className;
    
    // Stats

    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _physical;
    [SerializeField] private TextMeshProUGUI _magical;
    [SerializeField] private TextMeshProUGUI _speed;

    [SerializeField] 
    private Image sprite;
    
    //Button
    [SerializeField]
    private Button _recruitButton;

    public event Action<GuildMemberData> GuildMemberRecruited;


    private void Awake()
    {
        _recruitButton = GetComponent<Button>();
        _recruitButton.onClick.AddListener(Recruit);
    }
    
    private void Recruit()
    {
        GuildMemberRecruited?.Invoke(_guildMember);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetGuildMember(GuildMemberData guildMember)
    {
        _guildMember = guildMember;
        UpdateData();
        
    }
    

    private void UpdateData()
    {
        _name.text = _guildMember.Name;
        _className.text = _guildMember.ClassType.ToString();
        _health.text = "Health: " + _guildMember.Stats.Health.ToString();
        _physical.text = "Physical: " + _guildMember.Stats.Physical.ToString();
        _magical.text = "Magical: " + _guildMember.Stats.Magical.ToString();
        _speed.text = "Speed: " + _guildMember.Stats.MovementSpeed.ToString();
    }
}
