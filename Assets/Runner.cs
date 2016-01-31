using UnityEngine;

public class Runner : MonoBehaviour {

	public float MinSpeed = 1;
	public float MaxSpeed = 1;
	public bool RunLeft;
	public Animator Anim;

	private float speed = 0;

	void Start(){
		speed = Random.Range(MinSpeed, MaxSpeed);

		if (Anim) {
			Anim.speed = speed;
		}
	}
	
	void Update () {
		transform.position += ((RunLeft ? Vector3.left : Vector3.right) * speed) * Time.deltaTime;
	}
}
