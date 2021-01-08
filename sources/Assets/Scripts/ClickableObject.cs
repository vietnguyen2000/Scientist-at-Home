using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickableObject : MyObject, IPointerClickHandler
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }



    // Update is called once per frame
    protected override void Update()
    {
        base.Start();
    }

    public virtual void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }
}
