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

    //Crosscheck
    [SerializeField]
    private GameObject crossCheckUI;
    [SerializeField]
    private GameObject thumbsUp;
    [SerializeField]
    private GameObject thumbsDown;
    [SerializeField]
    private GameObject ribbon_crossCheck;
    [SerializeField]
    private GameObject SlidesOtherDoor;
    [SerializeField]
    private GameObject SlidesOtherDoorArmed;




    public float rayLength;
    public LayerMask layermask;

    public void Start()
    {
        crossCheckRibbon.SetActive(false);
        label1.SetActive(false);
        crossCheckUI.SetActive(false);
        ribbon_crossCheck.SetActive(false);
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

                if (hit.collider.gameObject == thumbsDown)
                {
                    thumbsDownRoutine();
                }

                if (hit.collider.gameObject == thumbsUp)
                {
                    thumbsUpRoutine();
                }

            }

         }


    }



    //ARMING SLIDES

    private void MoveTheSlides()
    {
        Debug.Log("move the slides");
        slideMovement.Play();
        Destroy(slides);
        slidesStatic.SetActive(true);
        label1.SetActive(false);
        crossCheckRibbon.SetActive(true);
        CrossCheck();
    }


    private void ArmTheSlides()
    {
        label1.SetActive(true);
    }


    //CROSSCHECK

    private void CrossCheck()
    {
        crossCheckUI.SetActive(true);

    }

    private void thumbsDownRoutine()
    {
        thumbsUp.SetActive(false);
        CrossCheckRoutine();

    }

    private void thumbsUpRoutine()
    {
        thumbsDown.SetActive(false);
        CabinCrewTakeYourSeats();

    }

    private void CrossCheckRoutine()
    {
        ribbon_crossCheck.SetActive(true);
        Destroy(SlidesOtherDoor);
        SlidesOtherDoorArmed.SetActive(true);
        slideMovement.Play();
        CabinCrewTakeYourSeats();
    }

    private void CabinCrewTakeYourSeats()
    {
        Debug.Log("Cabin Crew Take Your Seats");
    }
}

