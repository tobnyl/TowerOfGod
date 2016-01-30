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
	public GameObject mainSpawnPoint;
	public static GameObject GrabbedBlock;
	public float HoldForce = 1;
	private Rigidbody2D grabbedRB;
	private Collider2D coll;
	public bool inSpawn;
	public int usedBlocks;

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
						block.transform.localScale = Vector3.one;

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

		if (Input.GetMouseButtonUp (0) && !inSpawn) {
			if (spawnedPrefab != null) {
				usedBlocks++;
				joint.enabled = false; // this fixing a major bug (I guess we won't need it anyway?)
				block.interactable = false;
				block.inPlay = true;
				GrabbedBlock.tag = "Block";
				GrabbedBlock.transform.parent = null;
				GrabbedBlock = null;
				SpawnBlock.instance.BlockSpawn ();
				Destroy (spawnedPrefab.gameObject);
			}
		} 
		if (Input.GetMouseButtonUp (0) && inSpawn) {
			GrabbedBlock.transform.localScale = Vector3.one;
			GrabbedBlock.transform.localScale *= SpawnBlock.SpawnSize;

			coll.isTrigger = true;
			GrabbedBlock.layer = 7;
			grabbedRB.isKinematic = true;
			Destroy (spawnedPrefab.gameObject);
			joint.anchor = new Vector2(0f,0f);
			joint.connectedBody = null;
			GrabbedBlock.transform.eulerAngles = new Vector3(0, 0, GrabbedBlock.GetComponent<Block>().SpawnAngle);
			GrabbedBlock.transform.position = mainSpawnPoint.transform.position;

		}
	}
	public void clearUsedBlocks(){
		usedBlocks = 0;
	}
}
