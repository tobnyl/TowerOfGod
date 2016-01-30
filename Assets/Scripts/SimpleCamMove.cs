using UnityEngine;
using System.Collections;

public class SimpleCamMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.05f, transform.position.z);

		}
		else if(Input.GetKey(KeyCode.S) && transform.position.y >= 0){
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.05f, transform.position.z);

		}
	
	}
}
