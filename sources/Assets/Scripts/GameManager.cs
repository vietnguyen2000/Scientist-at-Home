using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int level;
    public Camera camera;
    public ProgressBar progressBar;
    public ObjectPooler pool;

    public CountdownTimer TimePlay;

    public GameObject[] disableObject;
    public GameObject winGameObject;
    public GameObject loseGameObject;

    private bool isEnd;
    private void Awake()
    {
        pool = new ObjectPooler();
        progressBar = FindObjectOfType<ProgressBar>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd){
            if (progressBar.slider.value >= progressBar.slider.maxValue*0.95){
                Debug.Log("Win");
                isEnd = true;
                win();
            }
            else if(TimePlay.timeRemaining <= 0){
                Debug.Log("Lose");
                isEnd = true;
                lose();
            }
        }
        
    }

    public void lose()
    {
        for (int i = 0 ; i < disableObject.Length; i ++){
            disableObject[i].SetActive(false);
        }
        loseGameObject.SetActive(true);
    }

    public void win()
    {
        for (int i = 0 ; i < disableObject.Length; i ++){
            disableObject[i].SetActive(false);
        }
        winGameObject.SetActive(true);
        SaveLoadManager.Instance.PassNewLevel(level);
    }
}
