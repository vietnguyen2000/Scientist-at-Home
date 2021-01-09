using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tube : DragWindow, IPointerUpHandler
{
    public Tube mainTube;
    public Color color{
        get=> spriteColor.color;
        set=> spriteColor.color = value;
    }

    public Image spriteColor;
    public Collider2D coll;
    public Color Merge(Color color1, Color color2){
        return color1 + color2;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (mainTube == null)
        {
            Debug.Log("mainTube is null");
        }
        else
        {
            coll = GetComponent<Collider2D>();
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        //If the dragged window is the mainTube
        if (mainTube != spriteColor.GetComponentInParent<Tube>())
        {
            if (coll.OverlapPoint(mainTube.transform.position))
            {
                //Merge color
                Color mergedColor = Merge(spriteColor.color, mainTube.spriteColor.color);
                mainTube.spriteColor.color = mergedColor;

                //Delete the tube
                spriteColor.gameObject.SetActive(false);
                Image spriteparent = spriteColor.GetComponentInParent<Image>();
                spriteparent.gameObject.SetActive(false);
            }
        }
    }
}
