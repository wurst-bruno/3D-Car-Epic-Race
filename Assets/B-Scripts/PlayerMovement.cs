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
    int chanch = 1;
    int pircube = 1;


    void Start()
    {
        movementSpeedBackUp = movementSpeed;
        RotationSpeedBackUp = RotationSpeed;

    }

    void Update()
    {
        lap_actual.text = "Lap actual:  " + Vueltas.ToString() + "/3";

        transform.Translate(0, 0, movementSpeed * Input.GetAxis("Vertical"));
        transform.Rotate(0, RotationSpeed * Input.GetAxis("Horizontal"), 0);

        
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
            StartCoroutine(Countdown());
            while (chanch<100)
            {
                InstantiateChancho();
                chanch++;

            }

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
            movementSpeed = 0.5f;

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
            
            StartCoroutine(Countdown());
            while (pircube < 200)
            {
                InstantiatePirelliCube();


                pircube++;

            }
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
