using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class cursor : MonoBehaviour {
	public Camera CameraFacing;
	public Vector3 originalScale;

	private PointerEventData lookData;
	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject eventSystem = GameObject.Find("EventSystem");
		BasicLookInputModule blim = eventSystem.GetComponent<BasicLookInputModule>();

		GameObject currentObject = blim.currentRaycastObject;
		Debug.Log (currentObject);
		float distance;
		if (currentObject == null) { 
			RaycastHit hit;
			if (Physics.Raycast (new Ray(CameraFacing.transform.position, CameraFacing.transform.forward * 3), out hit)) {
				Debug.Log("Hit distance: " + hit.distance);
				distance = hit.distance;
			} else {
				Debug.Log("no hit");
				distance = CameraFacing.farClipPlane * 0.95f;
				Debug.Log("distance: " + distance);
			}
		} else {
			distance = Vector3.Distance(currentObject.transform.position, CameraFacing.transform.position);
		}

			transform.LookAt (CameraFacing.transform.position);
			transform.Rotate (0.0f, 180.0f, 0.0f);
			transform.position = CameraFacing.transform.position + CameraFacing.transform.forward * distance;
		if (distance < 10.0f) {
			distance *= 1 + 5 * Mathf.Exp (-distance);
		}
		transform.localScale = originalScale * distance;
		


	}
}
