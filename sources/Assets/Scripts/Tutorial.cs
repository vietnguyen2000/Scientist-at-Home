using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// attach to UI Text component (with the full text already there)

public class Tutorial : UITextTypeWriter
{

    public override void DoSomethingAfterPlayText(){
		base.DoSomethingAfterPlayText();
		
    }

}