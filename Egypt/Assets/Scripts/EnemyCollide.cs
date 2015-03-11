using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour 
{
	public float moveAAttackDamage = 10f;//, moveBAttackDamage = 15;
	//public GameObject enemyFist1, enemyFist2;
	
	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("COLLIDER TAG: " + col.collider.gameObject.tag);
		if (col.collider.gameObject.tag == "Player")
		{
			col.collider.gameObject.transform.SendMessage("applyDamage", moveAAttackDamage);
			//enemyFist1.GetComponent<CapsuleCollider>().enabled = false;
			//enemyFist2.GetComponent<CapsuleCollider>().enabled = false;
			Debug.Log("I hit the player");
	
			
		}
	}
}
