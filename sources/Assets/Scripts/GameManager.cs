using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Camera camera;
    public ProgressBar progressBar;
    public ObjectPooler pool;

    private void Awake()
    {
        pool = new ObjectPooler();
        progressBar = FindObjectOfType<ProgressBar>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progressBar.slider.value >= progressBar.slider.maxValue*0.95){
            Debug.Log("asjdioasjdioasjdoiasjdoiasjdioas");
            SceneManager.LoadScene("game2",LoadSceneMode.Single);
        }
    }

    public void lose()
    {
        Debug.Log("Lose");
    }

    public void win()
    {
        Debug.Log("Win");
    }
}
