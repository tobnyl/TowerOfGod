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
    public AudioClip GrabClip;

	void FixedUpdate(){
		if (Input.GetMouseButton(0))
		{
			if(spawnedPrefab != null){
				spawnedPrefab.transform.position = mousePos;
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
					if (block.Interactive)
					{

					    var hitRb = hit.transform.GetComponent<Rigidbody2D>();



					    var vol = 0.05f;// + hitRb.mass / 50f;
					    var pitch = 1.0f - hitRb.mass/20f;
                        Debug.Log("Rb: " + vol + " " + pitch);

                        AudioManager.Instance.Play(GrabClip, vol, vol, pitch, pitch);

                        spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
						GrabbedBlock = hit.transform.gameObject;
						joint = GrabbedBlock.GetComponent<SpringJoint2D>();
						coll = GrabbedBlock.GetComponent<Collider2D> ();
						grabbedRB = GrabbedBlock.GetComponent<Rigidbody2D>();

						joint.enabled = true;
						coll.isTrigger = false;
						GrabbedBlock.layer = 0;
						grabbedRB.isKinematic = false;

						if (block.IsNew) {
							Vector2 dist =  hit.point - (Vector2)block.transform.position;
							dist /= SpawnBlock.SpawnSize;
							block.transform.position = hit.point - dist;
							block.transform.localScale = block.GetComponent<Block>().OriginalScale;
						}

						joint.connectedBody = spawnedPrefab.GetComponent<Rigidbody2D>();
						joint.anchor = GrabbedBlock.transform.InverseTransformPoint(spawnedPrefab.transform.position);
					}
				}
			}
		}

		if (Input.GetMouseButtonUp (0) && !inSpawn) {
			if (spawnedPrefab != null) {
				if (block.IsNew) {
					usedBlocks++;
					block.inPlay = true;
					GrabbedBlock.tag = "Block";
					SpawnBlock.instance.BlockSpawn ();
				}

				joint.enabled = false; // this fixing a major bug (I guess we won't need it anyway?)
				block.IsNew = false;
				if (GameManager.Instance.LockOldBlockInput) {
					block.Interactive = false;
				}

				GrabbedBlock.transform.parent = null;
				GrabbedBlock = null;
				Destroy (spawnedPrefab.gameObject);
			}
		} 
		if (Input.GetMouseButtonUp (0) && inSpawn && block.IsNew) {
			GrabbedBlock.transform.localScale = Vector3.one;
			GrabbedBlock.transform.localScale *= SpawnBlock.SpawnSize;

			coll.isTrigger = true;
			GrabbedBlock.layer = 7;
			grabbedRB.isKinematic = true;
			Destroy (spawnedPrefab.gameObject);
			joint.anchor = new Vector2(0f,0f);
			joint.connectedBody = null;
			GrabbedBlock.transform.eulerAngles = new Vector3(0, 0, GrabbedBlock.GetComponent<Block>().SpawnAngle);
			GrabbedBlock.transform.rotation = Quaternion.identity;
			GrabbedBlock.transform.position = mainSpawnPoint.transform.position;

		}
	}
	public void clearUsedBlocks(){
		usedBlocks = 0;
	}
}
