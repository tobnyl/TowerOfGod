using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject TowerTop;
    public GameObject TowerLeftBlock;
    public GameObject TowerRightBlock;
    public float Speed = 5f;
    public float SmoothTime = 0.15f;

    private Vector3 _moveAmount;
    private Vector3 _smoothMoveVelocity;
    private float _heightOver2;
    private float _widthOver2;
    private Vector3 _viewPortWorldSize;

    void Start ()
    {
        _heightOver2 = Screen.height/2f;
        _widthOver2 = Screen.width/2f;

        var bottomViewport = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        var topViewport = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        _viewPortWorldSize = topViewport - bottomViewport;
    }

	void Update ()
	{
	    var cameraPosition = Camera.main.transform.position;

        var moveDir = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
	        0).normalized;

        Vector3 targetMoveAmount = moveDir * Speed;
        _moveAmount = Vector3.SmoothDamp(_moveAmount, targetMoveAmount, ref _smoothMoveVelocity, SmoothTime);

        cameraPosition += _moveAmount;

        // Vertical
	    var towerTopPositionY = GameManager.GetHighestPoint();

        if (cameraPosition.y - _viewPortWorldSize.y / 2f < 0)
        {
            cameraPosition.y = _viewPortWorldSize.y/2f;
        }
        else if (cameraPosition.y > towerTopPositionY)
        {
            cameraPosition.y = towerTopPositionY;
        }

        // Horizontal
	    var towerLeftBlock = TowerLeftBlock.transform.position;
	    var towerRightBlock = TowerRightBlock.transform.position;

        if (cameraPosition.x < towerLeftBlock.x)
        {
            cameraPosition.x = towerLeftBlock.x;
        }
        else if (cameraPosition.x > towerRightBlock.x)
        {
            cameraPosition.x = towerRightBlock.x;
        }


	    Camera.main.transform.position = cameraPosition;
    }
}
