using UnityEngine;
using System.Collections;

public class FieldHazardsCollisionScript : MonoBehaviour {
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "small flames") {
			//deal hp damage
		}

		if (col.gameObject.name == "Flame") {
			//deal hp damage
		}

		if (col.gameObject.name == "Fire1") {
			//deal hp damage
		}

		if (col.gameObject.name == "large flames") {
			//deal hp damage
		}

		if (col.gameObject.name == "explosion") {
			//deal hp damage
		}

	}
	
}
