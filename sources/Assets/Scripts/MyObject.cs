using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyObject : MonoBehaviour
{
    public Collider2D Collider{
        get => col;
    }
    public SpriteRenderer SpriteRenderer{
        get => spriteRenderer;
    }
    public GameManager GameManager{
        get=>gameManager;
    }
    protected GameManager gameManager;
    protected Collider2D col;
    protected SpriteRenderer spriteRenderer;
    protected virtual  void Start() {
        gameManager = (GameManager)FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        col = GetComponentInChildren<Collider2D>();
    }
    protected virtual void Update(){
        
    }
}