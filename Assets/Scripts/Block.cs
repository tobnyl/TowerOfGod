using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour {

	// public statics
	public static List<Block> AllBlocks = new List<Block>();
	public bool inPlay;
	public float SpawnAngle = 0;
    public GameObject ExplosionPrefab;

	// publics
	public bool interactable = false;


	void OnEnable(){
		AllBlocks.Add (this);
	}
	void OnDisable(){
		AllBlocks.Remove (this);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        var otherBlock = c.gameObject.GetComponent<Block>();
        var otherRigidBody = c.gameObject.GetComponent<Rigidbody2D>();
        var rigidBody = GetComponent<Rigidbody2D>();
       
        if (otherBlock != null) 
        {
            Debug.Log(c.relativeVelocity.magnitude);
            if (gameObject.tag == "Block" && otherBlock.tag == "Block" &&  c.relativeVelocity.magnitude > GameManager.Instance.DestroyBlockThreshold)
            {
                var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
                Destroy(explosion, 1.0f);


                Destroy(c.gameObject);
            }     
        }
    }
}
