using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blah : MonoBehaviour {

	public Image health;
	public int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >=200)
			health.fillAmount = .4f;
	}
}
