using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class cursor : MonoBehaviour {
	public Camera CameraFacing;
	public Vector3 originalScale;
	GameObject lastWt = null;

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
		float distance;
		if (currentObject == null) { 
			RaycastHit hit;
			if (Physics.Raycast (new Ray(CameraFacing.transform.position, CameraFacing.transform.forward * 3), out hit)) {
				lastWt = hit.transform.gameObject;
				lastWt.GetComponent<WebTexture>().HasFocus = true;
				distance = hit.distance;
			} else {
				if (lastWt != null) {
					lastWt.GetComponent<WebTexture>().HasFocus = false;
				}
				distance = CameraFacing.farClipPlane * 0.95f;
			}
		} else {
			distance = Vector3.Distance(currentObject.transform.position, CameraFacing.transform.position);
		}

			transform.LookAt (CameraFacing.transform.position);
			transform.Rotate (0.0f, 180.0f, 0.0f);
			transform.position = CameraFacing.transform.position + CameraFacing.transform.forward * distance * .95f;
		if (distance < 10.0f) {
			distance *= 1 + 5 * Mathf.Exp (-distance);
		}
		transform.localScale = originalScale * distance;
		


	}
}
