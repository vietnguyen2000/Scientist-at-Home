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

        Reset();

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

    protected override IEnumerator DisableAfterTime(string name)
    {
        yield return 0;
        while ((animator.GetCurrentAnimatorStateInfo(0).IsName(name)))
        {
            yield return null;
        }
        this.gameObject.SetActive(false);
        Reset();
    }

    void Reset()
    {
        this.from_begin = Time.fixedTime;
        this.transform.position = new Vector3(Random.Range(-0.5f, 0.5f), -3f, this.transform.position.z);

        float scale_factor = Random.Range(0.5f, 1f);
        this.transform.localScale = new Vector3(scale_factor, scale_factor, this.transform.localScale.z);

        this.vec.velocity = new Vector2(0, 0);
    }
}
