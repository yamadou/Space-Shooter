using UnityEngine;
using System.Collections;

public class DestroyByShots : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject EnemyExplosion;
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
		
			Instantiate (playerExplosion, transform.position, transform.rotation);
			Instantiate (EnemyExplosion, transform.position, transform.rotation);
			gameController.GameOver ();

		} else if (other.tag == "Shots") {
			Instantiate (EnemyExplosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
		}

		if (other.tag != "Asteroid" && other.tag != "Enemy Shots") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
