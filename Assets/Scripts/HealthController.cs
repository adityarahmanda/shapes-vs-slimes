using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	private Image healthImage;
	public TowerController tower;

	void Start() {
		healthImage = GetComponent<Image> ();
	}

	void Update() {
		if(((float)tower.health / 100.0f) < healthImage.fillAmount) {
			healthImage.fillAmount -= 0.01f;
		}
	}
}
