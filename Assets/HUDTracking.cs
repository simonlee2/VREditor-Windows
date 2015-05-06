using UnityEngine;
using System.Collections;

public class HUDTracking : MonoBehaviour {
	public GameObject trackingAnchor;
	private GameObject HUD;
	// Use this for initialization
	void Start () {
		HUD = GameObject.Find ("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = trackingAnchor.transform.position + trackingAnchor.transform.forward * 3 - trackingAnchor.transform.up * 2;
		HUD.transform.position = pos;
		HUD.transform.rotation = trackingAnchor.transform.rotation;
	}
}
