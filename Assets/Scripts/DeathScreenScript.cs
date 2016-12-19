using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour {

	public Text scoreText, highScoreText, highScoreNumber, yourScore;
	private int currentScore, highScore;
	public GameObject topCloud, bottomCloud;
	private Vector2 newScorePosition, newTopCloudPosition, newBottomCloudPosition, newHighScorePosition, 
					newHighScoreTextPosition, newYourScorePosition;
	public float speed;
	private Color tmp;
	private bool canProceed;

	// Use this for initialization
	void Start () {
		currentScore = PlayerPrefs.GetInt ("Current Score");
		highScore = PlayerPrefs.GetInt ("High Score");
		scoreText.text = currentScore.ToString ();
		highScoreNumber.text = highScore.ToString ();
		newScorePosition = scoreText.transform.position;
		newTopCloudPosition = topCloud.transform.position;
		newBottomCloudPosition = bottomCloud.transform.position;
		newHighScorePosition = highScoreNumber.transform.position;
		newHighScoreTextPosition = highScoreText.transform.position;
		newYourScorePosition = yourScore.transform.position;
		canProceed = false;

	}
	
	// Update is called once per frame
	void Update () {
		moveDown ();
		moveUp ();
		moveLeft ();
		makeOpaque ();
		for (int i = 0; i < Input.touchCount; i++) {
			
			if (Input.GetTouch (i).phase == TouchPhase.Began && canProceed == true) {
				SceneManager.LoadScene (1);
			}

		}

	}

	private void moveDown(){
		if (topCloud.transform.position.y > 3.76) {
			newScorePosition.y -= speed * Time.deltaTime;

			newTopCloudPosition.y -= speed * Time.deltaTime;


		} else {
			newTopCloudPosition.y = 3.73f;
			//canProceed = true;
		}
		scoreText.transform.position = newScorePosition;
		topCloud.transform.position = newTopCloudPosition;
	}

	private void moveUp(){
		if (bottomCloud.transform.position.y < -3.76) {
			newBottomCloudPosition.y += speed * Time.deltaTime;

		} else {
			newBottomCloudPosition.y = -3.73f;
		}

		bottomCloud.transform.position = newBottomCloudPosition;
	}

	private void moveLeft(){
		if (highScoreNumber.transform.position.x > 1) {
			newHighScorePosition.x -= speed * Time.deltaTime * 3;
			newHighScoreTextPosition.x -= speed * Time.deltaTime * 3;
		} else {
			newHighScorePosition.x = 0;
			newHighScoreTextPosition.x = 0;
			canProceed = true;
		}

		highScoreText.transform.position = newHighScoreTextPosition;
		highScoreNumber.transform.position = newHighScorePosition;
	}

	private void makeOpaque(){
		tmp = yourScore.color;
		if (tmp.a < 255) {
			tmp.a += speed / 7 * Time.deltaTime;
			yourScore.color = tmp;
		}
	}
}
