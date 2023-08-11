using System.Collections;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rect;
    Vector3 scale;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        scale = rect.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //rect.localScale
        LeanTween.scale(rect, scale * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(rect, scale, 0.3f);
    }
}
