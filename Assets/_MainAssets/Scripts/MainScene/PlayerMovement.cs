using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	const float MAX_SCREEN_RESTRICTION = 0.95f;
	const float MIN_SCREEN_RESTRICTION = 0.05f;
	const float ROTATE_Z_DEGREES = 270.0f;
	const float ROTATE_ANIMATION_SPEED = 100.0f;
	const float ROTATE_DURATION = 7.0f;

	bool _willRotate = false;

	Vector3 _viewPortpoint;

	void Update() 
	{
		if(_willRotate)
		{
			RotatePlayer();
		}
		RestrictMovementOnScreenBounds();
	}

	public void MovePlayer(Vector3 touchPosition)
	{
        transform.position = touchPosition;
	}
	
	void RestrictMovementOnScreenBounds()
	{
		_viewPortpoint = Camera.main.WorldToViewportPoint(transform.position); 
		_viewPortpoint.x = Mathf.Clamp(_viewPortpoint.x, MIN_SCREEN_RESTRICTION, MAX_SCREEN_RESTRICTION);
		_viewPortpoint.y = Mathf.Clamp(_viewPortpoint.y, MIN_SCREEN_RESTRICTION, MAX_SCREEN_RESTRICTION);
		transform.position = Camera.main.ViewportToWorldPoint(_viewPortpoint);
	}

	void RotatePlayer()
	{
		Quaternion rotation = Quaternion.Euler(0, 0, ROTATE_Z_DEGREES);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, 
		                                              rotation, 
		                                              (ROTATE_ANIMATION_SPEED * Time.deltaTime));
		StartCoroutine(ResetRotation());
	}

	public void SetRotate(bool willRotate)
	{
		_willRotate = willRotate;
	}
	
	IEnumerator ResetRotation()
	{
		yield return new WaitForSeconds(ROTATE_DURATION);
		_willRotate = false;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, 
		                                              Quaternion.identity, 
		                                              (ROTATE_ANIMATION_SPEED * Time.deltaTime));
	}
}
