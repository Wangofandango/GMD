using System.Collections;
using System.Collections.Generic;
using Characters.Guildmembers;
using GameLogic;
using Interactables;
using Interactables.Recruitment;
using Unity.VisualScripting;
using UnityEngine;

public class GuildmemberInteractor : MonoBehaviour, Iinteractable
{
    public GuildMemberData Data { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interactor)
    {
        if (interactor.CompareTag("Player"))
        {
            GetComponent<GuildMemberController>().shouldMoveToPortal = true; // Set flag in GuildMemberController
            StopAllCoroutines(); 
        }
    }
}
