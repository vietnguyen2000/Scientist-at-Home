using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCharacterUI : MonoBehaviour
{
    public GameObject target;
     //this is the ui element
    public RectTransform UI_Element;
 
 //first you need the RectTransform component of your canvas
    public RectTransform CanvasRect;
    public Canvas  canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        UI_Element = GetComponent<RectTransform>();
        UI_Element.anchoredPosition = canvas.WorldToCanvas(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

public static class CanvasExtensions
{
    public static Vector2 WorldToCanvas(this Canvas canvas,
                                        Vector3 world_position,
                                        Camera camera = null)
    {
        if (camera == null)
        {
            camera = Camera.main;
        }

        var viewport_position = camera.WorldToViewportPoint(world_position);
        var canvas_rect = canvas.GetComponent<RectTransform>();

        return new Vector2((viewport_position.x * canvas_rect.sizeDelta.x) - (canvas_rect.sizeDelta.x * 0.5f),
                        (viewport_position.y * canvas_rect.sizeDelta.y));
    }
 }