using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarPuertas : MonoBehaviour
{
    public GameObject puerta2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "ActivadorPuerta")
        {
            puerta2.SetActive(false);
        }

        if (col.gameObject.name == "DesactivadorPuerta")
        {
            puerta2.SetActive(true);
        }
    }

}
