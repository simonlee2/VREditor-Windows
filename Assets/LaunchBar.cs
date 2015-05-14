using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LaunchBar : MonoBehaviour {
	public InputField launchBarField;
	private bool launchBarIsActive;
	public GameObject launchBarObject;
	public GameObject lookCamera;
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
		launchBarObject.SetActive (false);
		launchBarField.DeactivateInputField ();
		launchBarIsActive = false;




		if (search == "new text window") {
			Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 3;
			GameObject pane = Instantiate(Resources.Load("EditorPane"), pos, lookCamera.transform.rotation) as GameObject;
			pane.GetComponentInChildren<Canvas>().worldCamera = lookCamera.GetComponent<Camera>();
		} else if (Regex.IsMatch (search, @"([\da-z])*.txt")) {
			string text = System.IO.File.ReadAllText (Application.dataPath + "\\" + search);
			Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 3;
			GameObject pane = Instantiate(Resources.Load("EditorPane"), pos, lookCamera.transform.rotation) as GameObject;
			pane.GetComponentInChildren<Canvas>().worldCamera = lookCamera.GetComponent<Camera>();
			pane.GetComponentInChildren<EditorInputField>().text = text;
		} else if (Regex.IsMatch(search, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$")) {
			loadWebContent(search);
		}
	}

	private void loadWebContent(string url) {
		Debug.Log ("Web URl: " + url);

		Vector3 pos = lookCamera.transform.position + lookCamera.transform.forward * 5;
		GameObject web = Instantiate(Resources.Load("WebPane"), pos, lookCamera.transform.rotation) as GameObject;
		UWKWebView wv = web.GetComponentInChildren<UWKWebView> ();
		wv.LoadURL (url);
	}
}
