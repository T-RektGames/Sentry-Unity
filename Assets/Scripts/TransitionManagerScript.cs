﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManagerScript : MonoBehaviour {

	public GameObject sentryText, by, tRekt, bottomCloud, topCloud, redLine;
	public float speed;
	private int counter;
	private bool startGame = false;
	private Color tmp;
	//private AudioSource mainTheme;


	// Use this for initialization
	void Start () {
		counter = 0;
		//mainTheme = gameObject.GetComponent<AudioSource> ();
		//mainTheme.time = PlayerPrefs.GetFloat ("Playback Time", 0);
		//counter2 = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (startGame == false) {
			counter += 1;

			for (int i = 0; i < Input.touchCount; i++) {

				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					startGame = true;
					counter = 0;
				}

			}

//			if (Input.GetMouseButtonDown (0)) {
//				startGame = true;
//				counter = 0;
//			}
		}
			
		if (startGame == true) {
			counter += 1;
			moveUp ();
			moveDown ();
			makeTransparent ();

		

			if (redLine.transform.position.y < -0.56) {

				bringRedLine ();
			} else {
				redLine.GetComponent<Rigidbody2D> ().velocity = transform.up * 0;
			}

			if (counter == 90) {
				if (PlayerPrefs.GetInt ("Seen Tutorial", 0) == 1) {
					SceneManager.LoadScene (2);
				} else {
					SceneManager.LoadScene (4);
				}
				//PlayerPrefs.SetFloat ("Playback Time", mainTheme.time);
			}

		}

	}

	private void moveUp(){
		topCloud.GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		sentryText.GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
	}

	private void moveDown(){
		bottomCloud.GetComponent<Rigidbody2D> ().velocity = transform.up * speed*-1;
		by.GetComponent<Rigidbody2D> ().velocity = transform.up * speed * -1;
		tRekt.GetComponent<Rigidbody2D> ().velocity = transform.up * speed * -1;


	}

	private void bringRedLine(){


		redLine.GetComponent<Rigidbody2D> ().velocity = transform.up * speed;

	}

	private void makeTransparent(){
		tmp = sentryText.GetComponent<Text>().color;
		if (tmp.a > 0) {
			tmp.a -= speed / 4 * Time.deltaTime;
		}
		sentryText.GetComponent<Text>().color = tmp;
	}
}
