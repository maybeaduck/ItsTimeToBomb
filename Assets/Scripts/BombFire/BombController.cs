using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class BombController : MonoBehaviour, IPointerClickHandler//Клик хандлер просто знает где мышка и обрабатывает все что  с ней связано
{
    //Сделать эффект дыма при нажатии мышкой по огню 
    public int id;
    public Text info;
    public bool _OnFire;

    [SerializeField] private int _CountTaps;
    [SerializeField] private int _RequiredTaps;
    [SerializeField] private GameObject _Fire;
    [SerializeField] private GameObject _TargetFire;
    [SerializeField] private GameObject _FireOut;

    [HideInInspector] public bool _Explosion;

    private void OnEnable() {
        GameEventsManager.Instance.EventEndFire += OnDefuseBomb;
        GameEventsManager.Instance.EventExplosion += OnBombExplosion;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventEndFire -= OnDefuseBomb;
        GameEventsManager.Instance.EventExplosion -= OnBombExplosion;
    }

    IEnumerator EndFire(){
        yield return new WaitForSeconds(1.5f);//партиклы сменяются - огонь тухнет (Сделать скорость тушения быстрее)
        _Fire.SetActive(false); 
    }

    // Проверка нажатий на тригер
    public void OnPointerClick(PointerEventData eventData){ //Наследник класса, Чекает данные о мыхе
        if( eventData.pointerId == -1 && _OnFire && !_Explosion){//поинтерайди это кнопка -1 лкм, -2 пкм, -3 средняя
            _CountTaps++;
        }
    }
    
    private void Start()
    {  
        _OnFire = true;
        _Explosion = false;
    }
    
    public void OnDefuseBomb(int id){
        if (id == this.id){
        info.text = "You WIN";
        _OnFire = false;
        _FireOut.SetActive(true);//еще немного партиклов
        StartCoroutine(EndFire());
        }
    }
    public void OnBombExplosion(int id){
        if (id == this.id){
        info.text = "You LOSE";
        _Explosion = true;
        }
    }

    private void Update()
    {
        if(_CountTaps == _RequiredTaps){
            GameEventsManager.Instance._EventEndFire(id);
        }
    }
    
}
