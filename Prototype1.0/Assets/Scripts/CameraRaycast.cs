using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycast : MonoBehaviour
{
   [SerializeField]
    private GameObject label1;
    [SerializeField]
    private GameObject crossCheckRibbon;
    [SerializeField]
    private GameObject slides;
    [SerializeField]
    private GameObject slidesStatic;
    [SerializeField]
    private AudioSource slideMovement;


    public float rayLength;
    public LayerMask layermask;

    public void Start()
    {
        crossCheckRibbon.SetActive(false);
        label1.SetActive(false);
    }



    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                Debug.Log("Something was clicked!");

                if (hit.collider.gameObject == slides) 
                {
                    Debug.Log("slides have been hit");
                    ArmTheSlides();

                }

                if (hit.collider.gameObject == label1)
                {
                    MoveTheSlides();
                }

            }

         }


    }

    private void MoveTheSlides()
    {
        Debug.Log("move the slides");
        slideMovement.Play();
        Destroy(slides);
        slidesStatic.SetActive(true);
        label1.SetActive(false);
        crossCheckRibbon.SetActive(true);
    }

    private void ArmTheSlides()
    {
        label1.SetActive(true);
    }
}

