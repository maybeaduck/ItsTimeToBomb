using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public int id;
    private void OnEnable() {
        GameEventsManager.Instance.EventLevelLoader += OnLoadLevel;
        GameEventsManager.Instance.EventExit += OnExit;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventLevelLoader -= OnLoadLevel;
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
}
