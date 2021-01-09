﻿using System;
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
    public Color finalColor;
    static private bool initColor = true;
    public Vector3 initPos = new Vector3(93, 264, 0);

    public GameManager GameManager{
        get=>gameManager;
    }
    protected GameManager gameManager;

    public Color Merge(Color color1, Color color2){
        if (color2.r != 0)    {
            return new Color(color1.r, color1.g - (float)64/255, color1.b - (float)64/255);
        }
        else if (color2.g != 0)    {
            return new Color(color1.r - (float)64/255, color1.g, color1.b - (float)64/255);
        }
        else    {
            return new Color(color1.r - (float)64/255, color1.g - (float)64/255, color1.b);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initColor = true;
        gameManager = (GameManager)FindObjectOfType<GameManager>();
        
        if (mainTube == null)
        {
            Debug.Log("mainTube is null");
        }
        else
        {
            coll = GetComponent<Collider2D>();
        }
    }

    private bool notObtainable(Color currColor, Color wantedColor)  {
        if (currColor.r < wantedColor.r || currColor.g < wantedColor.g || currColor.b < wantedColor.b)  {
            return true;
        }
        return false;
    }
<<<<<<< HEAD

    private bool obtainedColor(Color currColor, Color wantedColor)  {
        if (currColor.r == wantedColor.r && currColor.g == wantedColor.g && currColor.b == wantedColor.b)  {
            return true;
        }
        return false;
=======
    
    // When 2 Game object collided
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("OnCollisionEnter2D");
        // Debug.Log(col.gameObject);
        // Check 2 tube collapsed:
        // if (this.endDrag == 1 && col.gameObject is BigTube)  {
        //     this.gameObject.SetActive(false);
        //     // gameManager.updateBigTubeColor(Merge(this.gameObject.color, col.gameObject.color));
        // }
        // this.endDrag = 0;
>>>>>>> CountdownTimer
    }

    void Update()
    {
        if (!initColor && notObtainable(mainTube.spriteColor.color, finalColor))    {
            gameManager.lose();
        }
        else if (obtainedColor(mainTube.spriteColor.color, finalColor))   {
            gameManager.win();
        }
    }

    private bool ableToMerge(Color color1, Color color2){
        Color checkColor = Merge(color1, color2);
        if (checkColor.r < 0 || checkColor.g < 0 || checkColor.b < 0)   {
            return false;
        }
        return true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // If the dragged to window is the mainTube:
        if (mainTube != spriteColor.GetComponentInParent<Tube>())
        {
            if (coll.OverlapPoint(mainTube.transform.position))
            {
                if (ableToMerge(mainTube.spriteColor.color, spriteColor.color)) {
                    //Merge color
                    Color mergedColor = Merge(mainTube.spriteColor.color, spriteColor.color);
                    mainTube.spriteColor.color = mergedColor;
                    initColor = false;

                    // //Delete the tube
                    spriteColor.gameObject.transform.position = initPos;
                    // spriteColor.gameObject.SetActive(false);
                    Image spriteParent = spriteColor.GetComponentInParent<Image>();
                    spriteParent.gameObject.transform.position = initPos;
                }
                else
                {
                    Debug.Log("Hiệu ứng chuyển động báo không được phép làm thế");
                }
            }
        }
    }
}
