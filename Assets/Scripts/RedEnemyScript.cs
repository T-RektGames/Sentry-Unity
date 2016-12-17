using UnityEngine;
using System.Collections;

public class RedEnemyScript : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public int health;
	public GameObject deadEnemy;
	public float fireRate;
	private float nextFire;
	public GameObject blackBullet;
	// Use this for initialization
	void Start () {
		health = 1;
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
	}

	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			shoot ();
			nextFire = Time.time + fireRate;
		}	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Red Bullet") {

			Instantiate (deadEnemy, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

	}

	void shoot(){
		Instantiate (blackBullet, gameObject.transform.position, gameObject.transform.rotation);
	}


}
