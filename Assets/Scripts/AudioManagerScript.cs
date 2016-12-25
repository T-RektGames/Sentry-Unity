using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour {

	//public AudioClip mainTheme, gameTheme;
	private AudioSource[] audioSources;
	private AudioSource mainTheme, gameTheme;
	private int sceneIndex;
	private bool oneTime, oneTime2, oneTime3;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		audioSources = gameObject.GetComponents<AudioSource> ();
		//audioSource.clip = mainTheme;
		mainTheme = audioSources[0];
		gameTheme = audioSources [1];
		oneTime = false;
		oneTime2 = false;
		oneTime3 = false;
	}
	
	// Update is called once per frame
	void Update () {
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if (sceneIndex == 1 && oneTime == false) {

			if (mainTheme.isPlaying == false) {
				mainTheme.Play ();
			}

			oneTime = true;
			oneTime2 = false;
			oneTime3 = false;
		}

		if (sceneIndex == 2 && oneTime2 == false) {
			mainTheme.Pause ();
			gameTheme.Play ();
			oneTime2 = true;
			oneTime = false;
			oneTime3 = false;

		}

		if (sceneIndex == 3 && oneTime3 == false ) {
			mainTheme.Play ();
			gameTheme.Stop ();
			oneTime3 = true;
			oneTime = false;
			oneTime2 = false;
		}

	}
}
