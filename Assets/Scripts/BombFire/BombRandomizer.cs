using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  
Выбор сложности?  
Наростание сложности с каждой новой пройденной бомбой?
На каждую сложность пак позиций
Вывести все в переменную 
Массив из позиий. Ok
*/
public class BombRandomizer : MonoBehaviour
{
    [Range(0,2)] public int Difficulty = 0; // Сложность 0- лекий;

    private float AdaptiveDifficulty;
    [Header("Позиции для 0й сложности")]
    [SerializeField] private GameObject[] poolPositionDifficulty0;
    [Header("Позиции для 1й сложности")]
    [SerializeField] private GameObject[] poolPositionDifficulty1;
    [Header("Позиции для 2й сложности")]
    [SerializeField] private GameObject[] poolPositionDifficulty2;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
