using UnityEngine;
using System.Collections;

public class RedLineSript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			Application.LoadLevel (Application.loadedLevel);
		}
		//print ("lol");
	}
}
