using UnityEngine;
using System.Collections;

public class TerrainSwitchScript : MonoBehaviour {
	int n = 2;
	int currentIndex = 0;
	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(0, 0, 0);
		//Instantiate(Resources.Load("Terrain0"), pos, Quaternion.identity);
		//GameObject newTerrain = GameObject.FindGameObjectsWithTag ("Terrain") [0];
		int currentIndex = 0;
		Instantiate(Resources.Load("Terrain"+currentIndex));

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			GameObject oldTerrain = GameObject.FindGameObjectsWithTag ("Terrain") [0];
			Destroy(oldTerrain);
			currentIndex = (currentIndex + 1) % 2;
			Instantiate (Resources.Load ("Terrain" + currentIndex));
		}
	}
}
