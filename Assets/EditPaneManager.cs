using UnityEngine;
using System.Collections;

public class EditPaneManager : MonoBehaviour {
	public GameObject lookCamera;
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

		if (comboPressed (KeyCode.K, KeyCode.L)) {
			Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 3;
			Instantiate(Resources.Load("tile"), pos, new Quaternion());
		}

		if (Input.GetKey (KeyCode.LeftAlt) && Input.GetKey(KeyCode.B)) {
			// drag windows around
			// find distance btwn look and window
			GameObject eventSystem = GameObject.Find("EventSystem");
			BasicLookInputModule blim = eventSystem.GetComponent<BasicLookInputModule>();
			GameObject currentObject = blim.currentRaycastObject;
			Transform rootTransform = currentObject.transform.root;
			float distance = Vector3.Distance(rootTransform.position, lookCamera.transform.position);
			if (Input.GetKey(KeyCode.J) && distance > 1.5) {
				distance -= 0.5f;
			}
			if (Input.GetKey(KeyCode.K)) {
				distance += 0.5f;
			}

			rootTransform.position = (lookCamera.transform.position + lookCamera.transform.forward * distance);
			rootTransform.rotation = lookCamera.transform.rotation;
		}
	}

	public bool comboPressed(KeyCode meta, KeyCode key) {
		if (Input.GetKey (meta) && Input.GetKeyDown (key)) {
			return true;
		}
		return false;
	}
}
