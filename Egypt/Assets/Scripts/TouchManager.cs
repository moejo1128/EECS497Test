using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public static bool guiTouch = false;
	public static int currTouch = 0;

	[HideInInspector]
	public int touch2Watch = 64;

	public void TouchInput ()
	{
		/*
		if (guiTexture != null) {*/
		for(int i = 0; i < Input.touchCount; i++){

			currTouch = i;

			if(guiTexture.HitTest(Input.GetTouch(i).position) && guiTexture != null)
			{
				guiTouch = true;
				switch (Input.GetTouch(i).phase)
				{
				case TouchPhase.Began:
					SendMessage("OnFirstTouchBegan");
					SendMessage("OnFirstTouch");
					break;
				case TouchPhase.Moved:
					SendMessage("OnFirstTouchMoved");
					SendMessage("OnFirstTouch");
					break;
				case TouchPhase.Stationary:
					SendMessage("OnFirstTouchStayed");
					SendMessage("OnFirstTouch");
					break;
				case TouchPhase.Ended:
					SendMessage("OnFirstTouchEndedAnywhere");
					guiTouch = false;
					break;


				}

			}

			switch(Input.GetTouch(i).phase)
			{
			case TouchPhase.Began:
				//OnTouchBeganAnywhere();
				this.SendMessage("OnTouchBeganAnyWhere");
				/*
				if(Physics.Raycast(ray, out rayHitInfo))
					rayHitInfo.transform.gameObject.SendMessage("OnTouchBegan3D");*/
				break;
			case TouchPhase.Ended:
				//OnTouchEndedAnywhere();
				this.SendMessage("OnTouchEndedAnywhere");
				/*
				if(Physics.Raycast(ray, out rayHitInfo))
					rayHitInfo.transform.gameObject.SendMessage("OnTouchEnded3D");*/
				break;
			case TouchPhase.Moved:
				//OnTouchMovedAnywhere();
				this.SendMessage("OnTouchMovedAnywhere");
				/*
				if(Physics.Raycast(ray, out rayHitInfo))
					rayHitInfo.transform.gameObject.SendMessage("OnTouchMoved3D");*/
				break;
			case TouchPhase.Stationary:
				//OnTouchStayedAnywhere();
				this.SendMessage("OnTouchStayedAnywhere");
				/*
				if(Physics.Raycast(ray, out rayHitInfo))
					rayHitInfo.transform.gameObject.SendMessage("OnTouchStayed3D");*/
				break;
			}
		
		}

	}

}
