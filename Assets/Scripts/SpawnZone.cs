using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour {
	public GrabBlock gb;
	public GameObject Cam;

	// Use this for initialization
	void Start () {
		gb = Cam.GetComponent<GrabBlock> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Joint") {
			gb.inSpawn = true;
			Debug.Log ("Enter OnTriggerEnter2D");
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Joint") {
			gb.inSpawn = false;
			Debug.Log ("Exit OnTriggerExit2D");
		}
	}
}
