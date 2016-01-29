using UnityEngine;
using System.Collections;

public class GrabBlock : MonoBehaviour 
{
//	private RaycastHit hit;
	private Vector2 mousePos;
	public GameObject mousePointPrefab;
	public GameObject spawnedPrefab;
	public GameObject prefabChild;
	public GameObject grabbedBlock;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);

		RaycastHit hit;
		if (Input.GetMouseButton(0))
		{
			if(spawnedPrefab != null){
				
				spawnedPrefab.transform.position = Vector2.Lerp(transform.position, mousePos, 1000f);
			}

		}
		if (Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray, out hit) == true)
			{
				Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.red);
				Debug.Log ("Ray hit a " + hit.transform.gameObject.name);
				spawnedPrefab = Instantiate(mousePointPrefab, hit.point, Quaternion.identity) as GameObject;
				hit.transform.parent = spawnedPrefab.transform;
				grabbedBlock = hit.transform.gameObject;
			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			if(spawnedPrefab != null){
				grabbedBlock.transform.parent = null;
				Destroy (spawnedPrefab.gameObject);
			}
		}
	}
}
