using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// public statics
	public static GameManager Instance;
	public float HighestPoint = 0;
	public float HighestX = 0;
	public float LowestX = 0;

	// privates
	private const float UPDATE_LATENCY = 0.1f;
	private IEnumerator updateBoundariesRoutine;


	void Awake(){
		if (Instance) Destroy(this);
		else Instance = this;
	}
	void OnEnable(){
		updateBoundariesRoutine = _UpdateBoundaries();
		StartCoroutine(updateBoundariesRoutine);
	}
	void OnDisable(){
		StopCoroutine(updateBoundariesRoutine);
	}

	private IEnumerator _UpdateBoundaries(){
		while (true) {

			float highY = 0;
			float highX = 0;
			float lowX = 0;

			for (int i = 0; i < Block.AllBlocks.Count; i++) {
				if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
					Debug.Log ("1: " + i);
					continue;
				}
				PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
				for (int o = 0; o < pColl.points.Length; o++) {
					Vector2 v = pColl.points[o] + (Vector2)(pColl.transform.position);
					if (v.y > highY) {
						highY = v.y;
					}
					if (v.x > highX) {
						highX = v.x;
					}
					if (v.x < lowX) {
						lowX = v.x;
					}
				}
			}
			
			HighestPoint = highY;
			HighestX = highX;
			LowestX = lowX;
			Debug.Log (HighestPoint);

			yield return new WaitForSeconds(UPDATE_LATENCY);
		}
	}
	public static float GetHighestPoint(){
		float highY = 0;
		for (int i = 0; i < Block.AllBlocks.Count; i++) {
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock || Block.AllBlocks[i].inPlay == false){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float y = pColl.points[o].y + pColl.transform.position.y;
				if (y > highY) {
					highY = y;
				}
			}
		}
		
		return highY;
	}
	public static float GetHighestX(){
		float highX = 0;
		for (int i = 0; i < Block.AllBlocks.Count; i++) {
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float x = pColl.points[o].x + pColl.transform.position.x;
				if (x > highX) {
					highX = x;
				}
			}
		}
		
		return highX;
	}
	public static float GetLowestX(){
		float lowX = 0;
		for (int i = 0; i < Block.AllBlocks.Count; i++) {
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float x = pColl.points[o].x + pColl.transform.position.x;
				if (x < lowX) {
					lowX = x;
				}
			}
		}
		
		return lowX;
	}
}
