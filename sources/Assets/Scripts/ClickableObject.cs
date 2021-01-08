using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using System;
public abstract class ClickableObject : MyObject
{
    public float unit;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            UpdateProgress();
            this.gameObject.SetActive(false);
        }
    }
    
    protected abstract void UpdateProgress();
}
