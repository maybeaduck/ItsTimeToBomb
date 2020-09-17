using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BombCounterScript : MonoBehaviour
{

    public int id;
    
    [SerializeField] private int _allGameBombCount = 0;
    [SerializeField] private TextMeshPro _bombCounterText;
    [SerializeField] private TextMeshPro _bombLoseCounterText;
    
    private void Start() {
        _allGameBombCount = GameController.Instance._getBombCountData();
        _drawBombCount();
    }
    private void OnEnable() {
        GameEventsManager.Instance.EventGameOver += _bombCountAddToAll;
        GameEventsManager.Instance.EventEndFire += _bombCountAdd;
        GameEventsManager.Instance.EventExitTheParty += _resetCounter;
    }
    private void OnDisable(){
        GameEventsManager.Instance.EventGameOver -= _bombCountAddToAll;
        GameEventsManager.Instance.EventEndFire -= _bombCountAdd;
        GameEventsManager.Instance.EventExitTheParty -= _resetCounter;
    }
    private void _resetCounter(int id){
        if(id == this.id){
            _allGameBombCount = 0;
        }
    }
    private void _bombCountAdd(int id){
        if(id == this.id){
            _allGameBombCount++;
            GameController.Instance._setBombCountData(_allGameBombCount);
            _drawBombCount();
        }
       
    }
    private void _drawBombCount(){
        _bombCounterText.text = _allGameBombCount.ToString();
        _bombLoseCounterText.text = _allGameBombCount.ToString();
    }
    private void _bombCountAddToAll(int id){
        if(id == this.id){
            GameController.Instance._setBombCountData(_allGameBombCount);
            
        }
    }
}
