using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioHandler : MonoBehaviour
{


    //CAMERA SHAKER
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;


    //TIMER
    public float timer = 0.0f;

    public AudioSource airplaneAmbient;
    public AudioSource engineShutoff;
    public AudioSource turbulance;
    public AudioSource brace;
    public AudioSource waterCrash;

    //SHAKER
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    //TIMER
    void Update()
    {
        

        timer += Time.deltaTime;
        if (timer > 15 && timer < 15.1)
        {
            engineShutoff.Play();
        }

        if (timer > 21 && timer < 21.1) 
        {
            turbulance.Play();
            turbulance.loop = true;
        }

        if(timer >= 21)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }

        if (timer > 23 && timer < 23.1)
        {
            brace.Play();
            brace.loop = true;
        }

        if (timer > 43 && timer < 43.1)
        {
            waterCrash.Play();
        }

        if (timer >= 45)
        {
            brace.Stop();
            turbulance.Stop();
        }

        if (timer >= 47)
        {
            SceneManager.LoadScene("FlightNoCallEvacuation");
        }

     }





}

