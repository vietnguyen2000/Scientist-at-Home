using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Color color{
        get=> spriteColor.color;
        set=> spriteColor.color = value;
    }
    public SpriteRenderer spriteColor;
    public Color Merge(Color color1, Color color2){

        return color1 + color2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
