using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{
    public float value = 5;
    public float BoomRate = 0.2f;
    private GameManager gameManager;
    public GameObject Boom;
    public Animator monitor;
    public Animator keyboard;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnDisable() {
        speed = 0;
        monitor.SetFloat("speed",speed);
        keyboard.SetFloat("speed",speed);
    }
    float lastTimeTouch;
    float speed;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0 ; i < Input.touchCount; i ++){
            Debug.Log(Input.touches[i].phase);
            if (Input.touches[i].phase is TouchPhase.Began){
                Debug.Log(Time.time - lastTimeTouch);
                if (Time.time - lastTimeTouch <= 0.8f){
                    speed = 1;
                }
                lastTimeTouch = Time.time;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                pos = new Vector3(pos.x,pos.y,0);
                gameManager.progressBar.Increment(value);
                
                float x = Random.Range(0.0f,1.0f);
                if (x <= BoomRate){
                    StartCoroutine(createBoom(pos));
                    
                }
            }
        }
        
        if(speed > 0)
            speed -= Time.deltaTime;
        else{
            speed = 0;
        }
        monitor.SetFloat("speed",speed);
        keyboard.SetFloat("speed",speed);
    }
    IEnumerator createBoom(Vector3 pos){
        yield return null;
        yield return null;
        GameObject boom = gameManager.pool.Instantiate(Boom);
        boom.transform.position = pos;
    }
}
