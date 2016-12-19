using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SentryMove : MonoBehaviour
{


	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;
	public float health;
	private float nextFire;
	double halfScreen = Screen.height / 2.0;
	Vector2 screenPosition;
	public GameObject redLine;
	private float originalHealth;
	private SpriteRenderer renderer;
	private Color tempColour;
	public GameManager gameManager;


	// Use this for initialization
	void Start ()
	{
		originalHealth = health;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
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
	void Update ()
	{
		
		for (int i = 0; i < Input.touchCount; i++) {
			//if (Input.GetTouch (i).phase == TouchPhase.Began) {
			screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y));
			if (screenPosition.x > redLine.transform.position.x) {
				//do something
				if (Time.time > nextFire) {
					//screenPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y));
					shoot (screenPosition.x, screenPosition.y);
					nextFire = Time.time + fireRate;
				}
			} else {
				Vector3 tmp = gameObject.transform.position;
				tmp.y = screenPosition.y;
				if (-4.5 <= tmp.y && tmp.y <=2.5) {
					
					gameObject.transform.position = tmp;
				}
			
			}


		}

	

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Black Bullet") {
			Destroy (other.gameObject);
			health -= 1;
			tempColour = renderer.color;
			//if (tmp.a > 0) {

			tempColour.a = (health/originalHealth);
			renderer.color = tempColour;
			if (health < 1) {
				Destroy (this.gameObject);
				gameManager.setDied (true);

			}
		}
		//print ("lol");
	}

	private float RadianToDegree (double angle)
	{
		return (float)(angle * (180.0 / Mathf.PI));
	}

	private void shoot (float screenX, float screenY)
	{
		Vector2 screenPosition = new Vector2 (screenX, screenY);
		//screenPosition = Camera.main.ScreenToWorldPoint (screenPosition);
		GameObject newBullet = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		float distance = Mathf.Sqrt (
			                 ((screenPosition.x - bulletSpawn.position.x) * (screenPosition.x - bulletSpawn.position.x)) + ((screenPosition.y - bulletSpawn.position.y) * (screenPosition.y - bulletSpawn.position.y)));
		float time = distance / 10;
		float velocityX = (float)((screenPosition.x - bulletSpawn.position.x) / time);
		float velocityY = (float)((screenPosition.y - bulletSpawn.position.y) / time);
		//shotSentryBullet.setVelocityX(velocityX);
		newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocityX, velocityY);
		float rotationAngle = (float)(RadianToDegree (Mathf.Atan2 (screenPosition.y - bulletSpawn.position.y, screenPosition.x - bulletSpawn.position.x)));
		newBullet.transform.Rotate (0, 0, rotationAngle, Space.World);
		print (bulletSpawn.position.x);
	}
}