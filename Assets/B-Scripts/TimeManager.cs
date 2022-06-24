using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text txtTime;
    public float customTime;
    public Text txtTimeCustom;


    void Start()
    {

    }

    void Update()
    {
        float elapsedTime = Time.timeSinceLevelLoad;
        txtTime.text = "El tiempo es de:  " + elapsedTime.ToString();
        customTime = 0;
    }

    
}