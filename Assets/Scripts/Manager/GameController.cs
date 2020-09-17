using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using becomebetter;
public class GameController : Singleton<GameController>
{
    private int id = 1;
    private float _dataHp1 = 1f;
    private float _dataHp2 = 0f;
    private float _dataHp3 = 0f;
    private float _dataHpG = 0f;
    private int _BombCount = 0;
    public bool _OnGameOver = false;

    public int _getBombCountData(){
        return _BombCount;
    }
    public void _setBombCountData(int _BC){
        _BombCount = _BC;
    }

    private void OnEnable() {
        GameEventsManager.Instance.EventGameOver += OnGameOver;
        GameEventsManager.Instance.EventExitTheParty += ResetLevel;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventGameOver -= OnGameOver;
        GameEventsManager.Instance.EventExitTheParty -= ResetLevel;
    }
    public void _setHpData(float _hp1,float _hp2,float _hp3,float _hpG){
        _dataHp1 = _hp1;
        _dataHp2 = _hp2;
        _dataHp3 = _hp3;
        _dataHpG = _hpG;
    }
    public float[] _getHpData(){
        return new float[4]{_dataHp1,_dataHp2,_dataHp3,_dataHpG};
    }
    private void OnGameOver(int id){
        if (id == this.id){
            _OnGameOver = true;
            GameEventsManager.Instance._EventLoseMenu(id);
        } 
    }
    
    private void ResetLevel(int id){
        if (id == this.id){
        _dataHp1 = 1;
        _dataHp2 = 0;
        _dataHp3 = 0;
        _dataHpG = 0;
        }

    }
}
