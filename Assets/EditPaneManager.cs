using UnityEngine;
using System.Collections;

public class EditPaneManager : MonoBehaviour {
	public GameObject lookCamera;
	GameObject currentObject;
	bool editMode = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (comboPressed (KeyCode.LeftAlt, KeyCode.N)) {
			// spawn new window
			Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 3;
			GameObject pane = Instantiate(Resources.Load("EditorPane"), pos, lookCamera.transform.rotation) as GameObject;
			pane.GetComponentInChildren<Canvas>().worldCamera = lookCamera.GetComponent<Camera>();
		}

		if (comboPressed (KeyCode.LeftAlt, KeyCode.X)) {
			RaycastHit hit;
			if (Physics.Raycast (new Ray(lookCamera.transform.position, lookCamera.transform.forward * 3), out hit)) {
				if (currentObject == null) {
					currentObject = hit.transform.gameObject;
				}
			} else {
				GameObject eventSystem = GameObject.Find("EventSystem");
				BasicLookInputModule blim = eventSystem.GetComponent<BasicLookInputModule>();
				if (currentObject == null) { 
					currentObject = blim.currentRaycastObject;
				}
			}

			Destroy(currentObject.transform.root.gameObject);
			currentObject = null;
		}

		if (comboPressed (KeyCode.K, KeyCode.L)) {
			Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 3;
			Instantiate(Resources.Load("tile"), pos, new Quaternion());
		}

		if (Input.GetKey (KeyCode.I)) {
			editMode = true;
			Debug.Log(editMode);
		}

		if (Input.GetKey(KeyCode.Escape)) {
			editMode = false;
			Debug.Log(editMode);
		}

		if (Input.GetKey (KeyCode.LeftAlt) && Input.GetKey(KeyCode.B)) {
			// drag windows around
			// find distance btwn look and window

			RaycastHit hit;
			if (Physics.Raycast (new Ray(lookCamera.transform.position, lookCamera.transform.forward * 3), out hit)) {
				if (currentObject == null) {
					currentObject = hit.transform.gameObject;
				}
			} else {
				GameObject eventSystem = GameObject.Find("EventSystem");
				BasicLookInputModule blim = eventSystem.GetComponent<BasicLookInputModule>();
				if (currentObject == null) { 
					currentObject = blim.currentRaycastObject;
				}
			}

			Transform rootTransform = currentObject.transform.root;
			float distance = Vector3.Distance(rootTransform.position, lookCamera.transform.position);
			float xScale = rootTransform.localScale.x;
			float yScale = rootTransform.localScale.y;
			if (Input.GetKey(KeyCode.J) && distance > 1.5) {
				distance -= 0.5f;
			}
			if (Input.GetKey(KeyCode.K)) {
				distance += 0.5f;
			}
			if (Input.GetKey(KeyCode.M)) {
				xScale += 0.0005f;
			}
			if (Input.GetKey(KeyCode.Comma)) {
				xScale -= 0.0005f;
			}

			if (Input.GetKey(KeyCode.U)) {
				yScale += 0.0005f;
			}
			if (Input.GetKey(KeyCode.I)) {
				yScale -= 0.0005f;
			}

			
			rootTransform.position = (lookCamera.transform.position + lookCamera.transform.forward * distance);
			rootTransform.rotation = lookCamera.transform.rotation;
			rootTransform.localScale = new Vector3(xScale, yScale, rootTransform.localScale.z);
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
