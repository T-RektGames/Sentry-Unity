using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Random r;
	int i;
	int newYPos;
	Vector3 newPosition;
	public float enemySpawnRate;

	private float nextFire;
	public GameObject redEnemy;
	public GameObject greyEnemy;
	public GameObject whiteEnemy;

	public EnemyManager(){

		newPosition = new Vector3(10, -3, 0);
		enemySpawnRate = 2;
	}

	// Use this for initialization
	void Start () {
		//r = new Random ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > nextFire){
			nextFire = Time.time + enemySpawnRate;
			i = Random.Range (1, 4); 
			newYPos = Random.Range (-4, 3);
			newPosition.y = newYPos;

			if (i == 3) {
				
				Instantiate (whiteEnemy, newPosition, whiteEnemy.transform.rotation); 

			} else if (i == 2) {

				Instantiate (greyEnemy, newPosition, greyEnemy.transform.rotation); 

			} else {

				Instantiate (redEnemy, newPosition, redEnemy.transform.rotation); 

			}

		}
	
	}
}
