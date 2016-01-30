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

// Use this for initialization
void Start ()
{
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

        scoreText.text = "" + currentScore + "";
	    highScoreText.text = _highScore.ToString();
	}
	Debug.Log (GameManager.Instance.HighestPoint);
}
}
