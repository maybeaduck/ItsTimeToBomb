using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonAnumation : MonoBehaviour
{
    public int id;
    [SerializeField] private ButtonType _buttonType;
	private string animationName = "ButtonAnimation";
	private Vector3 delta;
    private bool pause = true;
    [SerializeField] private string LevelName;
    
    private void OnMouseDown() {
        if(!gameObject.GetComponent<Animation>().IsPlaying(animationName)){
            if(_buttonType == ButtonType.PauseButton){
                GameEventsManager.Instance._EventButtonDown(id,_buttonType,LevelName,pause);
                pause = !pause;
            }
            else{
                GameEventsManager.Instance._EventButtonDown(id,_buttonType,LevelName,false);
            }
			delta = transform.position - transform.parent.position;
			transform.parent.Translate(delta);
			gameObject.GetComponent<Animation>().Play(animationName);
		}
    }
    public void OnPlay(){
        if(pause == true){
            GameEventsManager.Instance._EventButtonDown(id,_buttonType,LevelName,pause);
            pause = false;
        }
    }
}
