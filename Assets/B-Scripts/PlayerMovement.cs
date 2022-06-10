using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Text vel_actual;

    public float movementSpeed;
    float movementSpeedBackUp;
    public float RotationSpeed;
    public GameObject sppedCube;


    void Start()
    {
        movementSpeedBackUp = movementSpeed;
        //SceneManager.LoadScene("Scene"); carga la sig escena , se podría usar al final.

    }

    void Update()
    {

        transform.Translate(0, 0, movementSpeed * Input.GetAxis("Vertical"));

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    //transform.position += new Vector3(0, 0, movementSpeed); es lo mismo que lo de acá abajo
        //    transform.Translate(0, 0, movementSpeed);
        //}
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0, 0, -movementSpeed);
        //}
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, RotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -RotationSpeed, 0);
        }

        vel_actual.text = "Velocidad actual:  " + movementSpeed.ToString();

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Speed1")
        {
            movementSpeed = 1f;
            Destroy(sppedCube);
        }

        //Colision con objeto de veolidad
        //if (col.gameObject.name == "S peed")
        //{
        //    movementSpeed = 0.15f;
        //    Variable dentro de un temporizar
        //}
        //if donde si la variable es igual a 0 MovementSeed == BackUp

    }
    void OnColiisionExit(Collision Col)
    {
        if(Col.gameObject.name == "Pasto")
        {
            movementSpeed = 0.4f;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Pasto")
        {
            movementSpeed = 0.1f;


            // Si no sirve el if del void enter usar esto;

            //if (collisionInfo.gameObject.name == "Speed")
            //{
            //    movementSpeed = 0.05f;
            //}
        }
        else
        {
            movementSpeed = 0.4f;
        }
       
    }
}
