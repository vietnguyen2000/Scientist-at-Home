using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// attach to UI Text component (with the full text already there)

public class Tutorial : UITextTypeWriter
{
    public GameObject ThreeSecsCountDown;
    public GameObject[] listStart;
    protected override void Awake() {
        base.Awake();
        ThreeSecsCountDown.SetActive(false);
        for (int i = 0 ; i < listStart.Length; i++){
            listStart[i].SetActive(false);
        }
    }
    public override void DoSomethingAfterPlayText(){
		base.DoSomethingAfterPlayText();
		skip = false;
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame(){
        while (skip == false){
            yield return null;
        }
        txt.transform.parent.gameObject.SetActive(false);
        ThreeSecsCountDown.SetActive(true);
        yield return new WaitForSeconds(3);
                for (int i = 0 ; i < listStart.Length; i++){
            listStart[i].SetActive(true);
        }
        gameObject.SetActive(false);

    }

}