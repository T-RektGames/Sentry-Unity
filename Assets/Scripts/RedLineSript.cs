using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RedLineSript : MonoBehaviour {

	public GameManager gameManager;


	// Use this for initialization
	void Start () {
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
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			gameManager.setDied(true);

		}
		//print ("lol");
	}
}
