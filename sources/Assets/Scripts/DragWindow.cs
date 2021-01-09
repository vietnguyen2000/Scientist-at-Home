using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragWindow : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image backgroundImage;
    private Color backgroundColor;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Change background color to sth faded
        //backgroundColor.a = .4f;
        //backgroundImage.color = backgroundColor;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Change position of the Image
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Change color back to normal
        //backgroundColor.a = 1f;
        //backgroundImage.color = backgroundColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ////Render the Image as the top layer.
        //dragRectTransform.SetAsLastSibling();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (dragRectTransform == null)
            dragRectTransform = GetComponent<RectTransform>();
        if (canvas == null)
            canvas = GetComponentInParent<Canvas>();
        if (backgroundImage == null)
            backgroundImage = GetComponent<Image>();
        backgroundColor = backgroundImage.color;
    }

}
