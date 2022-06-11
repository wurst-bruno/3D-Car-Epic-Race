using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text txtTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.timeSinceLevelLoad;
        txtTime.text = "El tiempo es de:  " + elapsedTime.ToString();

    }
    
}