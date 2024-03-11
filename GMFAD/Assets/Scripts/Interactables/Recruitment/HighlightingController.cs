using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightingController : MonoBehaviour, IPointerDownHandler
{
    
    public Image ImageToHightlight;
    
    public event Action OnClick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
