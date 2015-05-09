using UnityEngine;
using System.Collections;

public class TerrainSwitchScript : MonoBehaviour {
	int n = 2;
	int currentIndex = 0;
	public GameObject plane;
	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(0, 0, 0);


		int currentIndex = 0;
		GameObject map = Instantiate(Resources.Load("Terrain"+currentIndex), new Vector3(0, 0, 0), new Quaternion()) as GameObject;
		Vector3 TS = map.GetComponent<Terrain>().terrainData.size;
		map.transform.position = new Vector3(-TS.x/2, 0, -TS.z/2);
		/* To-DO
		 * next should find the player position and spawn the terrain's center a bit below the player's position
		 * make sure the center of the terrain is almost at the sea-level otherwise need to substract away the ground height
		 */
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			plane.SetActive(false);
			GameObject [] terrains = GameObject.FindGameObjectsWithTag("Terrain");
			if (terrains.Length != 0) {
				GameObject oldTerrain = terrains [0];
				Destroy(oldTerrain);
			}
			currentIndex = (currentIndex + 1) % n;
			GameObject map = Instantiate (Resources.Load ("Terrain" + currentIndex), new Vector3(0, 0, 0), new Quaternion()) as GameObject;
			Vector3 TS = map.GetComponent<Terrain>().terrainData.size;
			map.transform.position = new Vector3(-TS.x/2, 0, -TS.z/2);
		}
		if (Input.GetKeyDown ("2")) {
			plane.SetActive(true);
			GameObject [] terrains = GameObject.FindGameObjectsWithTag("Terrain");
			if (terrains.Length != 0) {
				GameObject oldTerrain = terrains [0];
				Destroy(oldTerrain);
			}
		}
	}
}
