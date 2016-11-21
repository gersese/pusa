using UnityEngine;

public class InputManager : MonoBehaviour 
{
	const string TAG_PLAYER = "Player";

	PlayerMovement _playerMovement = null;
	Vector3 _touchPosition;

	void Start()
	{
		_playerMovement = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<PlayerMovement>();
	}

	void OnTriggerStay(Collider touchedObject)
	{
		if(TouchedPlayer(touchedObject))
		{
			_touchPosition.z = 0.0f;
			transform.position = _touchPosition;
			_playerMovement.MovePlayer(_touchPosition);
		}
	}

	void Update() 
	{
		if(Touched())
		{
			_touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_touchPosition.z = 0.0f;
			transform.position = _touchPosition;
		}
	}

	bool Touched()
	{
		if(Input.GetMouseButton(0))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool TouchedPlayer(Collider touchedObject)
	{
		if(touchedObject.tag == "Player")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
