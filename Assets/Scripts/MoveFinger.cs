using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveFinger : MonoBehaviour {

	public float speed;
	private int counter;
	private bool canProceed;
	public Text proceed;
	private Vector2 screenPosition;

	// Use this for initialization
	void Start () {
		speed = 2;
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		counter =0;
	}
	
	// Update is called once per frame
	void Update () {
		counter += 1;
		if (transform.position.y < -4 && gameObject.GetComponent<Rigidbody2D> ().velocity.y < 0 || gameObject.GetComponent<Rigidbody2D> ().velocity.y > 0 && transform.position.y > 2.5) {
			gameObject.GetComponent<Rigidbody2D> ().velocity *= -1;
		}

		if (counter == 300) {
			canProceed = true;
			proceed.enabled = true;
		}

		if (Input.GetMouseButtonDown (0) && canProceed == true) {
			screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y));
			PlayerPrefs.SetInt ("Seen Tutorial", 1);
			PlayerPrefs.Save ();
			SceneManager.LoadScene (2);

		}
			

		
	}




}
