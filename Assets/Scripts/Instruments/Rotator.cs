using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _RotationSpeed = 100; //скорость
    [SerializeField] private Slider SpeedRotation;
    public bool StartRandomeRotation;
    public bool AllowResetRotation;
    private bool dragging = false; //проверочная переменная
    private Rigidbody _rb; //переменная для физики
    

    public void Set_RotationSpeed(){
        _RotationSpeed = SpeedRotation.GetComponent<Slider>().value;
    }

    private void Start()
    {
        
        _rb = GetComponent<Rigidbody>();//получаем физику
        //рандомный поворот при спавне объекта 
        if(StartRandomeRotation){
            transform.rotation = new Quaternion(Random.Range(0,320),Random.Range(0,320),Random.Range(0,320),0);
        }
    }

    private void OnMouseDrag() {//проверка мышки не тащит ли она чего
        dragging = true;
    }

    private void Update()
    {
        if(AllowResetRotation && Input.GetKeyDown(KeyCode.Space)){
            gameObject.transform.rotation = Quaternion.identity;
        }
        if (Input.GetMouseButtonUp (0)){//если вдруг отпустил мышь то ты точно не тащишь ничего за собой
            dragging = false;
        }
    }

    private void FixedUpdate() {
        if(dragging){
            float x = Input.GetAxis("Mouse X") * _RotationSpeed * Time.fixedDeltaTime; //присваеваем переменным кручение вокруг осей
            float y = Input.GetAxis("Mouse Y") * _RotationSpeed * Time.fixedDeltaTime; //ВАЖНО НЕ ПО ОСИ А ВОКРУГ!!!

            _rb.AddTorque(Vector3.down*x); //делаем легкие толчки что бы оно крутилось на месте
            _rb.AddTorque(Vector3.forward*y);//если бы это было AddForce то оно перемещплось
        }
    }
    
}
