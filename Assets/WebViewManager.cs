using UnityEngine;
using System.Collections;

public class WebViewManager : MonoBehaviour {
	public GameObject CameraFacing;
	GameObject currentObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt) && Input.GetKey(KeyCode.B)) {
			// drag windows around
			// find distance btwn look and window
			RaycastHit hit;
			if (Physics.Raycast (new Ray(CameraFacing.transform.position, CameraFacing.transform.forward * 3), out hit)) {
				currentObject = hit.transform.gameObject;
			}

			Transform rootTransform = currentObject.transform.root;
			float distance = Vector3.Distance(rootTransform.position, CameraFacing.transform.position);
			if (Input.GetKey(KeyCode.J) && distance > 1.5) {
				distance -= 0.5f;
			}
			if (Input.GetKey(KeyCode.K)) {
				distance += 0.5f;
			}

			rootTransform.LookAt(CameraFacing.transform.position);
			rootTransform.position = (CameraFacing.transform.position + CameraFacing.transform.forward * distance);
			rootTransform.Rotate(90.0f, 0.0f, 0.0f);
		}
		
		if (Input.GetKeyUp (KeyCode.B)) {
			currentObject = null;
		}
	}

	public bool comboPressed(KeyCode meta, KeyCode key) {
		if (Input.GetKey (meta) && Input.GetKeyDown (key)) {
			return true;
		}
		return false;
	}
}
