using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class Bubble : ClickableObject
{
    public Rigidbody2D vec;
    public Vector2 force;

    float from_begin;

    protected override void Start()
    {
        base.Start();
        this.vec = this.GetComponent<Rigidbody2D>();

        this.transform.position = new Vector3(Random.Range(-1f, 1f), -4f, this.transform.position.z);
    }

    // Update is called once per frame
    protected override void Update()
    {
        
        base.Update();
    }
    private void FixedUpdate() {
        this.vec.AddForce(this.force);
    }
    protected override void UpdateProgress()
    {
        animator.Play("BubbleBreak", 0);
        StartCoroutine(DisableAfterAnimationState("BubbleBreak"));
    }

    protected override IEnumerator DisableAfterAnimationState(string name)
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
        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        this.from_begin = Time.fixedTime;
        this.transform.position = new Vector3(Random.Range(-0.5f * width, 0.5f * width), -3f, this.transform.position.z);

        float scale_factor = Random.Range(0.5f, 1f);
        this.transform.localScale = new Vector3(scale_factor, scale_factor, this.transform.localScale.z);

        this.vec.velocity = new Vector2(0, 0);
    }
}
