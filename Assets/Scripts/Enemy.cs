using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Animator anim;
	public float health;
	public float speed;
	public int damage;
	public TowerController playerTower;

	private Rigidbody2D rb;

	void Start(){
		anim = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		playerTower = GetComponent<TowerController> ();
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (speed * -1, rb.velocity.y);
	}

	public void TakeDamage(int damageTaken){
		health -= damageTaken;
		anim.SetTrigger ("CameraShake");
		if (health <= 0) {
			GameManager.coins += Random.Range(5, 10);
			Destroy (gameObject);
		}
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerController> ().Attacked (damage);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "PlayerTower") {
			collision.GetComponent<TowerController> ().health -= 10;
			Destroy (gameObject);
		}
	}
}
