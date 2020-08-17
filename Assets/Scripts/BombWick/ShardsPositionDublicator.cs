using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardsPositionDublicator : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;

    private void Update() {
        transform.position = _bomb.transform.position;
        transform.rotation = _bomb.transform.rotation;
    }
}