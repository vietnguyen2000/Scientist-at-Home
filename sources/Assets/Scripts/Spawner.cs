using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MyObject
{
    public Transform[] listPositionSpawner;
    public float delay;
    public GameObject GoodBubble;
    public GameObject BadBubble;
    public float badRate;
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
        GameObject x;
        if (Random.Range(0.0f,1.0f) < badRate){
            x = this.gameManager.pool.Instantiate(BadBubble);    
        }
        else x = this.gameManager.pool.Instantiate(GoodBubble);
    }
}

