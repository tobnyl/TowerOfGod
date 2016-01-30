using UnityEngine;
using System.Collections;

public class GrabBlock : MonoBehaviour 
{
	SpringJoint2D joint;
	private Vector2 mousePos;
	public GameObject mousePointPrefab;
	public GameObject spawnedPrefab;
	public GameObject prefabChild;
	public GameObject grabbedBlock;
	public float HoldForce = 1;
	private Rigidbody2D grabbedRB;


	void FixedUpdate(){
		if (Input.GetMouseButton(0))
		{
			if(spawnedPrefab != null){
				spawnedPrefab.transform.position = mousePos;

				if (grabbedRB != null) {
					grabbedRB.velocity = (Vector2)(spawnedPrefab.transform.position - grabbedBlock.transform.position) * HoldForce;
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
				spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
				joint = spawnedPrefab.GetComponent<SpringJoint2D>();
				grabbedBlock = hit.transform.gameObject;
				grabbedRB = grabbedBlock.GetComponent<Rigidbody2D>();
				grabbedRB.gravityScale = 0;
				joint.connectedBody = grabbedRB;
				joint.connectedAnchor = spawnedPrefab.transform.position - grabbedBlock.transform.position;

			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			if(spawnedPrefab != null){
				joint.connectedBody = null;
				joint.connectedAnchor = Vector2.zero;
				grabbedRB.gravityScale = 1;
				grabbedBlock.transform.parent = null;
				grabbedBlock = null;
				Destroy (spawnedPrefab.gameObject);
			}
		}
	}
}
