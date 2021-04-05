using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int score;
	public Text scoreText;
	private bool died, runOnce;


	// Use this for initialization
	void Start () {
		died = false;
		runOnce = false;
		//DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		updateScore();
		if (died == true && runOnce == false) {
			PlayerPrefs.SetInt ("Current Score", score);
			if (score > PlayerPrefs.GetInt ("High Score", 0)) {
				PlayerPrefs.SetInt ("High Score", score);
			}

			PlayerPrefs.Save ();
			runOnce = true;
		}
	}

	public void addScore(){
		score += 1;
	}

	public int getScore (){
		return this.score;
	}

	private void updateScore (){
		//if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(2)){
			scoreText.text = score.ToString();
			
		//}
	}

	public void setDied ( bool died){
		this.died = died;
	}

	public bool getDied(){
		return this.died;
	}
}
