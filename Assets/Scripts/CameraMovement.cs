using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject TowerTop;
    public float Speed = 5f;
    public float SmoothTime = 0.15f;

    private Vector3 _moveAmount;
    private Vector3 _smoothMoveVelocity;


    void Start ()
    {
	
	}

	void Update ()
	{
	    var moveDir = new Vector3(
	        0,
            Input.GetAxisRaw("Vertical"),
	        0).normalized;

        Vector3 targetMoveAmount = moveDir * Speed;
        _moveAmount = Vector3.SmoothDamp(_moveAmount, targetMoveAmount, ref _smoothMoveVelocity, SmoothTime);

        Camera.main.transform.position += _moveAmount;
	}
}
