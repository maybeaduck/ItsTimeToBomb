using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticle : MonoBehaviour, IPooledObject
{
    
    public void OnObjectSpawn()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

}
