using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BadBubble : Bubble
{
    protected override void UpdateProgress()
    {
        this.gameManager.progressBar.Increment(this.unit);
    }
}
