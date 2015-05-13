using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LaunchBar : MonoBehaviour {
	public InputField launchBarField;
	private bool launchBarIsActive;
	public GameObject launchBarObject;
	// Use this for initialization
	void Start () {
		launchBarIsActive = false;
		launchBarObject.SetActive(false);
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent ();
		submitEvent.AddListener (SubmitSearch);
		launchBarField.onEndEdit = submitEvent;
	}
	
	// Update is called once per frame
	void Update () {
		if (comboPressed(KeyCode.LeftAlt, KeyCode.V)) {
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

	private void SubmitSearch(string search) {
		if (Regex.IsMatch(search, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$")) {
			Debug.Log ("Web URl: " + search);
			loadWebContent(search);
		}
		string text = System.IO.File.ReadAllText(Application.dataPath + "\\" + search);
		Debug.Log (text);
	}

	private void loadWebContent(string url) {
		Debug.Log ("Load web content with url :" + url);
	}
}
