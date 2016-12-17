using UnityEngine;
using System.Collections;

public class RedBulletScript : MonoBehaviour {
	public float speed;
	public GameManager gameManager;
	//public Canvas score;

	//public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
		GameObject gameManagerObject = GameObject.FindWithTag ("GameController");
		if (gameManagerObject != null)
		{
			gameManager = gameManagerObject.GetComponent <GameManager>();
		}
		if (gameManager == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			gameManager.addScore ();
		}
		//print ("lol");
	}


}
