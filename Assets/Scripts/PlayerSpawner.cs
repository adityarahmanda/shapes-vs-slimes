using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject triangle;
	public GameObject rectangle;
	public GameManager gameManager;

	public float startTimeBtwSpawn;
	private float timeBtwSpawn;
	private bool isAllowedToBuy;

	void Update() {
		if (timeBtwSpawn <= 0) {
			isAllowedToBuy = true;
		} else {
			timeBtwSpawn -= Time.deltaTime;
		}
	}

	public void SpawnTriangle(){
		if (GameManager.coins >= 15 && isAllowedToBuy) {
			GameManager.coins -= 15;
			Instantiate (triangle, transform.position, transform.rotation);

			isAllowedToBuy = false;
			timeBtwSpawn = startTimeBtwSpawn;
		}
	}

	public void SpawnRectangle(){
		if (GameManager.coins >= 40 && isAllowedToBuy) {
			GameManager.coins -= 40;
			Instantiate (rectangle, transform.position, transform.rotation);

			isAllowedToBuy = false;
			timeBtwSpawn = startTimeBtwSpawn;
		}
	}
}
