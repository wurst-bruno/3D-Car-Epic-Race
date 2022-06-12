using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{


    public GameObject Ganaste;
    // Use this for initialization
    void Start()
    {
        
    }
   
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.name == "Meta")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Ganaste.SetActive(true);

        }


    }
}