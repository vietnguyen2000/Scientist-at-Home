using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class GoodBubble : Bubble
{
    protected override void UpdateProgress()
    {
        base.UpdateProgress();
        this.gameManager.progressBar.Increment(this.unit);
    }
}
