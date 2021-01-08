using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MyObject
{
    public float delay;
    public GameObject samples;
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
        for (int i = 0; i<=this.samples.transform.childCount - 1; i++)
        {
            GameObject child = this.samples.transform.GetChild(i).gameObject;
            this.gameManager.pool.Instantiate(child);
        }
    }
}
