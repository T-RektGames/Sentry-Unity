using UnityEngine;
using System.Collections;

public class DeadEnemyScript : MonoBehaviour {


	public float speedOfFade;
	private SpriteRenderer renderer;
	private Color tmp;
	//public float lol;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		tmp = renderer.color;
		if (tmp.a > 0) {

			tmp.a -= speedOfFade * Time.deltaTime;
			renderer.color = tmp;
		} else {
			Destroy (gameObject);
		}
	}
}
