using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrayOnPointerExit : MonoBehaviour, ISelectHandler
{

    public event Action<int> selectedEvent;

    private Image image;
    [SerializeField] private Color startingColor;
    [SerializeField] private Color disableColor = Color.black;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = startingColor;
    }

    public void OnSelect(BaseEventData eventData)
    {
        selectedEvent?.Invoke(transform.GetSiblingIndex());
    }
    public void DisableImage() 
    {
        image.color = disableColor;
    }
    public void ActivateImage() 
    {
        image.color = startingColor;
    }
}