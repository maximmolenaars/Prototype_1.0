using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlightRayCast : MonoBehaviour
{
    //AUDIO
    private float timeLeft = 0.0f;
    public AudioSource source;

    //OBJECTS
    public GameObject ACP_light;
    public GameObject phone;
    public GameObject phonePopup;
    public Light pinkLight;

   

    public float rayLength;
    public LayerMask layermask;

    private void Start()
    {
        phonePopup.SetActive(false);
        ACP_light.SetActive(false);
        pinkLight.enabled = false;
        phone.GetComponent<MeshCollider>().enabled = false;
    }

    public void Update()
    {

        timeLeft += Time.deltaTime;
        if (timeLeft > 20 && timeLeft < 20.05)
        {
            PhoneRing();
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                Debug.Log("Something was clicked!");
                if (hit.collider.gameObject == phone)
                {
                    phonePopup.SetActive(true);

                }

                if (hit.collider.gameObject == phonePopup)
                {
                    Debug.Log("Purser chat");
                    ACP_systemOff();
                    phonePopup.SetActive(false);
                }

            }

         }


    }


    private void PhoneRing()
    {
        source.Play();
        phone.GetComponent<MeshCollider>().enabled = true;
        ACP_system();

    }


    private void ACP_system()
    {
        ACP_light.SetActive(true);
        pinkLight.enabled = true;
    }

    private void ACP_systemOff()
    {
        ACP_light.SetActive(false);
        pinkLight.enabled = false;
    }

}

