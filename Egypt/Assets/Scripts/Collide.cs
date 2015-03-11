using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour 
{
	//public GameObject player;
	public float moveAAttackDamage = 10f;//, moveBAttackDamage = 15;
	//public GameObject golemFist1, golemFist2;
	//public bool wasMoveA = false;
	/*
	void wasHit(bool hit){
		if (hit)
			wasMoveA = true;
		else
			wasMoveA = false;
	}*/

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("COLLIDER TAG: " + col.collider.gameObject.tag);
		if (col.collider.gameObject.tag == "Enemy")
		{
			col.collider.gameObject.transform.SendMessage("applyDamage", moveAAttackDamage);
			//golemFist1.GetComponent<CapsuleCollider>().enabled = false;
			//golemFist2.GetComponent<CapsuleCollider>().enabled = false;
			Debug.Log("I hit the enemy");

			
		}
	}
}
