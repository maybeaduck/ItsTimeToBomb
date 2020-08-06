using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    
    public void LoadLevel(string levelname){
        Application.LoadLevel(levelname);
    }
    public void Exit(){
        Application.Quit();
    }
    
    public void OnRestart(){ //сменил название возможно кнопка забіла о методе
        Application.LoadLevel("first bomb");
    }

    public void OnBackToMenu(){
        Application.LoadLevel("MainMenu");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
