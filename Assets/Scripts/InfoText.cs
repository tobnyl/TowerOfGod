using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
public Text scoreText;
public GameObject cam;
public bool score;

// Use this for initialization
void Start () {
	
}

// Update is called once per frame
void Update () {
	if (score) {
			scoreText.text = "" + Mathf.RoundToInt(GameManager.GetHighestPoint()) + "";
	}
	Debug.Log (GameManager.Instance.HighestPoint);
}
}
