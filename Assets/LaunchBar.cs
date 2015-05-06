using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaunchBar : MonoBehaviour {
	public InputField launchBarField;
	private bool launchBarIsActive;
	public GameObject launchBarObject;
	// Use this for initialization
	void Start () {
		launchBarIsActive = false;
		launchBarObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (comboPressed(KeyCode.Z, KeyCode.X)) {
			if (launchBarIsActive) {
				launchBarObject.SetActive(false);
				launchBarField.DeactivateInputField();
				launchBarIsActive = false;
			} else {
				launchBarObject.SetActive(true);
				launchBarField.ActivateInputField();
				launchBarField.Select();
				launchBarIsActive = true;
			}
		}
	}

	public bool comboPressed(KeyCode meta, KeyCode key) {
		if (Input.GetKey (meta) && Input.GetKeyDown (key)) {
			return true;
		}
		return false;
	}
}
