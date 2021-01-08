using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
