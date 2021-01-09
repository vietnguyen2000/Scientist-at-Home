using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MyObject
{
    public float delay;
    float from_begin;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.from_begin = Time.fixedTime;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Time.fixedTime - from_begin > delay)
        {
            this.from_begin = Time.fixedTime;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject bubble = Resources.Load<GameObject>("Prefabs/GoodBubble");
        this.gameManager.pool.Instantiate(bubble);
    }
}
