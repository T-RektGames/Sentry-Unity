﻿using UnityEngine;
using System.Collections;

public class SentryMove : MonoBehaviour
{


	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;
	public float health;
	private float nextFire;
	double halfScreen = Screen.height / 2.0;
	Vector2 screenPosition;
	public GameObject redLine;


	// Use this for initialization
	void Start ()
	{
		
		
	}

	// Update is called once per frame
	void Update ()
	{
		print (Input.touchCount);

//		if (Input.GetMouseButtonDown (0) && Time.time > nextFire) {
//			screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
//			shoot (screenPosition.x, screenPosition.y);
//			nextFire = Time.time + fireRate;
//		}


//		if (Input.touchCount == 1) {
//			Vector2 screenPositiony = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y));
//			if (screenPositiony.x > redLine.transform.position.x) {
//				//do something
//				if (Time.time > nextFire) {
//					shoot (screenPositiony.x, screenPositiony.y);
//					nextFire = Time.time + fireRate;
//				}
//			}
//		}

		for (int i = 0; i < Input.touchCount; i++) {
			//if (Input.GetTouch (i).phase == TouchPhase.Began) {
			screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y));
			if (screenPosition.x > redLine.transform.position.x) {
				//do something
				if (Time.time > nextFire) {
					//screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y));
					shoot (screenPosition.x, screenPosition.y);
					nextFire = Time.time + fireRate;
				}
			} else {
				Vector3 tmp = gameObject.transform.position;
				tmp.y = screenPosition.y;
				if (-4.5 <= tmp.y && tmp.y <=2.5) {
					
					gameObject.transform.position = tmp;
				}
				//if (Input.GetTouch(i).position.y < halfScreen) {
				//		if (gameObject.transform.localPosition.y > -4.5) {
				//		gameObject.transform.Posi;
				//		}
				//} else if (Input.GetTouch(i).position.y > halfScreen) {
				//
				//		if (gameObject.transform.localPosition.y < 2.5) {
				//		gameObject.transform.Translate (Vector3.up * 5 *Time.deltaTime);
				//		}
				//	}

				//}
			}
			//}

		}

		//gameObject.transform.Translate(Vector3.up);

		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)


		//Vector2 touchPosition = Input.GetTo



		//Check if it is left or right?



		//Debug.Log("Character pretended move to: ");

		//}

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Black Bullet") {
			Destroy (other.gameObject);
			health -= 1;
			if (health < 1) {
				Destroy (this.gameObject);
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		//print ("lol");
	}

	private float RadianToDegree (double angle)
	{
		return (float)(angle * (180.0 / Mathf.PI));
	}

	private void shoot (float screenX, float screenY)
	{
		Vector2 screenPosition = new Vector2 (screenX, screenY);
		//screenPosition = Camera.main.ScreenToWorldPoint (screenPosition);
		GameObject newBullet = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		float distance = Mathf.Sqrt (
			                 ((screenPosition.x - bulletSpawn.position.x) * (screenPosition.x - bulletSpawn.position.x)) + ((screenPosition.y - bulletSpawn.position.y) * (screenPosition.y - bulletSpawn.position.y)));
		float time = distance / 10;
		float velocityX = (float)((screenPosition.x - bulletSpawn.position.x) / time);
		float velocityY = (float)((screenPosition.y - bulletSpawn.position.y) / time);
		//shotSentryBullet.setVelocityX(velocityX);
		newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocityX, velocityY);
		float rotationAngle = (float)(RadianToDegree (Mathf.Atan2 (screenPosition.y - bulletSpawn.position.y, screenPosition.x - bulletSpawn.position.x)));
		newBullet.transform.Rotate (0, 0, rotationAngle, Space.World);
		print (bulletSpawn.position.x);
	}
}