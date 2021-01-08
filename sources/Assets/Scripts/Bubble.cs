using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class Bubble : ClickableObject
{
    public Rigidbody2D vec;
    public Vector2 force;

    protected override void Start()
    {
        this.vec = this.GetComponent<Rigidbody2D>();
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.vec.AddForce(this.force);
        base.Update();
    }
    protected override void UpdateProgress()
    {
        animator.Play("BubbleBreak",0);
        StartCoroutine(DisableAfterTime("BubbleBreak"));

    }
    IEnumerator DisableAfterTime(string name)
    {
        yield return 0;
        while ((animator.GetCurrentAnimatorStateInfo(0).IsName(name))){
            yield return null;
        }
        gameObject.SetActive(false);
     }
}
