using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		//GetComponent<Renderer>().material.color = isLookedAt ? Color.green : Color.red;
		if (!isLookedAt) { delay = Time.time + 2.0f; }
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			// Teleport randomly
			Vector3 direction = Random.onUnitSphere;
			Debug.Log ("Direction.y = "+direction.y);
			direction.y = Mathf.Clamp(direction.y, 5f, 1f);
			float distance = 2 * Random.value + 5f;
			transform.localPosition = direction * distance;
		}
	}
	
}