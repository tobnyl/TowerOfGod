using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour {
	public GrabBlock gb;
	public GameObject Cam;

	void Start () {
		gb = Cam.GetComponent<GrabBlock> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Block>()) {
			gb.inSpawn = true;
			//Debug.Log ("Enter OnTriggerEnter2D");
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.GetComponent<Block>()) {
			gb.inSpawn = false;
			//Debug.Log ("Exit OnTriggerExit2D");
		}
	}
}
