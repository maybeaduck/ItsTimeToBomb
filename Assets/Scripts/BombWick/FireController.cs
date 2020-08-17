using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireController : MonoBehaviour
{
    //смена материала фителя когда он догорает
    [Header("idEvent")]
    public int id;
    [Header("Времени до конца")]
    public float TimeUntilTheEnd;//Сколько времени дается?
    [Header("Скорость горения фитиля")]
    [SerializeField] private float _SpeedWickFire;
    [Tooltip("Список требуимых экземпляров")]
    [Header("Огонь будет стремится к")]
    [SerializeField] private GameObject _TargetObject;
    [Header("Бомба")]
    [SerializeField] private GameObject _Bomb;
    [Header("Объект на котором находится компонент таймер")]
    [SerializeField] private GameObject _Timer;
    [Header("Цвет выгоренного фитиля")]
    [SerializeField] private Color _endColor;//Цвет который нужно сменить

    private float _TimerStep;//Сколько процентов дороги обьект пройдет за 1единицу времени
    private float _TimerPersent = 0f;//сколько процентов пути уже прошел
    private float _WickFirePercent = 0;
    private GameObject Wick;
    void Start()
    {
        _TimerStep = 1/TimeUntilTheEnd;//узнаем единицу времени
        Debug.Log(_TimerStep);
        Debug.Log(1/TimeUntilTheEnd);
    }
    private void OnTriggerEnter(Collider other) {
        if (other != null){
            _WickFirePercent = 0;
            if(other.transform.tag == "Wick"){
                Wick = other.gameObject;
            }
        }
    }
    void WickFire(){

        Wick.GetComponent<MeshRenderer>().materials[0].color = Color.Lerp(Wick.GetComponent<MeshRenderer>().materials[0].color , _endColor, _SpeedWickFire * Time.fixedDeltaTime);
    }
    void Update()
    {
        if(_Bomb.GetComponent<BombController>()._OnFire){
            _TimerPersent = _Timer.GetComponent<Timer>().GetTimerSeconds() / TimeUntilTheEnd;
        }
        

        if (_Bomb.GetComponent<BombController>()._OnFire){//проверяем не закончилось ли время
            if(_Timer.GetComponent<Timer>().GetTimerSeconds() >= TimeUntilTheEnd){
                Debug.Log("EventExploution!");
                GameEventsManager.Instance._EventExplosion(id);
                
            }
        }
    }
    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, _TargetObject.transform.position,_TimerPersent * Time.fixedDeltaTime);
        //выше прото лерп который переносит группу парктикло до нужой точки - таргета
        if(Wick != null){
            WickFire();
        }        
    }
    
}
