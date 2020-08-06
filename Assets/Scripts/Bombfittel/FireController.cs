using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireController : MonoBehaviour
{
    //смена материала фителя когда он догорает
    [Header("idEvent")]
    public int id;
    [Header("Времени до конца")]
    public float TimeUntilTheEnd;//Сколько времени дается?
    
    [Tooltip("Список требуимых экземпляров")]
    [Header("Огонь будет стремится к")]
    [SerializeField] private GameObject TargetObject;
    [Header("Фитиль")]
    [SerializeField] private GameObject Fittel;
    [Header("Бомба")]
    [SerializeField] private GameObject Bomb;
    [Header("Объект на котором находится компонент таймер")]
    [SerializeField] private GameObject Timer;
    [Header("Цвет выгоренного фитиля")]
    [SerializeField] private Color endColor;//Цвет который нужно сменить

    private float _TimerStep;//Сколько процентов дороги обьект пройдет за 1единицу времени
    private float TimerPersent = 0f;//сколько процентов пути уже прошел
    
    void Start()
    {
        _TimerStep = 1/TimeUntilTheEnd;//узнаем единицу времени
        Debug.Log(_TimerStep);
        Debug.Log(1/TimeUntilTheEnd);
    }

    void Update()
    {
        if(Bomb.GetComponent<BombController>()._OnFire){
            TimerPersent = Timer.GetComponent<Timer>().GetTimerSeconds() / TimeUntilTheEnd;
        }
        

        if (Bomb.GetComponent<BombController>()._OnFire){//проверяем не закончилось ли время
            if(Timer.GetComponent<Timer>().GetTimerSeconds() >= TimeUntilTheEnd){
                Debug.Log("EventExploution!");
                GameEventsManager.Instance._EventExplosion(id);
            }
        }
    }
    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, TargetObject.transform.position,TimerPersent * Time.fixedDeltaTime);
        //выше прото лерп который переносит группу парктикло до нужой точки - таргета
        Fittel.GetComponent<MeshRenderer>().materials[0].color = Color.Lerp(Fittel.GetComponent<MeshRenderer>().materials[0].color , endColor, TimerPersent * Time.fixedDeltaTime);

    }
}
