using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public GameObject PauseMenu;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0f)
            {
                PauseMenu.active = false;
                Time.timeScale = 1;
                Debug.Log("Game is running");
            }
            else
            {
                PauseMenu.active = true;
                Time.timeScale = 0;
                Debug.Log("Game is paused");
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenu.active = false;
        Time.timeScale = 1;
        Debug.Log("Game is running");
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("HermanMenuTest");
    }
}
