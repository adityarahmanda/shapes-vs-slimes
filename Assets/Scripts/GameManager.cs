using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int coins = 100;

	public TowerController shapesTower;
	public TowerController slimesTower;
	private bool isGameEnd;

	public Text coinsText;

	// Update is called once per frame
	void Update () {
		if (!isGameEnd) {
			coinsText.text = "coins : " + coins;

			if (shapesTower.health <= 0 || slimesTower.health <= 0) {
				if (shapesTower.health <= 0) {
					coinsText.text = "Slimes Wins!";
					isGameEnd = true;
				} else {
					coinsText.text = "Shapes Wins!";
					isGameEnd = true;
				}
			}
		}
	}

	public bool IsGameEnd(){
		return isGameEnd;
	}
}
