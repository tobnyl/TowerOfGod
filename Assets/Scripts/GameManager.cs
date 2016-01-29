using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// public statics
	public static GameManager Instance;
	public static float HighestPoint = 0;

	// privates
	private const float UPDATE_LATENCY = 0.1f;
	private IEnumerator updateHighestPointRoutine;


	void Awake(){
		if (Instance) Destroy(this);
		else Instance = this;
	}
	void OnEnable(){
		updateHighestPointRoutine = _UpdateHighestPoint();
		StartCoroutine(updateHighestPointRoutine);
	}
	void OnDisable(){
		StopCoroutine(updateHighestPointRoutine);
	}

	private static IEnumerator _UpdateHighestPoint(){
		while (true) {
			GetHighestPoint();
			yield return new WaitForSeconds(UPDATE_LATENCY);
		}
	}
	public static float GetHighestPoint(){
		float highY = 0;
		for (int i = 0; i < Block.AllBlocks.Count; i++) {
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float y = pColl.points[i].y + pColl.transform.position.y;
				if (y > highY) {
					highY = y;
				}
			}
		}
		
		HighestPoint = highY;
		return HighestPoint;
	}
}
