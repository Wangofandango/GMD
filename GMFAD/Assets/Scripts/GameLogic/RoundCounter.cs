using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private int round;
    
    private TextMeshProUGUI textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        round = 1; //Start round:
        textMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    private void UpdateText()
    {
        textMeshPro.text = "Round: " + round;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextRound(int roundNumber)
    {
        round = roundNumber;
        UpdateText();
    }

    public void ResetRound()
    {
        round = 1;
        UpdateText();
    }
}
