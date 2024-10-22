﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour, IPointerClickHandler
{

	public Text txt;
    public float secsPerText = 0.025f;
	string story;
    protected bool skip;
	protected virtual void Awake () 
	{
		if (txt == null) txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
        skip = false;
		foreach (char c in story) 
		{
			txt.text += c;
            if (skip){
                txt.text = story;
                break;
            }
			yield return new WaitForSeconds (secsPerText);
            
		}
        DoSomethingAfterPlayText();
	}
    public virtual void DoSomethingAfterPlayText(){

    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        skip = true;

    }

}