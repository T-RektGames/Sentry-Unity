using UnityEngine;
using System.Collections;

public class WhiteEnemyScript : MonoBehaviour {

	public float speed;
	public int health;
	private Animator anim;
	public GameObject deadEnemy;

	void Start () {
		health = 3;
		anim = gameObject.GetComponent<Animator>();
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.tag == "Red Bullet") {

			if (health == 3) {
				health = 2;
				anim.Play ("greyEnemyAnimation");
				Destroy (other.gameObject);


			} else if (health == 2) {
				health = 1;
				anim.Play ("redEnemyAnimation");
				Destroy (other.gameObject);

			} else if (health == 1) {
				health = 0;
				Instantiate (deadEnemy, gameObject.transform.position, gameObject.transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);


			}
		}

	}

}
