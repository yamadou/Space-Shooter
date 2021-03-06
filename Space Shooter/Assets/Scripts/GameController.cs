﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool restart;
	private bool gameOver;

	void Start ()
	{
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
		}
	}

	//IEnumerator = coroutine
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (spawnWait);

		while(true){
 
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
					spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				if(i % 2 == 0)
					Instantiate (hazard, spawnPosition, spawnRotation);
				else
					Instantiate (enemy, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds (waveWait);
			}

			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				restartText.text = "Press 'R' for Restart";
				restart = true; // it's okay to restart the game at this point
				break;
			}
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score : " + score;
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
