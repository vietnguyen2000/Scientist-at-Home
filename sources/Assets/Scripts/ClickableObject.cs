﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using System;
public abstract class ClickableObject : MyObject
{
    public float unit;
    public Animator animator;
    public bool isClicked = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void OnEnable() {
        isClicked = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        for (int i = 0 ; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began){
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                pos = new Vector3(pos.x,pos.y,0);
                if (col.OverlapPoint(pos) && !isClicked){
                    
                    UpdateProgress();
                    isClicked = true;
                }               
            }
            
        }
    }
    protected virtual IEnumerator DisableAfterAnimationState(string name)
    {
        yield return 0;
        while ((animator.GetCurrentAnimatorStateInfo(0).IsName(name))){
            yield return null;
        }
        gameObject.SetActive(false);
     }
    
    protected abstract void UpdateProgress();
}
