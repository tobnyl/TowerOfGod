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

	public bool InstructionsOn = false;
	public bool CreditsOn = false;




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
		InstructionsOn = !InstructionsOn;

		if(InstructionsOn)
		{
			instructionMenu.enabled = true;
			//instructionText.enabled = true;

			//startText.enabled = false;
			//exitText.enabled = false;
			quitMenu.enabled = false;
			creditMenu.enabled = false;
		}
		else {
			instructionMenu.enabled = false;
		}
	}

	public void CreditPress()
	{
		CreditsOn = !CreditsOn;
		if (CreditsOn) {
			creditMenu.enabled = true;

			//startText.enabled = false;
			//instructionText.enabled = false;
			instructionMenu.enabled = false;
			//exitText.enabled = false;
			quitMenu.enabled = false;
		}
		else {
			creditMenu.enabled = false;
		}
	}

	public void ExitPress()
	{
		startText.enabled = false;
		instructionText.enabled = false;
		creditText.enabled = false;
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
		Application.LoadLevel(1);
	}
	

	public void ExitGame()
	{
		Application.Quit();
	}


}
