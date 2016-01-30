using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject TowerTop;
    public GameObject TowerLeftBlock;
    public GameObject TowerRightBlock;
    public float Speed = 5f;
    public float SmoothTime = 0.15f;
	public float TwrTopThreshold;

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

        

        // Vertical
		var towerTopPositionY = GameManager.GetHighestPoint();
        Debug.Log("Towertop: " + towerTopPositionY);

		if (towerTopPositionY > TwrTopThreshold)
	    {
	        var tempMoveY = cameraPosition.y += _moveAmount.y;

            Debug.Log("Yes");

	        if (tempMoveY - _viewPortWorldSize.y/2f < 0)
	        {
                tempMoveY = _viewPortWorldSize.y/2f;
	            Debug.Log("Lowest point...");
	        }
	        else if (tempMoveY > towerTopPositionY)
	        {
                tempMoveY = towerTopPositionY;
	            Debug.Log("Highest point...");
	        }
	        else
	        {
	            _moveAmount.y = 0;
	        }

            cameraPosition.y += _moveAmount.y;
        }

	    cameraPosition.y = Mathf.Clamp(cameraPosition.y, _viewPortWorldSize.y / 2f, Mathf.Max(_viewPortWorldSize.y/2f, towerTopPositionY));

	    // Horizontal
	    var towerLeftBlock = GameManager.GetLowestX();
	    var towerRightBlock = GameManager.GetHighestX();

        cameraPosition.x += _moveAmount.x;

        if (cameraPosition.x < towerLeftBlock)
        {
            cameraPosition.x = towerLeftBlock;
        }
        else if (cameraPosition.x > towerRightBlock)
        {
            cameraPosition.x = towerRightBlock;
        }


	    Camera.main.transform.position = cameraPosition;
    }
}
