using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkyBoxSwitchScript : MonoBehaviour {
	int currentIndex = 1;
    List<string> skyboxes = new List<string>();
	// Use this for initialization
	void Start () {
		skyboxes.Add ("sunrise");
		skyboxes.Add ("room");
	}
	
	// Update is called once per frame
	void Update () {
		//new Tuple<string, string>("Hello", "World"),
		//new Tuple<string, string>("Foo", "Bar")
		if (Input.GetKeyDown ("1")) {
			//GameObject playerController = GameObject.FindGameObjectWithTag("Player");
			//Skybox skybox = playerController.transform.FindChild("LeftEyeAnchor").GetComponent<Skybox>() as Skybox;
			//skybox.material = Resources.Load ("/Assets/Images/test_skybox_l", typeof(Material)) as Material;
			Skybox skybox_left = GameObject.FindGameObjectWithTag("LeftEye").GetComponent<Skybox>();
			skybox_left.material = Resources.Load (skyboxes[currentIndex]+ "_left") as Material;
			Skybox skybox_right = GameObject.FindGameObjectWithTag("RightEye").GetComponent<Skybox>();
			skybox_right.material = Resources.Load (skyboxes[currentIndex]+ "_right") as Material;
			currentIndex = (currentIndex + 1) % skyboxes.Count;
		}
		//RenderSettings.skybox.ma = test_skybox_left;
	}
}
