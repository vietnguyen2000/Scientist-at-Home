using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Collider2D))]
public class Tube : MonoBehaviour
{   
    public Color color{
        get=> spriteColor.color;
        set=> spriteColor.color = value;
    }
    public SpriteRenderer spriteColor;
    private string spriteColorName = "tube";

    private Vector3 screenPoint;
    private Vector3 offset;
    private int endDrag = 0;

    public Color Merge(Color color1, Color color2){
        return (color1 + color2)/2;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.spriteColor = Array.Find(GetComponentsInChildren<SpriteRenderer>(), x => x.name == spriteColorName);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    // When 2 Game object collided
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("OnCollisionEnter2D");
        // Debug.Log(col.gameObject);
        // Check 2 tube collapsed:
        if (this.endDrag == 1 && col.gameObject is BigTube)  {
            this.gameObject.SetActive(false);
            gameManager.updateBigTubeColor(Merge(this.gameObject.color, col.gameObject.color));
        }
        this.endDrag = 0;
    }

    void OnMouseDown()
    {
        this.endDrag = 0;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
   
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()    {
        // Debug.Log("Drag ended!");
        // // casts a box using given coordinates and returns all found colliders
        // Collider2D[] foundColliders = Physics2D.OverlapAreaAll(topLeftCorner, bottomRightCorner, layerMask);

        // if (foundColliders.Length == 0) {
        // // can spawn things
        // foreach (Collider2D col in foundColliders)
        // {
        //     Debug.Log(col);
            
        // }
        // }
        this.endDrag = 1;
    }
}
