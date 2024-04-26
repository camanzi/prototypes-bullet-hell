using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuVoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    [SerializeField]
    private Color hoverFontColor = Color.white;

    [SerializeField]
    private GameObject selectorIconContainer;

    private Color previusColor;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        selectorIconContainer?.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectorIconContainer?.SetActive(true);
        previusColor = text.color;
        text.color = hoverFontColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectorIconContainer?.SetActive(false);
        text.color = previusColor;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Pressed" + eventData);
    }
}
