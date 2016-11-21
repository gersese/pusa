using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{
	const float SCROLL_SPEED = 20.0f;
	const float Y_POSITION = 0.4f;
	const float X_START_POINT = 0.2f;
	const float X_END_POINT = -18.9f;
	const string TAG_SCROLLING_BG = "ScrollingBackground";
	
	Vector3 _startPoint;
	Vector3 _endPoint;
	
	GameObject _scrollingBackground = null;
	
	void Start()
	{
		_scrollingBackground = GameObject.FindGameObjectWithTag(TAG_SCROLLING_BG);
		_startPoint = new Vector3(X_START_POINT, Y_POSITION, 0.0f);
		_endPoint = new Vector3(X_END_POINT, Y_POSITION, 0.0f);
	}
	
	void Update () 
	{
		Scroll();
	}
	
	void Scroll()
	{
		Vector3 currentPosition = _scrollingBackground.transform.localPosition;
		
		if(HasReachedEndPoint(currentPosition))
		{
			currentPosition = _startPoint;
		}
		
		Vector3 direction = Vector3.MoveTowards(currentPosition, _endPoint, (SCROLL_SPEED * Time.deltaTime));
		_scrollingBackground.transform.localPosition = direction;
		
	}
	
	bool HasReachedEndPoint(Vector3 currentPosition)
	{
		if(currentPosition.x == _endPoint.x)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
