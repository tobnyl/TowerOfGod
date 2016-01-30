using UnityEngine;

public class AutoKillParticleSystem : MonoBehaviour {

	private ParticleSystem pSys;

	void Start(){
		pSys = GetComponent<ParticleSystem>();
	}
	void Update(){
		if (!pSys.IsAlive()) {
			Destroy(gameObject);
		}
	}
}
