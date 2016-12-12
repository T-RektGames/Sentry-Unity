using UnityEngine;
using System.Collections;

public class GreyEnemyScript : MonoBehaviour {

	public float speed;
	public int health;
	private Animator anim;
	public GameObject deadEnemy;

	// Use this for initialization
	void Start () {
		health = 2;
		anim = gameObject.GetComponent<Animator> ();
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
	}
	
	// Update is called once per frame
	void Update () {
	
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

}
