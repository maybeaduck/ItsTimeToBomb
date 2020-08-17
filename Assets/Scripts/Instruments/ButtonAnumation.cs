using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonAnumation : MonoBehaviour
{
    public int id;
    [SerializeField] private ButtonType _buttonType;
	private string animationName = "ButtonAnimation";
	private Vector3 delta;
    [SerializeField] private string LevelName;
    private void OnMouseDown() {
        if(!gameObject.GetComponent<Animation>().IsPlaying(animationName)){
            GameEventsManager.Instance._EventButtonDown(id,_buttonType,LevelName);
			delta = transform.position - transform.parent.position;
			transform.parent.Translate(delta);
			gameObject.GetComponent<Animation>().Play(animationName);
		}
    }
}
