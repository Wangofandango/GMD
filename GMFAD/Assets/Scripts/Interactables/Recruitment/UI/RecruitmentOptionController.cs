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

    [SerializeField] 
    private Image sprite;
    
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
    }
}
