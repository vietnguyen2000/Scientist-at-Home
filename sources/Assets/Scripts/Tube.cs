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
    [SerializeField] public Color finalColor;

    public GameManager GameManager{
        get=>gameManager;
    }
    protected GameManager gameManager;

    public Color Merge(Color color1, Color color2){
        return color1 + color2;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        if (currColor.r > wantedColor.r || currColor.g > wantedColor.g || currColor.b > wantedColor.b)  {
            return false;
        }
        return true;
    }

    private bool obtainedColor(Color currColor, Color wantedColor)  {
        if (currColor.r == wantedColor.r || currColor.g == wantedColor.g || currColor.b == wantedColor.b)  {
            return false;
        }
        return true;
    }

    void Update()
    {
        if (notObtainable(mainTube.spriteColor.color, finalColor))    {
            gameManager.lose();
        }
        else if (obtainedColor(mainTube.spriteColor.color, finalColor))   {
            gameManager.win();
        }
    }

    private bool ableToMerge(Color color1, Color color2){
        if (color1.r + color2.r >= 255 || color1.g + color2.g >= 255 || color1.b + color2.b >= 255)   {
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
                if (ableToMerge(spriteColor.color, mainTube.spriteColor.color)) {
                    //Merge color
                    Color mergedColor = Merge(spriteColor.color, mainTube.spriteColor.color);
                    mainTube.spriteColor.color = mergedColor;

                    //Delete the tube
                    spriteColor.gameObject.SetActive(false);
                    Image spriteParent = spriteColor.GetComponentInParent<Image>();
                    spriteParent.gameObject.SetActive(false);

                    checkIfFinalColor();
                }
                else
                {
                    Debug.Log("Hiệu ứng chuyển động báo không được phép làm thế");
                }
            }
        }
    }
}
