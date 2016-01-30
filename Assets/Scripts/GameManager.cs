using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// public statics
	public static GameManager Instance;
	public float HighestPoint = 0;
	public float HighestX = 0;
	public float LowestX = 0;

    [Range(0.0f, 20f)]
    public float DestroyBlockThreshold;

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
				if(!Block.AllBlocks[i].inPlay){
					continue;
				}
				if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
					continue;
				}

				PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
				for (int o = 0; o < pColl.points.Length; o++) {
					Vector2 v = pColl.transform.TransformPoint(pColl.points[o]);
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
//			Debug.Log (HighestPoint);

			yield return new WaitForSeconds(UPDATE_LATENCY);
		}
	}
	public static float GetHighestPoint(){
		float highY = 0;
		for (int i = 0; i < Block.AllBlocks.Count; i++) {
			if(!Block.AllBlocks[i].inPlay){
				continue;
			}
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float y = pColl.transform.TransformPoint(pColl.points[o]).y;
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
			if(!Block.AllBlocks[i].inPlay){
				continue;
			}
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float x = pColl.transform.TransformPoint(pColl.points[o]).x;
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
			if(!Block.AllBlocks[i].inPlay){
				continue;
			}
			if(Block.AllBlocks[i] == GrabBlock.GrabbedBlock){
				continue;
			}
			PolygonCollider2D pColl = Block.AllBlocks[i].GetComponent<PolygonCollider2D>();
			for (int o = 0; o < pColl.points.Length; o++) {
				float x = pColl.transform.TransformPoint(pColl.points[o]).x;
				if (x < lowX) {
					lowX = x;
				}
			}
		}
		
		return lowX;
	}
}
