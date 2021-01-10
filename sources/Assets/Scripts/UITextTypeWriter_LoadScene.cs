using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITextTypeWriter_LoadScene : UITextTypeWriter
{
    public string SceneName;

    public override void DoSomethingAfterPlayText(){
		base.DoSomethingAfterPlayText();
		skip = false;
        StartCoroutine(LoadScene(SceneName));
    }
    IEnumerator LoadScene(string SceneName){
        while (skip == false){
            yield return null;
        }
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single);
    }

}