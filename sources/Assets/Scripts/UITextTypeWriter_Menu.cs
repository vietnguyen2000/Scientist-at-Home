using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// attach to UI Text component (with the full text already there)

public class UITextTypeWriter_Menu : UITextTypeWriter
{

    public override void DoSomethingAfterPlayText(){
		base.DoSomethingAfterPlayText();
		GetComponentInParent<Animator>().Play("AppearTittle");
    }

}