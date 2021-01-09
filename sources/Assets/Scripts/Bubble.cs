using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class Bubble : ClickableObject
{
    public Rigidbody2D vec;
    public Vector2 force;

    float from_begin;
    Vector3 start;

    protected override void Start()
    {
        base.Start();
        this.vec = this.GetComponent<Rigidbody2D>();
        this.from_begin = Time.fixedTime;
        this.start.Set(Random.Range(-0.6f, 0), Random.Range(-5.0f, -6.0f), this.transform.position.z);
        this.transform.position = start;
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.vec.AddForce(this.force);
        base.Update();

        if (Time.fixedTime - this.from_begin > 5)
        {
            this.from_begin = Time.fixedTime;
            this.gameObject.SetActive(false);
            this.transform.position = this.start;
        }

        this.start.Set(Random.Range(-0.6f, 0), Random.Range(-5.0f, -6.0f), this.transform.position.z);
    }
    protected override void UpdateProgress()
    {
        animator.Play("BubbleBreak",0);
        StartCoroutine(DisableAfterTime("BubbleBreak"));

    }
}
