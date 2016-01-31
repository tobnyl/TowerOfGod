using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public SpriteRenderer JewelRenderer;
	public SpriteRenderer GodRenderer;
	public Animator Anim;
	public Sprite Neutral;
	public Sprite Happy;
	public Sprite Angry;
	public RuntimeAnimatorController Laughing;
	public RuntimeAnimatorController Raging;
	public Color JewelNeutral;
	public Color JewelHappy;
	public Color JewelLaugh;
	public Color JewelAngry;
	public Color JewelRage;

	public bool test;

	private int previousScore = 0;

	
	void Start () {
		StartCoroutine(_Update());
	}
//	void Update(){
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			// laugh
//			Anim.SetBool("Laugh", true);
//
//			JewelRenderer.color = JewelLaugh;
//			previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
//			
//		}
//		if (Input.GetKeyDown(KeyCode.C)) {
//			// roaring
//			Anim.SetBool("Rage", true);
//
//			JewelRenderer.color = JewelRage;
//			previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
//			
//		}
//	}

	IEnumerator _Update(){
		while (true) {
//			if (Mathf.RoundToInt(GameManager.Instance.HighestPoint) == previousScore) {
//				// neutral
//				GodRenderer.sprite = Neutral;
//				JewelRenderer.color = JewelNeutral;
//				previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
//				
//				yield return null;
//				continue;
//			}


			if (GameManager.Instance.HighestPoint == 0) {
				// happy
				Anim.enabled = false;

				GodRenderer.sprite = Angry;
				JewelRenderer.color = JewelAngry;
				previousScore = 0;
				
				yield return new WaitForSeconds(1f);
				continue;
			}
			
			if (Mathf.RoundToInt(GameManager.Instance.HighestPoint) >= GameManager.Instance.HighScore) {
				if (Mathf.RoundToInt(GameManager.Instance.HighestPoint) - previousScore > 3) {
					Anim.enabled = true;

					// laugh
					Anim.SetBool("Laugh", true);

					JewelRenderer.color = JewelLaugh;
					previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
					
					yield return new WaitForSeconds(3f);
					Anim.SetBool("Laugh", false);
					continue;
				}
				else {
					// happy
					Anim.enabled = false;

					GodRenderer.sprite = Happy;
					JewelRenderer.color = JewelHappy;
					previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
					
					yield return new WaitForSeconds(1f);
					continue;
				}
			}
			else {
				if (Mathf.RoundToInt(GameManager.Instance.HighestPoint) - previousScore < -1) {
					// roaring
					Anim.enabled = true;

					Anim.SetBool("Rage", true);

					JewelRenderer.color = JewelRage;
					previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
					
					yield return new WaitForSeconds(3f);
					Anim.SetBool("Rage", false);
					continue;
				}
				else {
					// angry
					Anim.enabled = false;

					GodRenderer.sprite = Angry;
					JewelRenderer.color = JewelAngry;
					previousScore = Mathf.RoundToInt(GameManager.Instance.HighestPoint);
					
					yield return new WaitForSeconds(1f);
					continue;
				}
			}


			yield return null;
		}
	}
}
