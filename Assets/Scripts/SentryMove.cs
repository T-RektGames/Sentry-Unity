using UnityEngine;
using System.Collections;

public class SentryMove : MonoBehaviour {


	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;

	private float nextFire;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
			//{
		}
		
		//gameObject.transform.Translate(Vector3.up);

		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)


		Vector2 touchPosition = Input.mousePosition;

		double halfScreen = Screen.height / 2.0;

			//Check if it is left or right?
		if (touchPosition.y < halfScreen) {
			if (gameObject.transform.localPosition.y > -4.5) {
				gameObject.transform.Translate (Vector3.down * 5 * Time.deltaTime);
			}
		} else if (touchPosition.y > halfScreen) {
			
			if (gameObject.transform.localPosition.y < 2.5) {
				gameObject.transform.Translate (Vector3.up * 5 * Time.deltaTime);
			}
		}


		//Debug.Log("Character pretended move to: ");

		//}

	}
}