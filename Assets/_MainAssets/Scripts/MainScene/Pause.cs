using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour 
{
	const string BUTTON_ESCAPE = "Cancel";
	const string TAG_PAUSE_MENU_OBJ = "PauseMenu";
	const string TAG_SCROLLING_BG = "Screen";
	const string TAG_TOUCH = "Touch";

	bool _isPaused = false;
	
	GameObject _pauseMenu = null;
	ScrollingBackground _scrollingBackground = null;
	InputManager _inputManager = null;

	void Start()
	{

		_pauseMenu = GameObject.FindGameObjectWithTag(TAG_PAUSE_MENU_OBJ);
		_scrollingBackground = GameObject.FindGameObjectWithTag(TAG_SCROLLING_BG).GetComponent<ScrollingBackground>();
		_inputManager = GameObject.FindGameObjectWithTag(TAG_TOUCH).GetComponent<InputManager>();
	}

	void Update () 
	{
		if(HasPressed())
		{
			if(_isPaused)
			{
				SetPaused (false);
			}
			else
			{
				SetPaused (true);
			}
		}
	}

	bool HasPressed()
	{
		if(Input.GetButtonDown(BUTTON_ESCAPE))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void SetPaused(bool paused)
	{
		SetPauseMenuActive(true);

		if(paused)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}

		_inputManager.enabled = !paused;
		_scrollingBackground.enabled = !paused;

		_isPaused = paused;
	}

	public void SetPauseMenuActive(bool isActive)
	{
		for(int i = 0; i < _pauseMenu.transform.childCount; i++)
		{
			_pauseMenu.transform.GetChild(i).gameObject.SetActive(isActive);
		}
	}

}
