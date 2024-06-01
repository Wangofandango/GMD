using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{

    private int gold;
    
    private TextMeshProUGUI textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        gold = 20; //Start gold:
        textMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateText()
    {
        textMeshPro.text = "Gold: " + gold;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateText();
    }
    
    public int GetGold()
    {
        return gold;
    }
    
    public void ResetGold()
    {
        gold = 0;
        UpdateText();
    }
    
    public bool CanBuy(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        return false;
    }
    
    public void SpendGold(int amount)
    {
        gold -= amount;
        UpdateText();
    }
}
