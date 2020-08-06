using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
        //do not edit
        public int id;
        public int _timersecond = 0;
        public bool getseconds = false;
        public int timersecond;
        public float secondgametime = 0;
        public float secondgametimereset = 0;
        public float minedgametime = 0;
        public float minegametimereset = 0;
        bool _onfire = true;
        bool _explosion = false;
        
        private void OnEnable() {
            GameEventsManager.Instance.EventEndFire += OnFire;
            GameEventsManager.Instance.EventExplosion += OnExplosion;
        }
        private void OnDisable() {
            GameEventsManager.Instance.EventEndFire -= OnFire;
            GameEventsManager.Instance.EventExplosion -= OnExplosion;
        }
        
        void OnFire(int id){
            if(id == this.id){
                _onfire = false;
            }
        }
        void OnExplosion(int id){
            if(id == this.id){
                _explosion = true;
            }
        }


        public int GetTimerSeconds(){
            ///НЕ ЗАБУДЬ ТАЙМЕР ВЫКЛЮЧИТЬ StopTimer();
            if ((_explosion = false) || (_onfire = true)){
                getseconds = true;
                return _timersecond;
            }
            else
            {
                getseconds = false;
                return _timersecond;
            }   
        }
        void Update () {
        //up game timer translate in second
            secondgametime += Time.deltaTime;
            if (secondgametime >= 1f) {
                timersecond += 1;
                if(getseconds){
                    _timersecond += 1;
                }
                else{
                    _timersecond = 0;
                }
            }
            if (secondgametime >= 1f) {
                secondgametime = secondgametimereset;
            }
            //up second time translate into minutes
            if (timersecond >= 60) {
                minedgametime += 1;
                timersecond = 0;
            }
            if (minedgametime >= 60) {
                minedgametime = minegametimereset;
            }
            
        }
}
