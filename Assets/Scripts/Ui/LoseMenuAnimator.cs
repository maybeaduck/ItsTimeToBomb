using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuAnimator : MonoBehaviour
{
    private string animationName = "MenuAnimation";
	private Vector3 delta;

    private void OnEnable() {
        if(!gameObject.GetComponent<Animation>().IsPlaying(animationName)){
			delta = transform.position - transform.parent.position;
			transform.parent.Translate(delta);
			gameObject.GetComponent<Animation>().Play(animationName);
		}
    }

}
