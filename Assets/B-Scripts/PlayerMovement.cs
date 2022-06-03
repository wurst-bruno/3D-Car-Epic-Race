using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    float movementSpeedBackUp;
    public float RotationSpeed;
    
    

   
    void Start()
    {
        movementSpeedBackUp = movementSpeed;
        //SceneManager.LoadScene("Scene"); carga la sig escena , se podría usar al final.

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += new Vector3(0, 0, movementSpeed); es lo mismo que lo de acá abajo
            transform.Translate(0, 0, movementSpeed);
                    }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, RotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -RotationSpeed, 0);
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        

        //Colision con objeto de veolidad
        if (col.gameObject.name == "Speed")
        {
            movementSpeed = 0.15f;
            //Variable dentro de un temporizar
        }
        //if donde si la variable es igual a 0 MovementSeed == BackUp

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Asfalto")
        {
            movementSpeed = 0.1f;
        }
        if (collisionInfo.gameObject.name == "Pasto")
        {
            movementSpeed = 0.05f;
        }
    }

   
}
