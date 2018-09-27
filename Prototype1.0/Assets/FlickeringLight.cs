using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

    [SerializeField]
    private Light pinkACPLight;


    float timeOn = 0.2f;
    float timeOff = 0.5f;
    private float changeTime = 0;


    void Update()
    {
        if (Time.time > changeTime)
        {
            pinkACPLight.enabled = !pinkACPLight.enabled;
            if (pinkACPLight.enabled)
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
                changeTime = Time.time + timeOff;
            }
        }
    }


}
