using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{
    public float value = 5;
    public float BoomRate = 0.2f;
    private GameManager gameManager;
    public GameObject Boom;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0 ; i < Input.touchCount; i ++){
            if (Input.touches[i].phase == TouchPhase.Began){
                gameManager.progressBar.Increment(value);
                float x = Random.Range(0.0f,1.0f);
                if (x <= BoomRate){
                    GameObject boom = gameManager.pool.Instantiate(Boom);
                    boom.transform.position = Camera.main.ScreenToWorldPoint(Input.touches[i].position) + new Vector3(0,0,10.0f);
                }
            }
        }
    }
}
