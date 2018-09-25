using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    
    public float timeLeft = 0.0f;

    public AudioSource source;


    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > 30 && timeLeft < 30.1)
        {
            PhoneRing();
        }
    }

    private void PhoneRing()
    {
        source.Play();
    }
}
