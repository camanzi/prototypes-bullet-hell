using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomSliderController : MonoBehaviour
{

    private GrayOnPointerExit[] volumeTicks;
    private int activeTickIndex;

    private void Awake()
    {
        volumeTicks = GetComponentsInChildren<GrayOnPointerExit>();
        activeTickIndex = volumeTicks.Length - 1;
    }

    private void OnEnable()
    {
        foreach (GrayOnPointerExit volumeTick in volumeTicks)
        {
            volumeTick.selectedEvent += SelectActiveTickIndex;
        }
    }
    private void OnDisable()
    {
        foreach (GrayOnPointerExit volumeTick in volumeTicks)
        {
            volumeTick.selectedEvent -= SelectActiveTickIndex;
        }
    }
    private void Update()
    {

        ColorToIndex(activeTickIndex);
    }
    private void SelectActiveTickIndex(int index) 
    {
        activeTickIndex = index;
    }
    private void ColorToIndex(int index) 
    {
        for (int i = 0; i <= index; i++)
        {
            volumeTicks[i].ActivateImage();
        }
        for (int i = volumeTicks.Length - 1; i > index; i--) 
        {
            volumeTicks[i].DisableImage();
        }
    }

}