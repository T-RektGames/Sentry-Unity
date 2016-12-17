using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		updateScore();
	}

	public void addScore(){
		score += 1;
	}

	public int getScore (){
		return this.score;
	}

	private void updateScore (){
		scoreText.text = score.ToString();
	}
}
