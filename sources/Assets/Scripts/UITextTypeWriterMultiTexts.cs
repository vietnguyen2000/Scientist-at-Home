using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// attach to UI Text component (with the full text already there)

public class UITextTypeWriterMultiTexts : MonoBehaviour, IPointerClickHandler
{

	public Text txt;
    public float secsPerText = 0.025f;
	string[] stories;
    protected bool skip;
	protected virtual void Awake () 
	{
		if (txt == null) txt = GetComponent<Text>();
		// story = txt.text;
		txt.text = "";
        stories = new string[] {"As a scientist, I want to make something for the world to defend coronavirus. hmm, but now i dont have any idea to do that... I just want to take a shower.", "I've figured out the idea, now let's head to my computer and start planning our cure. Quickly, otherwise all of those Eureka thoughts and ideas will vanish from my head, and I don't know when I'll get another revelation!", "Hmm, the plan has been created. It could work, now let's make it at my DIY lab and hopefully save humanity from this whole mess. Even as an introvert I hate being at home for too long like this, I miss my awesome laboratory."};
		// stories[0] = "As a scientist, I want to make something for the world to defend coronavirus. hmm, but now i dont have any idea to do that... I just want to take a shower.";
		// stories[1] = "I've figured out the idea, now let's head to my computer and start planning our cure. Quickly, otherwise all of those Eureka thoughts and ideas will vanish from my head, and I don't know when I'll get another revelation!";
		// stories[2] = "Hmm, the plan has been created. It could work, now let's make it at my DIY lab and hopefully save humanity from this whole mess. Even as an introvert I hate being at home for too long like this, I miss my awesome laboratory.";
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
        skip = false;
		int unlockedLevel = SaveLoadManager.Instance.SavedData.level;
        Debug.Log(unlockedLevel);
		foreach (char c in stories[unlockedLevel]) 
		{
			txt.text += c;
            if (skip){
                txt.text = stories[unlockedLevel];
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