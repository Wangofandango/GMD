using System.Collections;
using System.Collections.Generic;
using Interactables;
using Interactables.Recruitment;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RecruitmentUI : MonoBehaviour
{
    
    
    // Serialize a list of TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI[] nameTexts;
    [SerializeField] private TextMeshProUGUI[] classTexts;
    void Awake()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateRecruitmentOptions(List<GuildMemberData> guildMembers)
    {
        for (int i = 0; i < RecruitmentTableController.MaxRecruitmentOptions; i++)
        {
            nameTexts[i].text = guildMembers[i].Name;
            classTexts[i].text = guildMembers[i].ClassType.ToString();
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
}
