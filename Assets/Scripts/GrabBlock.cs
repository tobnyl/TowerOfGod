using UnityEngine;
using System.Collections;

public class GrabBlock : MonoBehaviour 
{
//	private RaycastHit hit;
//	Rigidbody2D rbp;
	SpringJoint2D joint;
	private Vector2 mousePos;
	public GameObject mousePointPrefab;
	public GameObject spawnedPrefab;
	public GameObject prefabChild;
	public GameObject grabbedBlock;
	private Rigidbody2D grabbedRB;


	// Use this for initialization
	void Start () 
	{
	
	}

	void FixedUpdate(){
		if (Input.GetMouseButton(0))
		{
			if(spawnedPrefab != null){
				spawnedPrefab.transform.position = mousePos;
			}
			if (grabbedRB != null) {
				grabbedRB.velocity = new Vector2(grabbedRB.velocity.x, grabbedRB.gravityScale * -4);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);

		RaycastHit2D hit;
		if (Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(new Vector2(worldPoint.x, worldPoint.y), Vector3.forward, Mathf.Infinity);
			if(hit.transform != null)
			{
//				Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.red);
//				Debug.Log ("Ray hit a " + hit.transform.gameObject.name);
				spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
				joint = spawnedPrefab.GetComponent<SpringJoint2D>();
				//hit.transform.parent = spawnedPrefab.transform;
				grabbedBlock = hit.transform.gameObject;
				grabbedRB = grabbedBlock.GetComponent<Rigidbody2D>();
				joint.connectedBody = grabbedRB;
				joint.connectedAnchor = spawnedPrefab.transform.position - grabbedBlock.transform.position;
				Debug.Log(joint.connectedBody);
				Debug.Log (joint.connectedAnchor);


//				rbp = spawnedPrefab.GetComponent<Rigidbody2D>();
//				SwitchRigidbodyToParent ();

			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			if(spawnedPrefab != null){
				joint.connectedBody = null;
				joint.connectedAnchor = Vector2.zero;
				grabbedBlock.transform.parent = null;
				grabbedBlock = null;
				Destroy (spawnedPrefab.gameObject);
			}
		}
	}
//	public void SwitchRigidbodyToParent(){
//		rbp.mass = rbc.mass;
//		rbp.gravityScale = rbc.gravityScale;
//		rbp.angularDrag = rbc.angularDrag;
//		rbc.mass = 0f;
//		rbc.gravityScale = 0f;
//		rbc.angularDrag = 0f;
//		rbp.isKinematic = true;
//	}
}
