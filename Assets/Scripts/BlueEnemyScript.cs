using UnityEngine;
using System.Collections;

public class BlueEnemyScript : MonoBehaviour {

	// Use this for initialization
	public float speed;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Red Bullet") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
