using UnityEngine;
using System.Collections;

public class TerrainSwitchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(0, 0, 0);
		//Instantiate(Resources.Load("Terrain0"), pos, Quaternion.identity);
		Instantiate(Resources.Load("Terrain0"));
		GameObject newTerrain = GameObject.FindGameObjectsWithTag ("Terrain") [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
