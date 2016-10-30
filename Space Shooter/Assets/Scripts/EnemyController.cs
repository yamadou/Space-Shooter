using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public float fireRate;
	public Transform EnemyShotSpawn;

	private float nextFire;

	void Start()
	{
		transform.Rotate (0,180, 0);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Time.time >= nextFire) {
			nextFire = Time.time + fireRate;
			Shoot ();
			GetComponent<AudioSource>().Play ();
		}
	}

	void Shoot()
	{
		Instantiate (shot, EnemyShotSpawn.position, EnemyShotSpawn.rotation);
	}
}
