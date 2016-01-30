using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestMenu : MonoBehaviour {

	public Canvas instructionMenu;
	public Canvas creditMenu;
	public Canvas quitMenu;

	public Button startText;
	public Button instructionText;
	public Button creditText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		instructionMenu.enabled = false;
		creditMenu.enabled = false;
		quitMenu.enabled = false;

		instructionMenu = instructionMenu.GetComponent<Canvas>();
		creditMenu = creditMenu.GetComponent<Canvas>();
		quitMenu = quitMenu.GetComponent<Canvas>();

		startText = startText.GetComponent<Button>();
		instructionText = instructionText.GetComponent<Button>();
		creditText = creditText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();


	}

	public void InstructionPress()
	{
		startText.enabled = false;
		instructionText.enabled = false;
		exitText.enabled = false;

		
		instructionMenu.enabled = true;
		creditMenu.enabled = false;
		quitMenu.enabled = false;
	}

	public void CreditPress()
	{
		startText.enabled = false;
		instructionText.enabled = false;
		exitText.enabled = false;

		instructionMenu.enabled = false;
		creditMenu.enabled = true;
		quitMenu.enabled = false;

	}

	public void ExitPress()
	{
		startText.enabled = false;
		instructionText.enabled = false;
		exitText.enabled = false;

		instructionMenu.enabled = false;
		creditMenu.enabled = false;
		quitMenu.enabled = true;
	}

	public void NoExit()
	{
		
		startText.enabled = true;
		instructionText.enabled = true;
		creditText.enabled = true;
		exitText.enabled = true;

		instructionMenu.enabled = false;
		creditMenu.enabled = false;
		quitMenu.enabled = false;
	}





	public void MainLevel ()
	{
		Application.LoadLevel(2);
	}
	

	public void ExitGame()
	{
		Application.Quit();
	}


}
