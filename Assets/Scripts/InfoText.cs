using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
public Text scoreText;
public GameObject cam;
public bool score;
public GrabBlock gb;

// Use this for initialization
void Start () {
	gb = cam.GetComponent <GrabBlock>();
}

// Update is called once per frame
void Update () {
	if (score) {
			scoreText.text = "Score: " + Mathf.RoundToInt(GameManager.GetHighestPoint()) + "\n Blocks: " + gb.usedBlocks;


	}
	Debug.Log (GameManager.Instance.HighestPoint);
}
}
