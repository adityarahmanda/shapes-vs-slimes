using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	public int health;
	public int damage;
	public float moveSpeed;

	public bool isKnockback;
	public float knockback;
	public float knockbackLenght;
	private float knockbackCount;

	private bool isAttack;
	public Transform attackPos;
	private float timeBtwAttack;
	public float startTimeBtwAttack;
	public float attackRange;
	public LayerMask whatIsEnemies;

	private Animator anim;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		if (knockbackCount <= 0) {
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (-knockback, knockback);
			knockbackCount -= Time.deltaTime;
		}
	}

	void Update() {
		if (health <= 0) {
			Destroy (gameObject);
		}
			
		if (timeBtwAttack <= 0) {
			anim.SetTrigger ("Attack");
			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRange, whatIsEnemies);
			for (int i = 0; i < enemiesToDamage.Length; i++) {
				enemiesToDamage [i].GetComponent<Enemy> ().TakeDamage (damage);
			}
			timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= Time.deltaTime;
		}
	}
		
	public void Attacked(int enemyDamage) {
		health -= enemyDamage;
		if (isKnockback) {
			knockbackCount = knockbackLenght;
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "EnemyTower") {
			collision.GetComponent<TowerController>().health -= 10;
			Destroy (gameObject);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}

	public int getHealth() {
		return health;
	}

	public int getDamage() {
		return damage;
	}

	public void attackAnimation() {
		anim.SetTrigger ("Attack");
	}

	public bool IsAttack {
		get { return isAttack; }
		set { isAttack = value; }
	}
}