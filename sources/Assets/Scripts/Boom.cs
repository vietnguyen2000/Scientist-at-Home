using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boom : ClickableObject
{
    protected override void UpdateProgress()
    {
        this.gameManager.progressBar.Increment(this.unit);
    }
}
