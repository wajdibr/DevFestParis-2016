using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ParticleTrigger : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f;
	private GameObject particles;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		particles = GameObject.FindGameObjectWithTag ("particles");
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.green : Color.red;

		if (!isLookedAt) { delay = Time.time + 2.0f; }
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time > delay)) {
			particles.gameObject.GetComponent<Renderer> ().enabled = true;
		} else {
			particles.gameObject.GetComponent<Renderer> ().enabled = false;
		}
	}
	
}