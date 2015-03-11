using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class TouchController : TouchManager {

	//to know which current button is being pressed
	public enum buttonType{jumpButton, rangeButton, aButton, bButton, joysButton, blockButton};
	public buttonType myButton;

	//our character and its animator
	public GameObject player;
	public GameObject enemy;
	private float distance;
	private Animator anim;
	public float damping = 2.0f;

	//animation speed & max distance of joystick
	public float animSpeed = 2.0f, maxJoyDelta = .05f;
	public GameObject golemFist1, golemFist2;

	//original joystick position and joystick transformation variable
	private Vector3 oJoyPosition; 
	private Transform joyTrans = null;
	private Transform targetTrans;

	//private RigidbodyConstraints originalConstraints;
	//private float jumpTime, dummyTime;
	//private bool jumped = false;
	//public bool wasMoveA = false, wasMoveB = false;


	
	void Start()
	{
		//get our characters animator
		anim = player.GetComponent<Animator>();	

		//get our joystick transformation and current position
		joyTrans = this.transform;
		oJoyPosition = joyTrans.position;
		targetTrans = enemy.transform;
		distance = 0f;
		//originalConstraints = player.rigidbody.constraints;
		//Debug.Log("**********BEFORE: " + originalConstraints.ToString());

		if (anim.layerCount == 2)
			anim.SetLayerWeight (1, 1);

	}

	void FixedUpdate()
	{
		//call touch input
		TouchInput ();

		/*
		dummyTime = Time.time;

		
		if ((dummyTime - jumpTime) >= 1.0f && jumped == true) {
			//Vector3 velocity = player.rigidbody.position;
			//velocity.y = -9.81f;
			//player.rigidbody.velocity = velocity;
			jumped = false;
			player.rigidbody.isKinematic = true;
			player.rigidbody.constraints = originalConstraints;
			//jumpTime = Time.time;
			Debug.Log("******************UPDATE: ");
		}

		if ((dummyTime - jumpTime) >= 6.0f && jumped == false) {

			player.rigidbody.isKinematic = false;
			Debug.Log("******************UPDATE2: ");
		}*/

		/*
		while (player.rigidbody.position.y != 0) {
			player.rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

			if(player.rigidbody.position.y == 0){
				player.rigidbody.constraints = originalConstraints;

				break;
			}

		}*/


	}


	void OnFirstTouchBegan()
	{
		//watch our touch
		touch2Watch = TouchManager.currTouch;

		/*
		if (myButton == buttonType.jumpButton) 
		{
			player.rigidbody.isKinematic = false;
			player.rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
			anim.SetBool("Jump", true);
			jumped = true;

			jumpTime = Time.time;
			Debug.Log("*********************UPDATE0: ");

		}*/
		if (myButton == buttonType.rangeButton) 
		{
			distance = Vector3.Distance (targetTrans.position, player.transform.position);

			Debug.Log("Pressed Range Button");
			
			lookAt ();
		}
		if (myButton == buttonType.blockButton) 
		{
			anim.SetBool("BoxingBlock", true);
		}
		if (myButton == buttonType.aButton) 
		{
			//wasMoveA = true;

			//player.SendMessage("wasHit", wasMoveA);
			golemFist1.GetComponent<CapsuleCollider>().enabled = true;
			golemFist2.GetComponent<CapsuleCollider>().enabled = true;
			anim.SetBool("MoveA", true);

		}
		if (myButton == buttonType.bButton) 
		{
			golemFist1.GetComponent<CapsuleCollider>().enabled = true;
			golemFist2.GetComponent<CapsuleCollider>().enabled = true;
			anim.SetBool("MoveB", true);
		}

	}

	void OnFirstTouchStayed()
	{
		/*
		if (myButton == buttonType.jumpButton) 
		{
			anim.SetBool("Jump", false);
		}*/
		if (myButton == buttonType.rangeButton) 
		{
			distance = Vector3.Distance (targetTrans.position, player.transform.position);
			
			Debug.Log("Pressed Range Button");
			
			lookAt ();
		}
		if (myButton == buttonType.blockButton) 
		{
			anim.SetBool("BoxingBlock", false);
		}
		if (myButton == buttonType.aButton) 
		{
			anim.SetBool("MoveA", false);
		}
		if (myButton == buttonType.bButton) 
		{
			anim.SetBool("MoveB", false);
		}
		
	}

	void OnFirstTouchMoved()
	{
		//if this is the joystick and this is the current touch we are watching
		if (myButton == buttonType.joysButton && TouchManager.currTouch == touch2Watch) 
		{
			//move our character the appropriate distance
			joyTrans.position = MoveJoystick();
			ApplyDeltaJoy(joyTrans);
		}
		/*
		if (myButton == buttonType.jumpButton) 
		{
			anim.SetBool("Jump", false);
		}*/
		if (myButton == buttonType.blockButton) 
		{
			anim.SetBool("BoxingBlock", false);
		}
		if (myButton == buttonType.aButton) 
		{
			anim.SetBool("MoveA", false);
		}
		if (myButton == buttonType.bButton) 
		{
			anim.SetBool("MoveB", false);
		}
	}


	void OnFirstTouchEndedAnywhere()
	{

		//if this is the joystick and this is the current touch we are watching
		if (myButton == buttonType.joysButton && TouchManager.currTouch == touch2Watch) 
		{
			//revert the joystick back to old position
			joyTrans.position = oJoyPosition;
			touch2Watch = 64;
			//stop animating our character
			anim.SetFloat("Speed", 0.0f);
			anim.SetFloat("Direction", 0.0f);
		}
		/*
		if (myButton == buttonType.jumpButton) 
		{
			anim.SetBool("Jump", false);
		}*/

		if (myButton == buttonType.blockButton) 
		{
			anim.SetBool("BoxingBlock", false);
		}
		if (myButton == buttonType.aButton) 
		{
			anim.SetBool("MoveA", false);
		}
		if (myButton == buttonType.bButton) 
		{
			anim.SetBool("MoveB", false);
		}
	}

	void OnTouchEndedAnywhere()
	{

		//if this is the joystick and this is the current touch we are watching
		if (myButton == buttonType.joysButton) 
		{
			//revert the joystick back to old position
			joyTrans.position = oJoyPosition;
			touch2Watch = 64;
			//stop animating our character
			anim.SetFloat("Speed", 0.0f);
			anim.SetFloat("Direction", 0.0f);
		}
	}

	void ApplyDeltaJoy(Transform trans)
	{
		anim.SetFloat("Speed", trans.position.y);			

		if (trans.position.x >= .19f && trans.position.x <= .21f) 
		{
			anim.SetFloat ("Direction", -1.0f);
		} 
		else if (trans.position.x >= .27f && trans.position.x <= .29f) 
		{
			anim.SetFloat ("Direction", 1.0f);
		}
		else 
		{
			anim.SetFloat ("Direction", 0.0f);
		}
		anim.speed = animSpeed;

	}

	Vector3 MoveJoystick()
	{
		float x = Input.GetTouch (touch2Watch).position.x / Screen.width, y = Input.GetTouch (touch2Watch).position.y / Screen.height;

		Vector3 position = new Vector3 (Mathf.Clamp (x, oJoyPosition.x - maxJoyDelta, oJoyPosition.x + maxJoyDelta), Mathf.Clamp (y, oJoyPosition.y - maxJoyDelta, oJoyPosition.y + maxJoyDelta), 0);

		return position;

	}

	void lookAt()
	{
		Quaternion rotation = Quaternion.LookRotation (targetTrans.position - player.transform.position);
		player.transform.rotation = Quaternion.Slerp (player.transform.rotation, rotation, 3.0f*Time.deltaTime); //* damping);
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
