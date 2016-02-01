using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
	public float distance = 3;
	private CardboardHead head;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update () {
		transform.position = head.transform.position + (head.Gaze.direction * distance);
	}
}