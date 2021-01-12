using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public void retry(){
        Scene scene = SceneManager.GetActiveScene();
        FindObjectOfType<MySceneManager>().LoadScene(scene.name);
    }
}
