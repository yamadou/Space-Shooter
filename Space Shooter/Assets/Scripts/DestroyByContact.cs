using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {


	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;


	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "Player") {
			gameController.GameOver ();
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

		} else if (other.tag == "Shots") {
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
		}

		if (other.tag != "Enemy Shots" && other.tag != "Enemy") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

	}
}

//gameObject == The Game Object the script is
// attached to

