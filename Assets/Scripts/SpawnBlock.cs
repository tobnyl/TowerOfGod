using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {
	Block blockScript;
	public static SpawnBlock instance;
	public GameObject[] blockList;
	public GameObject nextSpawnPoint;
	public GameObject currentSpawnPoint;
	public GameObject nextBlockPrefab;
	public GameObject currentBlock;
	public GameObject cam;
	public int bx;
	public int nextBlock;


	// Use this for initialization
	void Start () {
		BlockSpawn ();
		BlockSpawn ();
		if (instance) Destroy(this);
		else instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			BlockSpawn ();
		}
				
	}
	public void BlockSpawn(){
		if (currentBlock != null) {
			currentBlock.transform.position = currentSpawnPoint.transform.position;
			blockScript = currentBlock.GetComponent<Block>();
			blockScript.interactable = true;
		}
		bx = Random.Range (0, blockList.Length);
		nextBlockPrefab = blockList [bx];
		nextBlock = bx;
		currentBlock = Instantiate(nextBlockPrefab, nextSpawnPoint.transform.position, Quaternion.identity) as GameObject;
		currentBlock.transform.gameObject.transform.parent = cam.transform;
	}
}

