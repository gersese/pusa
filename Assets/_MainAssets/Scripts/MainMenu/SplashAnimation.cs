using UnityEngine;

public class SplashAnimation : MonoBehaviour 
{
	const float MOVE_SPEED = 50.0f;
	const float Y_BOTTOM_TARGET = -32.0f;
	const float Y_UPPER_TARGET = 60.0f;

	float _xPosition = 0.0f;
	float _yTarget = 0.0f;

	void Start()
	{
		_xPosition = transform.localPosition.x;
		_yTarget = Y_UPPER_TARGET;
	}

	void Update () 
	{
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, 
		                                              new Vector3(_xPosition, _yTarget, 0), 
		                                              (MOVE_SPEED * Time.deltaTime));

		if(transform.localPosition.y == Y_UPPER_TARGET)
		{
			_yTarget = Y_BOTTOM_TARGET;
		}
		else if(transform.localPosition.y == Y_BOTTOM_TARGET)
		{
			_yTarget = Y_UPPER_TARGET;
		}
	}
}
