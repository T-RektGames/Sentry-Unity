using UnityEngine;
using System.Collections;

public class BlackBulletScript : MonoBehaviour {

	// Use this for initialization
	public float speed;
	//private Vector2 velocity;
	//public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 



	}

	// Update is called once per frame
	void Update () {


	}
}
