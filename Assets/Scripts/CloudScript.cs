using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {
	
	public float speed;
	private Vector2 resetPosition;

	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed; 
		resetPosition = new Vector2 (10, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < -10.3) {
			transform.position = resetPosition;
		}
	
	}
}
