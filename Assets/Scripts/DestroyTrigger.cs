using UnityEngine;
using System.Collections;

public class DestroyTrigger : MonoBehaviour
{
    public int GameOverThreshold = 20;

    private int _numDestroyedObjects = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (_numDestroyedObjects > GameOverThreshold)
	    {
	        //Debug.Log("Game over!");
	    }
	}
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	    _numDestroyedObjects++;
	}
	public void DestroyAll(){
		GameObject[] Blocks = GameObject.FindGameObjectsWithTag ("Block");
		foreach (GameObject b in Blocks){
			Destroy (b.gameObject);
		}
	}
}
