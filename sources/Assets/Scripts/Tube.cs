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
    public Color finalColor;
    public PixArt virus;
    static private bool initColor = true;
    public Vector3 initPos = new Vector3(93, 264, 0);

    public GameManager GameManager{
        get=>gameManager;
    }
    protected GameManager gameManager;

    public Color Merge(Color color1, Color color2){
        if (color2.r != 0)    {
            return new Color(color1.r, color1.g - (float)1/4, color1.b - (float)1/4);
        }
        else if (color2.g != 0)    {
            return new Color(color1.r - (float)1/4, color1.g, color1.b - (float)1/4);
        }
        else    {
            return new Color(color1.r - (float)1/4, color1.g - (float)1/4, color1.b);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        initPos = this.transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        initColor = true;
        gameManager = (GameManager)FindObjectOfType<GameManager>();
        virus = FindObjectOfType<PixArt>();
        
        if (mainTube == null)
        {
            Debug.Log("mainTube is null");
        }
        else
        {
            coll = GetComponent<Collider2D>();
        }
    }

    private bool obtainable(Color currColor, Color wantedColor)  {
        if (currColor.r < wantedColor.r || currColor.g < wantedColor.g || currColor.b < wantedColor.b)  {
            return false;
        }
        return true;
    }

    private bool obtainedColor(Color currColor, Color wantedColor)  {
        if (currColor.r == wantedColor.r && currColor.g == wantedColor.g && currColor.b == wantedColor.b)  {
            return true;
        }
        return false;
    }

    void Update()
    {
        // bool winnable = initColor;
        // foreach (Color virusColor in virus.Remain())
        // {
        //     if (obtainedColor(mainTube.spriteColor.color, virusColor))  {
        //         virus.RemoveColor(virusColor);
        //         winnable = true;
        //     }
        //     // NOTE: Mỗi lần chơi chỉ cần tìm được 1 màu của con virus, sau đó lọ màu sẽ được reset
        //     else if (obtainable(mainTube.spriteColor.color, virusColor)) {
        //         winnable = true;
        //     }
        // }
        // if (!winnable)  {
        //     gameManager.lose();
        // }
        // if (virus.AllWhite())    {
        //     gameManager.win();
        // }
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
                    //Merge color:
                    Color mergedColor = Merge(mainTube.spriteColor.color, spriteColor.color);
                    mainTube.spriteColor.color = mergedColor;
                    initColor = false;

                    // Move the tube back to original position:
                    spriteColor.gameObject.SetActive(false);
                    Image spriteParent = spriteColor.GetComponentInParent<Image>();
                    spriteParent.gameObject.transform.localPosition = initPos;
                    spriteColor.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Hiệu ứng chuyển động báo không được phép làm thế");
                }
            }
        }
    }
}