using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class Bubble : ClickableObject
{
    public Rigidbody2D vec;
    public Vector2 force;
    public float timeToLive;

    float from_begin;

    protected override void Start()
    {
        base.Start();
        this.vec = this.GetComponent<Rigidbody2D>();
        this.from_begin = Time.fixedTime;

        this.transform.position = new Vector3(Random.Range(-1f, 1f), -4f, this.transform.position.z);

        this.timeToLive = 5;
    }

    // Update is called once per frame
    protected override void Update()
    {
        this.vec.AddForce(this.force);
        base.Update();

        if (Time.fixedTime - this.from_begin > this.timeToLive)
        {
            Reset();
            this.gameObject.SetActive(false);
        }
    }

    protected override void UpdateProgress()
    {
        animator.Play("BubbleBreak",0);
        StartCoroutine(DisableAfterTime("BubbleBreak"));
    }
    void Reset()
    {
        this.from_begin = Time.fixedTime;
        this.transform.position = new Vector3(Random.Range(-1f, 1f), -4f, this.transform.position.z);

        this.vec.velocity = new Vector2(0, 0);
    }
}
