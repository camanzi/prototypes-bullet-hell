using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuVoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Color hoverFontColor = Color.white;

    [SerializeField]
    private GameObject selectorIconContainer;

    private Color startingColor;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        selectorIconContainer?.SetActive(false);
        startingColor = text.color;
    }
    private void OnDisable()
    {
        ResetMenuVoice();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectorIconContainer?.SetActive(true);
        text.color = hoverFontColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetMenuVoice();
    }

    private void ResetMenuVoice() 
    {
        selectorIconContainer?.SetActive(false);
        text.color = startingColor;
    }
}
