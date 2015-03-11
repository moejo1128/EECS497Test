using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {



	private Transform targetTrans;
	private Animator anim;
	//private Vector3 moveDirection = Vector3.zero;
	private float attackTime, currTime;

	public GameObject enemy;
	public float distance;
	public float lookAtDistance = 50.0f;
	public float attackDistance = 5.8f;
	public float chaseDistance = 30.0f;
	public float moveSpeed = 5.0f;
	public float damping = 2.0f;
	public int moveAAttackDamage = 10, moveBAttackDamage = 15;
	public GameObject demonFist1, demonFist2;
	//public bool wasMoveA = false, wasMoveB = false;

	void Start()
	{
		//get our characters animator
		anim = 	this.GetComponent<Animator>();	
		targetTrans = enemy.transform;

	}


		
	// Update is called once per frame
	void FixedUpdate ()
	{
		distance = Vector3.Distance (targetTrans.position, transform.position);

		lookAt ();

		//attack logic
		if (distance < attackDistance) 
			attack();

		//chase logic
		else if (distance < chaseDistance) 
			chase();


		currTime = Time.time;
		if ((currTime - attackTime) >= .76) {
			anim.SetBool ("MoveA", false);
			//wasMoveA = false;
		}

	}

	void lookAt()
	{
		Quaternion rotation = Quaternion.LookRotation (targetTrans.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void chase()
	{
		anim.SetFloat ("Speed", .45f);
	}

	void attack()
	{
		demonFist1.GetComponent<CapsuleCollider>().enabled = true;
		demonFist2.GetComponent<CapsuleCollider>().enabled = true;
		anim.SetBool("MoveA", true);
		//wasMoveA = true;
		//wasMoveB = false;
		attackTime = Time.time;
	}

}
