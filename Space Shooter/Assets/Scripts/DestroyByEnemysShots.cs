using UnityEngine;
using System.Collections;

public class DestroyByEnemysShots : MonoBehaviour {

	public GameObject playerExplosion;

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy Shots") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
		}

		Destroy (gameObject);
		Destroy (other.gameObject);
	}
}
