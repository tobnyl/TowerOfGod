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
					grabbedRB.velocity = (Vector2)(spawnedPrefab.transform.position - GrabbedBlock.transform.position) * HoldForce;
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
				block = hit.transform.gameObject.GetComponent<Block>();
				if (block.interactable){
				spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
				joint = spawnedPrefab.GetComponent<SpringJoint2D>();
				GrabbedBlock = hit.transform.gameObject;
				coll = GrabbedBlock.GetComponent<Collider2D> ();
				coll.isTrigger = false;
				grabbedRB = GrabbedBlock.GetComponent<Rigidbody2D>();
				grabbedRB.isKinematic = false;
				grabbedRB.gravityScale = 0;
				joint.connectedBody = grabbedRB;
				joint.connectedAnchor = spawnedPrefab.transform.position - GrabbedBlock.transform.position;
				}

			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			if(spawnedPrefab != null){
				block.interactable = false;
				joint.connectedBody = null;
				joint.connectedAnchor = Vector2.zero;
				grabbedRB.gravityScale = 1;
				GrabbedBlock.transform.parent = null;
				GrabbedBlock = null;
				SpawnBlock.instance.BlockSpawn();
				Destroy (spawnedPrefab.gameObject);
			}
		}
	}
}
