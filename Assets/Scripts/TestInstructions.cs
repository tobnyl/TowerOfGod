using UnityEngine;
using System.Collections;

public class TestInstructions : MonoBehaviour 
{
	public Transform placeOne;
	public Transform placeTwo;
	public Transform placeThree;
	public Transform placeFour;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void MoveToOne()
	{

		gameObject.transform.position = placeOne.position;

	}

	public void MoveToTwo()
	{

	}

	public void MoveToThree()
	{

	}

	public void MoveToFour()
	{

	}
}
