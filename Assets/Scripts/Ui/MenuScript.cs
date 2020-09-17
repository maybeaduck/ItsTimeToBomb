using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public int id;
    public bool OnButtonDown = false;
    [SerializeField] private GameObject _LoseObject;
    private Vector3 delta;
    private void OnEnable() {
        GameEventsManager.Instance.EventButtonDown += OnButtonEventTrigger;
        GameEventsManager.Instance.EventGameOver += OnLoseMenu;
        GameEventsManager.Instance.EventLevelLoader += OnLoadLevel;
        GameEventsManager.Instance.EventExit += OnExit;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventButtonDown -= OnButtonEventTrigger;
        GameEventsManager.Instance.EventLevelLoader -= OnLoadLevel;
        GameEventsManager.Instance.EventGameOver -= OnLoseMenu;
        GameEventsManager.Instance.EventExit -= OnExit;
    }
    public void OnLoadLevel(int id,string levelname){
        if(id == this.id){
            SceneManager.LoadScene(levelname);
        }
        
    }
    public void OnExit(int id){
        if(id == this.id){
        Application.Quit();
        }
    }
    private void OnLoseMenu(int id){
        _LoseObject.SetActive(true);
    }
    private void OnButtonEventTrigger(int id,ButtonType BType,string levelname,bool pause){
        if(id == this.id){
            switch (BType){

                case ButtonType.LongADSButton:
                if(OnButtonDown == false){
                    OnButtonDown = true;
                    StartCoroutine(LongADS());
                } 
                break;

                case ButtonType.SwitchLevelButton:
                if(OnButtonDown == false){
                    OnButtonDown = true;
                    StartCoroutine(LevelLoader(levelname));
                }
                break;

                case ButtonType.ExitGameButton:
                if(OnButtonDown == false){
                    OnButtonDown = true;
                    GameEventsManager.Instance._EventExitTheParty(id);
                    StartCoroutine(GameExit());
                }  
                break;
                case ButtonType.RestartThisParty:
                    OnButtonDown = true;
                    GameEventsManager.Instance._EventExitTheParty(id);
                    StartCoroutine(LevelLoader(levelname));
                break;
                case ButtonType.PauseButton:
                    OnButtonDown = true;
                    StartCoroutine(PauseButton(pause));
                break;
            }
        }
    }
    private IEnumerator PauseButton(bool pause){
        yield return new WaitForSeconds(0.3f);
        if(pause == true){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
        
        GameEventsManager.Instance._EventPause(id,pause);
    }
    private IEnumerator LongADS(){
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Продажное Сообщение");
        OnButtonDown = false;
    }
    private IEnumerator LevelLoader(string _levelname){
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(_levelname);
        OnButtonDown = false;
    }
    private IEnumerator GameExit(){
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
        OnButtonDown = false;
    }
}
