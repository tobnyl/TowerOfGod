using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject TowerTop;
    public float Speed = 5f;
    public float SmoothTime = 0.15f;

    private Vector3 _moveAmount;
    private Vector3 _smoothMoveVelocity;
    private float _heightOver2;
    private float _widthOver2;

    void Start ()
    {
        _heightOver2 = Screen.height/2f;
        _widthOver2 = Screen.width/2f;

    }

	void Update ()
	{
	    var cameraPosition = Camera.main.transform.position;

	    var bottomViewport = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
	    var topViewport = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
	    var viewPortWorldSize = topViewport - bottomViewport;
        Debug.Log(viewPortWorldSize);

        var moveDir = new Vector3(
	        0,
            Input.GetAxisRaw("Vertical"),
	        0).normalized;

        Vector3 targetMoveAmount = moveDir * Speed;
        _moveAmount = Vector3.SmoothDamp(_moveAmount, targetMoveAmount, ref _smoothMoveVelocity, SmoothTime);

        cameraPosition += _moveAmount;

        if (cameraPosition.y - viewPortWorldSize.y / 2f < 0)
        {
            cameraPosition.y = viewPortWorldSize.y/2f;
        }
        else if (cameraPosition.y > TowerTop.transform.position.y)
        {
            cameraPosition.y = TowerTop.transform.position.y;
        }


        Camera.main.transform.position = cameraPosition;
    }
}
