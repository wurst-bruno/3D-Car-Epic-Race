﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Text vel_actual;
    public int vidas;
    public float movementSpeed;
    float movementSpeedBackUp;
    public float RotationSpeed;
    public GameObject sppedCube;
    bool isSpeedMod = false;
    float speedModTime;
    float Vueltas;
    
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
        if(isSpeedMod)
        {
            speedModTime -= Time.deltaTime;
            if(speedModTime <= 0)
            {
                isSpeedMod = false;
                speedModTime = 0;
                movementSpeed = movementSpeedBackUp;
            }
        }
        if (Vueltas ==3)
        {
            Debug.Log("Hola mama");
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SpeedUP")
        {
            movementSpeed = 0.6f;
            Destroy(col.gameObject);
            isSpeedMod = true;
            speedModTime = 15f;
        }
        if (col.gameObject.tag == "DeathWall")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (col.gameObject.name == "Meta")
        {
            Vueltas++;
        }

        
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Pasto")
        {
            movementSpeed = 0.1f;
            isSpeedMod = true;
            speedModTime = 0.1f;
            vidas--;
            for (int i = 0; i < vidas; i--)
            {
                if (i == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }

            }
        }
    }
}
