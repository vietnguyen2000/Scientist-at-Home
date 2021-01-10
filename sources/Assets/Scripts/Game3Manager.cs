using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Manager : MonoBehaviour
{
    public int level;
    public Camera camera;
    public ObjectPooler pool;

    public GameObject[] disableObject;
    public GameObject winGameObject;
    public GameObject loseGameObject;

    private bool isEnd;
    private void Awake()
    {
        pool = new ObjectPooler();
        camera = FindObjectOfType<Camera>();
    }

    public void lose()
    {
        for (int i = 0; i < disableObject.Length; i++)
        {
            disableObject[i].SetActive(false);
        }
        loseGameObject.SetActive(true);
    }

    public void win()
    {
        for (int i = 0; i < disableObject.Length; i++)
        {
            disableObject[i].SetActive(false);
        }
        winGameObject.SetActive(true);
        SaveLoadManager.Instance.PassNewLevel(level);
    }
}
