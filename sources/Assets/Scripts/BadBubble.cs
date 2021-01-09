using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BadBubble : Bubble
{
    protected override void UpdateProgress()
    {
        base.UpdateProgress();
        this.gameManager.progressBar.Increment(this.unit);
        MyCamera.Shake(0.3f,0.2f);
    }
}
