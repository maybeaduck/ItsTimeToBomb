﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using becomebetter;
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
    
    public event Action<int> EventExplosion;
    public event Action<int> EventEndFire;
    public event Action<int> EventMouseClick;

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
    

