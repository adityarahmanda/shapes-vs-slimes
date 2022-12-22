using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject slime;
	public GameManager gameManager;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;

	// Update is called once per frame
	void Update () {
		if (gameManager.IsGameEnd () != true) {
			if (timeBtwSpawn <= 0) {
				Instantiate (slime, transform.position, transform.rotation);
				timeBtwSpawn = startTimeBtwSpawn - (Random.Range (0.0f, startTimeBtwSpawn));
			} else {
				timeBtwSpawn -= Time.deltaTime;
			}
		}
	}
}
