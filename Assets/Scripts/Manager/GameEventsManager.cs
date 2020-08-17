﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using becomebetter;

public enum ButtonType{
    DefaultButton,
    LongADSButton,
    ShortADSButton,
    BanerADSButton,
    SwitchLevelButton,
    ExitGameButton
}

public class GameEventsManager : Singleton<GameEventsManager>
{
    //list event

    //public event Action<int> NameEvent;

    /*
    public void _NameEvent(int id){
        if(NameEvent != null){
            NameEvent(id);
        }
    }
    */
    public event Action<int,ButtonType,string> EventButtonDown;
    public event Action<int> EventExplosion;
    public event Action<int> EventEndFire;
    public event Action<int> EventMouseClick;
    public event Action<int,string> EventLevelLoader;
    public event Action<int> EventExit;
    public event Action<int> EventLoseMenu;
    public event Action<int,float> EventTakeDamage;
    public event Action<int> EventGameOver;

    public void _EventGameOver(int id){
        if(EventGameOver != null){
            EventGameOver(id);
        }
    }
    public void _EventTakeDamage(int id, float amountdamage){
        if(EventTakeDamage != null){
            EventTakeDamage(id,amountdamage);
        }
    }
    public void _EventLoseMenu(int id){
        if(EventLoseMenu != null){
            EventLoseMenu(id);
        }
    }
    public void _EventButtonDown(int id,ButtonType Btype,string levelName){
        if(EventButtonDown != null){
            EventButtonDown(id,Btype,levelName);
        }
    }
    public void _EventExit(int id){
        if(EventExit != null){
            EventExit(id);
        }
    }
    public void _EventLevelLoader(int id,string SceneName){
        if(EventLevelLoader != null){
            EventLevelLoader(id,SceneName);
        }
    }
    public void _EventExplosion(int id){
        if(EventExplosion != null){
            EventExplosion(id);
        }
    }

    public void _EventEndFire(int id){
        if(EventEndFire != null){
            EventEndFire(id);
        }
    }

    public void _EventMouseClick(int id){
        if(EventMouseClick != null){
            EventMouseClick(id);
        }
    }




}
    

