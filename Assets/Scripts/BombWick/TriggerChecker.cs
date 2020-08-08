using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TriggerChecker : MonoBehaviour,IPointerClickHandler//Клик хандлер просто знает где мышка и обрабатывает все что  с ней связано
{
    public int id;
    public void OnPointerClick(PointerEventData eventData){ //Наследник класса, Чекает данные о мыхе
        if( eventData.pointerId == -1 ){//поинтерайди это кнопка -1 лкм, -2 пкм, -3 средняя
            GameEventsManager.Instance._EventMouseClick(id);
        }
    }
}
