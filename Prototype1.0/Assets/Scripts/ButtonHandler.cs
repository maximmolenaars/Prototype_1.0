﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	public void ChangeScene () {
        SceneManager.LoadScene("ArmSlidesSequence");
	}
	
	
}
