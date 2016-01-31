using UnityEngine;
using System.Collections.Generic;

public class SpawnBlock : MonoBehaviour {
	Block blockScript;
	public static SpawnBlock instance;
	public List<BlockChance> BlockList = new List<BlockChance>();
	[System.Serializable]
	public class BlockChance{
		public GameObject[] Blocks;
		public float Chance = 0;
	}
	public GameObject nextSpawnPoint;
	public GameObject currentSpawnPoint;
	public GameObject nextBlockPrefab;
	public GameObject currentBlock;
	public GameObject cam;
	public int rand;
	public int nextBlock;

	public static float SpawnSize = 0.5f;


	// Use this for initialization
	void Start () {
		BlockSpawn ();
		BlockSpawn ();
		if (instance) Destroy(this);
		else instance = this;
	}
	
	public void BlockSpawn(){
		if (currentBlock != null) {
			currentBlock.transform.position = currentSpawnPoint.transform.position;
			blockScript = currentBlock.GetComponent<Block>();
			blockScript.Interactive = true;
		}
		rand = Random.Range (0, 100);
		float closest = 10000;
		GameObject closestObj = null;
		foreach (BlockChance bChance in BlockList) {
			if (Mathf.Abs (rand - bChance.Chance) < closest) {
				closest = Mathf.Abs (rand - bChance.Chance);
				closestObj = bChance.Blocks[Random.Range(0, bChance.Blocks.Length)];
			}
		}

		if (closestObj != null) {
			nextBlockPrefab = closestObj;
			nextBlock = rand;
			currentBlock = Instantiate(nextBlockPrefab, nextSpawnPoint.transform.position, Quaternion.identity) as GameObject;
			currentBlock.transform.gameObject.transform.parent = cam.transform;
			
			currentBlock.transform.localScale *= SpawnSize;
			currentBlock.GetComponent<Block>().SpawnAngle = Random.value < 0.25f ? 0 : Random.value < 0.5f ? 90 : Random.value < 0.75 ? 180 : -90;
			currentBlock.transform.eulerAngles = new Vector3(currentBlock.transform.eulerAngles.x, currentBlock.transform.eulerAngles.y, currentBlock.GetComponent<Block>().SpawnAngle);
		}
	}
}

