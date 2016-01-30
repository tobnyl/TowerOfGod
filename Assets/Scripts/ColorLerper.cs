using UnityEngine;

public class ColorLerper : MonoBehaviour {

	public Material TargetMaterial;
	public Camera TargetCamera;
	public Color StartColor;
	public Color EndColor;
	public Color CameraStartColor;
	public Color CameraEndColor;
	public float LerpTime;

	private float t;


	void Update () {
		TargetMaterial.color = Color.Lerp(StartColor, EndColor, t / LerpTime);
		TargetCamera.backgroundColor = Color.Lerp(CameraStartColor, CameraEndColor, t / LerpTime);

		t += Time.deltaTime;

		if (t >= LerpTime) {
			Destroy(gameObject);
		}
	}
}
