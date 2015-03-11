using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float totalHealth = 100f;
	public GameObject player;
	public GameObject healthbarObject;
	public GameObject enemyFist1, enemyFist2;
	//public GameObject canvas;

	private Image healthBar;

	void Start()
	{
		healthBar = healthbarObject.GetComponent<Image> ();


	}

	void applyDamage(float damage)
	{
		enemyFist1.GetComponent<CapsuleCollider>().enabled = false;
		enemyFist2.GetComponent<CapsuleCollider>().enabled = false;
		if (totalHealth <= 0f)
			playerDead ();
		else 
		{
			totalHealth = totalHealth - damage;

			healthBar.fillAmount = totalHealth / 400f;

			Debug.Log ("Current Health of " + player.name + ": " + totalHealth);
		}

	}

	void playerDead()
	{
		Debug.Log (player.name + " IS DEAD");
	}

	/*
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "Enemy")
		{
			Debug.Log("*****MAIN PLAYER GOT HIT*****");

		}
	}*/
}
