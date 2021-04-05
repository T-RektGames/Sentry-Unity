using UnityEngine;
using System.Collections;

public class GreyEnemyScript : MonoBehaviour {

	public float speed;
	public int health;
	private Animator anim;
	public GameObject deadEnemy;
	public float fireRate;
	private float nextFire;
	public GameObject blackBullet;
	// Use this for initialization
	void Start () {
		health = 2;
		anim = gameObject.GetComponent<Animator> ();
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

			if (health == 2) {
				anim.Play ("redEnemyAnimation");
				health = 1;
				Destroy (other.gameObject);
				
			} else if (health == 1) {

				Instantiate (deadEnemy, gameObject.transform.position, gameObject.transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		}

	}

	void shoot(){
		Instantiate (blackBullet, gameObject.transform.position, gameObject.transform.rotation);
	}

}
