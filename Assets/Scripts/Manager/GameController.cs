using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using becomebetter;
public class GameController : Singleton<GameController>
{
    private int id = 1;
    private float _dataHp1 = 1f;
    private float _dataHp2 = 1f;
    private float _dataHp3 = 1f;
    private float _dataHpG = 0f;
    private void OnEnable() {
        GameEventsManager.Instance.EventGameOver += OnGameOver;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventGameOver -= OnGameOver;
    }
    public void _setHpData(float _hp1,float _hp2,float _hp3,float _hpG){
        _dataHp1 = _hp1;
        _dataHp2 = _hp2;
        _dataHp3 = _hp3;
        _dataHpG = _hpG;
    }
    public void _getHpData(float _hp1,float _hp2,float _hp3,float _hpG){
        _hp1 = _dataHp1;
        _hp2 = _dataHp2;
        _hp3 = _dataHp3;
        _hpG = _dataHpG;
    }
    private void OnGameOver(int id){
        if (id == this.id){
            GameEventsManager.Instance._EventLoseMenu(id);
        } 
    }
}
