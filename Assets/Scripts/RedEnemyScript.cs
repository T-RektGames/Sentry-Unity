using UnityEngine;
using System.Collections;

public class RedEnemyScript : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public int health;
	public GameObject deadEnemy;
	// Use this for initialization
	void Start () {
		health = 1;
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Red Bullet") {

			Instantiate (deadEnemy, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

	}

}
