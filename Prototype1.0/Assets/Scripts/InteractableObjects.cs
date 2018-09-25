using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour {

    public GameObject label1;
    public GameObject crossCheckRibbon;
    public GameObject slides;

	// Use this for initialization
    public void Start () {

        label1.SetActive(false);
        crossCheckRibbon.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
