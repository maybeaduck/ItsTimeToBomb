using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using becomebetter;
public class HpController : MonoBehaviour
{
    
    /* 
    Hp controller
    3больших сердца = 3.0
    Золотое считается отдельно
    за обычный взрыв -1 полное сердце
    за меньший взрыв -0.5
    если переменная меньше 0 или равна ему то случается конец игры

    смена тайла с сердешком осуществляется через свитч кейс в апдейте после того как будет затронут євент -хп
    тоже самое с золотым просто золотое тратится в приоритете.
    =====
    Подсчет проплаченого здоровья ведется отдельно 
    максимум 1.0 

    =====
    мини бомбы уменьшют хп на 0.2 
    Большая бомба на 1
    средняя бомба на 0.5
    Золотая на 1 + отбирает монеты 
    */
    public int id;
    public float hp1 = 1;
    public float hp2 = 1;
    public float hp3 = 1;
    public float hpG = 0;
    
    [SerializeField] private GameObject HpInterface;

    private void OnEnable() {
        GameEventsManager.Instance.EventTakeDamage += takedamage;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventTakeDamage -= takedamage;
    }
    public void takedamage(int id, float amountdamage){
        if(id == this.id){
        if(hpG > 0){
            hpG -= amountdamage;
            updateicon(hpG,HpInterface.transform.GetChild(3).gameObject);
            _setData();
            return;
        }
        if(hp3 > 0){
            hp3 -= amountdamage;
            updateicon(hp3,HpInterface.transform.GetChild(2).gameObject);
            _setData();
            return;
        }
        if(hp2 > 0){
            hp2 -= amountdamage;
            updateicon(hp2,HpInterface.transform.GetChild(1).gameObject);
            _setData();
            return;
        }
        if(hp1 > 0){
            hp1 -= amountdamage;
            updateicon(hp1,HpInterface.transform.GetChild(0).gameObject);
            _setData();
            return;
        }
        }
    }
    public void updateicon(float hpcount,GameObject hpconteiner){
        if(hpcount>=0.51){
            hpconteiner.transform.GetChild(2).gameObject.SetActive(true);
            hpconteiner.transform.GetChild(1).gameObject.SetActive(false);
            hpconteiner.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(hpcount<=0.5 && hpcount != 0){
            hpconteiner.transform.GetChild(2).gameObject.SetActive(false);
            hpconteiner.transform.GetChild(1).gameObject.SetActive(true);
            hpconteiner.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(hpcount<= 0){
            hpconteiner.transform.GetChild(2).gameObject.SetActive(false);
            hpconteiner.transform.GetChild(1).gameObject.SetActive(false);
            hpconteiner.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    


    public void _setData(){
        GameController.Instance._setHpData(hp1,hp2,hp3,hpG);
    }
    public void _getData(){
        GameController.Instance._getHpData(hp1,hp2,hp3,hpG);
        updateHp();
    }
    public void updateHp(){
        updateicon(hp1,HpInterface.transform.GetChild(0).gameObject);
        updateicon(hp1,HpInterface.transform.GetChild(1).gameObject);
        updateicon(hp1,HpInterface.transform.GetChild(2).gameObject);
        updateicon(hp1,HpInterface.transform.GetChild(3).gameObject);
    }
    private void Start() {
        _getData();
    }
    private void Update() {
        if(hp1 == 0 && hp2 == 0 && hp3 == 0 && hpG == 0){
            GameEventsManager.Instance._EventGameOver(id);
        }
    }
}
