using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class makeTransparent : MonoBehaviour {
	//public float speed;
	public float speedOfFade;
	//private Vector2 velocity;
	//public Transform bulletSpawn;
	// Use this for initialization
	public GameManager gameManager;
	private SpriteRenderer renderer;
	private Color tmp;

	// Use this for initialization
	void Start () {
		speedOfFade = 0.5f;
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
	void Update () {
		if (gameManager.getDied() == true) {
			tmp = renderer.color;
			if (tmp.a > 0) {

				tmp.a -= speedOfFade * Time.deltaTime;
				renderer.color = tmp;
				if (gameObject.GetComponent<SentryMove> () != null) {
					Destroy (gameObject.GetComponent<SentryMove> ());
				}
				if (gameObject.GetComponent <RedEnemyScript> () != null) {
					Destroy (gameObject.GetComponent<RedEnemyScript> ());
				}
				if (gameObject.GetComponent<WhiteEnemyScript> () != null) {
					Destroy (gameObject.GetComponent<WhiteEnemyScript> ());
				}
				if (gameObject.GetComponent<GreyEnemyScript> () != null) {
					Destroy (gameObject.GetComponent<GreyEnemyScript> ());
				}
				if (gameObject.GetComponent<RedBulletScript> () != null) {
					Destroy (gameObject.GetComponent<RedBulletScript> ());
				}
			} else {
				Destroy (gameObject);
				SceneManager.LoadScene (3);

			}
		}

	}
}
