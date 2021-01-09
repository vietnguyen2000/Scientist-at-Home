using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boom : ClickableObject
{
    public float secondAlive = 3;
    protected override void OnEnable() {
        base.OnEnable();
        StartCoroutine(DisableAfterTime(secondAlive));
    }
    protected override void UpdateProgress()
    {
        this.gameManager.progressBar.Increment(this.unit);
        MyCamera.Shake(0.3f,0.2f);
        animator.Play("Explosion",0);
        StartCoroutine(DisableAfterAnimationState("Explosion"));
    }

    IEnumerator DisableAfterTime(float sec){
        yield return 0;
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}
