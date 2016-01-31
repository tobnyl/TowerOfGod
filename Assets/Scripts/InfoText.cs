using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public GameObject cam;
    public bool score;
	public GrabBlock gb;

	// Use this for initialization
	void Start ()
	{
		gb = cam.GetComponent <GrabBlock>();
	}

	// Update is called once per frame
	void Update () {

		if (score)
		{
		    var currentScore = Mathf.RoundToInt(GameManager.GetHighestPoint());

		    if (currentScore > GameManager.Instance.HighScore)
		    {
				GameManager.Instance.HighScore = currentScore;
		    }

			scoreText.text = "Score: " + currentScore + " \n Highscore: " + GameManager.Instance.HighScore + "\n Blocks: " + gb.usedBlocks;
		    
		}
		//Debug.Log (GameManager.Instance.HighestPoint);
	}
}
