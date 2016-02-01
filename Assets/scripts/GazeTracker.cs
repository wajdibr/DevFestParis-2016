using UnityEngine;
using System.Collections;

public class GazeTracker : MonoBehaviour {
	private CardboardHead head;
	
	private Vector3 offset;

	void Start()  {
		head =Camera.main.GetComponent<StereoController>().Head;
	}
	
	void LateUpdate() {
		
		// head.transform.position = the positon of the head on the plane
		// head.Gaze.direction = positon of where the head is looking
		offset = head.Gaze.direction + head.transform.position;

	}
}
