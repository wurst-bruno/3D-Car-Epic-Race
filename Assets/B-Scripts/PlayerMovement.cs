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
        
    }

    // Update is called once per frame
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
        if (col.gameObject.name == "Pasto")
        {
            movementSpeed = movementSpeed/2;
            //SceneManager.LoadScene("Scene"); carga la sig escena , se podría usar al final.

        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Pasto")
        {
            movementSpeed = movementSpeedBackUp;
        }
    }
}