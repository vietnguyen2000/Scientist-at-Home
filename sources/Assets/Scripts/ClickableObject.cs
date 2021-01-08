using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using System;
public abstract class ClickableObject : MyObject
{
    public float unit;
    public Animator animator;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected void OnMouseEnter()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            UpdateProgress();
        }
    }

    protected abstract void UpdateProgress();
}
