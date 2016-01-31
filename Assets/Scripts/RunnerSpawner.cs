using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunnerSpawner : MonoBehaviour {

	public GameObject RunnerPrefab;
	public bool RunLeft;
	public int MaxAmount = 5;
	public Vector2 Frequency;
	public float Distance = 20;

	private List<Runner> AllSpawned = new List<Runner>();
	private int curAmount = 0;


	void Start(){
		StartCoroutine(_Spawn());
	}
	void Update(){
		for (int i = 0; i < AllSpawned.Count; i++) {
			if (Vector2.Distance(transform.position, AllSpawned[i].transform.position) > Distance) {
				Destroy(AllSpawned[i].gameObject);
				AllSpawned.RemoveAt(i);
			}
		}
	}

	IEnumerator _Spawn(){
		while (true) {
			if (curAmount < MaxAmount) {
				curAmount++;
			
				GameObject obj = Instantiate(RunnerPrefab, transform.position, Quaternion.identity) as GameObject;
				AllSpawned.Add (obj.GetComponent<Runner>());
				AllSpawned[AllSpawned.Count - 1].RunLeft = RunLeft;
				obj.transform.localScale = new Vector3(RunLeft ? 1 : -1, 1, 1);
			}

			yield return new WaitForSeconds(Random.Range(Frequency.x, Frequency.y));
		}
	}
}
