﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SplashScreenScript : MonoBehaviour {
	private Animator anim;
	//private bool oneTimeOnly, oneTimeOnly2;
	private int counter;
	private AudioSource slash;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.enabled = false;
		counter = 0;
		slash = gameObject.GetComponent<AudioSource> ();
		//PlayerPrefs.SetFloat ("Playback Time", 0);

		//oneTimeOnly = false;
		//oneTimeOnly2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter += 1;
		if (counter == 120) {
			anim.enabled = true;
			slash.Play ();


			//oneTimeOnly = true;
		}



		if (counter == 300) {
			//oneTimeOnly2 = true;
			SceneManager.LoadScene (1);
		}
	}
}
