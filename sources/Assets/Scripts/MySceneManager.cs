using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    public GameObject SceneTransition;
    private bool isLoading = false;
    public void LoadScene(string SceneName){
        if(!isLoading){
            isLoading = true;
            SceneTransition.GetComponent<Animator>().Play("TransitionOut",0);
            StartCoroutine(LoadAsyncScene(SceneName));
        }
        
    }
    public IEnumerator LoadAsyncScene(string name){
        yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= 0.9f){
                if(!(SceneTransition.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TransitionOut"))){
                    asyncLoad.allowSceneActivation = true;
                }
            }
            
            yield return null;
        }
    }
}
