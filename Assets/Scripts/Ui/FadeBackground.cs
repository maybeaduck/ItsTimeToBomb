using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBackground : MonoBehaviour
{
    public Color Alpha;
    private void Start() {
        Alpha = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Alpha;
    }
}
