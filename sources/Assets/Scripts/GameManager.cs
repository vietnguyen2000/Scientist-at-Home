using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public ProgressBar progressBar;
    public ObjectPooler pool;

    private void Awake()
    {
        Debug.Log("10");
        pool = new ObjectPooler();
    }

    // Start is called before the first frame update
    void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
