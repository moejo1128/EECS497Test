using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Animator anim;
	//private CapsuleCollider col;
	public float animSpeed = 2.0f;

	void Start()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  
		//col = GetComponent<CapsuleCollider>();
		if (anim.layerCount == 2)
			anim.SetLayerWeight (1, 1);
	}
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");				
		float v = Input.GetAxis("Vertical");

		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h);
		anim.speed = animSpeed;	
		/*
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement*5);*/
	}

}
