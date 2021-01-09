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
        for (int i = 0 ; i < Input.touchCount; i++)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            pos = new Vector3(pos.x,pos.y,0);
            Debug.Log(col.bounds);
            if (col.bounds.Contains(pos))
                UpdateProgress();
        }
    }
    protected IEnumerator DisableAfterTime(string name)
    {
        yield return 0;
        while ((animator.GetCurrentAnimatorStateInfo(0).IsName(name))){
            yield return null;
        }
        gameObject.SetActive(false);
     }
    
    protected abstract void UpdateProgress();
}
