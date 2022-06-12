using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Text vel_actual;
    public Text rot_actual;
    public Text lap_actual;

    public GameObject Ganaste;
    public GameObject Moriste;


    public float movementSpeed;
    float movementSpeedBackUp;
    float RotationSpeedBackUp;
    public float RotationSpeed;
    public GameObject sppedCube;
    bool isSpeedMod = false;
    float speedModTime;
    float Vueltas = 1;
    float delay = 3;
    public GameObject Chancho;
    public GameObject PirelliCube;


    void Start()
    {
        movementSpeedBackUp = movementSpeed;
        RotationSpeedBackUp = RotationSpeed;
        //SceneManager.LoadScene("Scene"); carga la sig escena , se podría usar al final.

    }

    void Update()
    {
        lap_actual.text = "Lap actual:  " + Vueltas.ToString() + "/3";

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
        rot_actual.text = "Rotation Speed:  " + RotationSpeed.ToString();

        if (isSpeedMod)
        {
            speedModTime -= Time.deltaTime;
            if (speedModTime <= 0)
            {
                isSpeedMod = false;
                speedModTime = 0;
                movementSpeed = movementSpeedBackUp;
                RotationSpeed = RotationSpeedBackUp;
            }
        }
        

        if (Vueltas == 3)
        {
            Debug.Log("Hola mama");
            Ganaste.SetActive(true);
            InstantiateChancho();
            StartCoroutine(Countdown());

        }
        IEnumerator Countdown()
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        if (col.gameObject.tag == "RotUp")
        {
            RotationSpeed = 3f;
            Destroy(col.gameObject);

        }
        if (col.gameObject.tag == "DeathWall")
        {
            Moriste.SetActive(true);
            InstantiatePirelliCube();

            StartCoroutine(Countdown());
        }
        IEnumerator Countdown()
        {
            yield return new WaitForSeconds(delay);
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

        }

    }
    public void InstantiateChancho()
    {
        Instantiate(Chancho);

    }
    public void InstantiatePirelliCube()
    {
        Instantiate(PirelliCube);
    }

}
