using UnityEngine;
using System.Collections;

public class GrabBlock : MonoBehaviour 
{
	SpringJoint2D joint;
	Block block;
	private Vector2 mousePos;
	public GameObject mousePointPrefab;
	public GameObject spawnedPrefab;
	public GameObject prefabChild;
	public static GameObject GrabbedBlock;
	public float HoldForce = 1;
	private Rigidbody2D grabbedRB;
	private Collider2D coll;


	void FixedUpdate(){
		if (Input.GetMouseButton(0))
		{
			if(spawnedPrefab != null){
				spawnedPrefab.transform.position = mousePos;

				if (grabbedRB != null) {
					//grabbedRB.velocity = spawnedPrefab.GetComponent<Rigidbody2D>().velocity;
					//grabbedRB.velocity = (Vector2)(spawnedPrefab.transform.position - GrabbedBlock.transform.position) * HoldForce;
				}
			}
		}
	}
	
	void Update () 
	{ 
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		RaycastHit2D hit;
		if (Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(new Vector2(worldPoint.x, worldPoint.y), Vector3.forward, Mathf.Infinity);
			if(hit.transform != null)
			{
				block = hit.transform.GetComponent<Block>();
				if (block != null) {
					if (block.interactable){
						spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
						GrabbedBlock = hit.transform.gameObject;
						joint = GrabbedBlock.GetComponent<SpringJoint2D>();
						coll = GrabbedBlock.GetComponent<Collider2D> ();
						coll.isTrigger = false;
						GrabbedBlock.layer = 0;
						grabbedRB = GrabbedBlock.GetComponent<Rigidbody2D>();
						grabbedRB.isKinematic = false;
						joint.connectedBody = spawnedPrefab.GetComponent<Rigidbody2D>();
						joint.anchor = spawnedPrefab.transform.position - GrabbedBlock.transform.position;
					}
				}
			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			if(spawnedPrefab != null){
				joint.enabled = false; // this fixing a major bug (I guess we won't need it anyway?)

				block.interactable = false;
				block.inPlay = true;
				GrabbedBlock.transform.parent = null;
				GrabbedBlock = null;
				SpawnBlock.instance.BlockSpawn();
				Destroy (spawnedPrefab.gameObject);
			}
		}
	}
}
