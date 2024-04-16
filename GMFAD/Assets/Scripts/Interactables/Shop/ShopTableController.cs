using System.Collections;
using System.Collections.Generic;
using Interactables;
using Interactables.Shop;
using UnityEngine;

public class ShopTableController : MonoBehaviour, Iinteractable
{
    [SerializeField]
    public ShopUI shopUI;
    
    // Start is called before the first frame update
    void Start()
    {
        shopUI.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interactor)
    {
        shopUI.Show();
    }
}
