using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Random r;
	private int i, bottomRange, topRange;
	private int newYPos;
	private Vector3 newPosition;
	public float enemySpawnRate;
	private int whiteSpeed, redSpeed, greySpeed, counter;

	private float nextFire;
	public GameObject redEnemy;
	public GameObject greyEnemy;
	public GameObject whiteEnemy;
	public GameManager gameManager;

	public EnemyManager(){

		newPosition = new Vector3(10, -3, 0);
		enemySpawnRate = 2;
		bottomRange = 1;
		topRange = 4;
		counter = 0;
		topRange = 2;
	}

	// Use this for initialization
	void Start () {
		//r = new Random ();
		gameManager = gameObject.GetComponent<GameManager> ();
		whiteSpeed = -1;
		redSpeed = -1;
		greySpeed = -1;

	}
	
	// Update is called once per frame
	void Update () {
		counter += 1;

		if (counter == 1000) {
			redSpeed = -2;
			topRange = 3;

		}

		if (counter == 2000) {
			redSpeed = -2;
			enemySpawnRate = 1.75f;
		}

		if (counter == 3000) {
			topRange = 4;
			redSpeed = -2;
			whiteSpeed = -1;
			greySpeed = -2;
		}

		if (counter == 4000) {
			redSpeed = -3;
			whiteSpeed = -2;
			greySpeed = -2;
		}

		if (counter == 5000) {
			redSpeed = -3;
			whiteSpeed = -2;
			greySpeed = -3;
		}

		if (counter == 6000) {
			enemySpawnRate = 1.5f;

		}

		if (counter == 7000) {
			whiteSpeed = -3;

		}

		if (counter == 8000) {
			redSpeed = -4;
			enemySpawnRate = 1.25f;
		}

		if (counter == 9000) {
			redSpeed = -4;
			greySpeed = -4;
			//enemySpawnRate = 1.25f;
		}

		if (counter == 10000) {
			redSpeed = -4;
			greySpeed = -4;
			whiteSpeed = -4;
			enemySpawnRate = 1f;
			//topRange = 4;
		}




		
		if (Time.time > nextFire && gameManager.getDied() == false){
			nextFire = Time.time + enemySpawnRate;
			i = Random.Range (bottomRange, topRange); 
			newYPos = Random.Range (-45, 30)/ 10;
			newPosition.y = newYPos;

			if (i == 3) {
				
				GameObject newWhiteEnemy	= Instantiate (whiteEnemy, newPosition, whiteEnemy.transform.rotation) as GameObject;
				newWhiteEnemy.GetComponent<WhiteEnemyScript> ().speed = this.whiteSpeed;

			} else if (i == 2) {

				GameObject newGreyEnemy	= Instantiate (greyEnemy, newPosition, greyEnemy.transform.rotation) as GameObject;
				newGreyEnemy.GetComponent<GreyEnemyScript> ().speed = this.greySpeed; 

			} else {

				GameObject newRedEnemy	= Instantiate (redEnemy, newPosition, redEnemy.transform.rotation) as GameObject;
				newRedEnemy.GetComponent<RedEnemyScript> ().speed = this.redSpeed;

			}

		}
	
	}
}
