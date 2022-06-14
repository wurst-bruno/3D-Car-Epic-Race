using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarPuertas : MonoBehaviour
{
    public GameObject puerta2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
