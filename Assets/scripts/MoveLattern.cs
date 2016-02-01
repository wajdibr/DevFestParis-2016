using UnityEngine;
using System.Collections;

public class MoveLattern : MonoBehaviour {


	void Update() {
	
		if (Vector3.Distance(transform.position,Camera.main.transform.position)>12) {
			transform.Translate (0, 0, -Time.deltaTime, Camera.main.transform);
		}
	}
}
