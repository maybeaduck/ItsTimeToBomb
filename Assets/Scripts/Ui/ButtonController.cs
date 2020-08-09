using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator ButtonAnimator;
    public int id;
    public string SceneName;
    public bool ExitButton;
    private void OnMouseDown() {
        if(ExitButton == false){
            ButtonAnimator.SetBool("OnClick",true);
            StartCoroutine(Buttonanim());
        }else
        {
            ButtonAnimator.SetBool("OnClick",true);
            StartCoroutine(Buttonanim());
        }
    }
    private IEnumerator Buttonanim(){
        yield return new WaitForSeconds(0.6f);
        if(ExitButton == false){
            GameEventsManager.Instance._EventLevelLoader(id,SceneName);
        }
        else{
            GameEventsManager.Instance._EventExit(id);
        }
    }
    void Start()
    {
        ButtonAnimator.SetBool("OnClick",false);
    }
}
