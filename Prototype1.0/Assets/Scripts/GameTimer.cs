using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    public float timeLeft = 0.0f;


    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > 60 && timeLeft < 60.1)
        {
            Debug.Log("next scene");
        }
    }
}

