using System.Collections;
using System.Collections.Generic;
using Interactables;
using Interactables.Shop;
using UnityEngine;

public class ShopTableController : MonoBehaviour, Iinteractable
{
    [SerializeField]
    public ShopUI shopUI;

    private bool CurrentlyShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        shopUI.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Quick solution for now, will be changed later.
    public void Interact(GameObject interactor)
    {
        if (CurrentlyShowing == true)
        {
            shopUI.Hide();
            CurrentlyShowing = false;
            if (interactor.TryGetComponent(out Movement.Movement movement))
            {
                movement.EnableMovement();
            }
            return;
        }
        shopUI.Show();
        CurrentlyShowing = true;
        if (interactor.TryGetComponent(out Movement.Movement movement1))
        {
            movement1.DisableMovement();
        }
    }
}
