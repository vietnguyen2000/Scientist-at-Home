using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tube : MonoBehaviour
{   
    public Color color{
        get=> spriteColor.color;
        set=> spriteColor.color = value;
    }
    public SpriteRenderer spriteColor;
    private string spriteColorName = "tube";
    // TODO
    public Color Merge(Color color1, Color color2){
        return (color1 + color2)/2;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteColor = Array.Find(GetComponentsInChildren<SpriteRenderer>(), x => x.name == spriteColorName);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        // spriteMove = -0.1f;
    }
}
