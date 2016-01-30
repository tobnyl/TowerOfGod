using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public GameObject cam;
    public bool score;
    private float _highScore;
	public GrabBlock gb;

	// Use this for initialization
	void Start ()
	{
		gb = cam.GetComponent <GrabBlock>();
	    _highScore = 0;
	}

	// Update is called once per frame
	void Update () {

		if (score)
		{
		    var currentScore = Mathf.RoundToInt(GameManager.GetHighestPoint());

		    if (currentScore > _highScore)
		    {
		        _highScore = currentScore;
		    }

			scoreText.text = "Score: " + currentScore + " \n Highscore: " + _highScore + "\n Blocks: " + gb.usedBlocks;
		    
		}
		Debug.Log (GameManager.Instance.HighestPoint);
	}
}
