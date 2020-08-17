using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;

    void Update()
    {
       Vector3 _explosionPos = transform.position;
        Collider[] _colliders = Physics.OverlapSphere(_explosionPos, radius);
        foreach (Collider hit in _colliders){
            Rigidbody _rb = hit.GetComponent<Rigidbody>();
            if(_rb != null){
                _rb.AddExplosionForce(power, _explosionPos, radius, 3.0F);
            }
        } 
    }
}
