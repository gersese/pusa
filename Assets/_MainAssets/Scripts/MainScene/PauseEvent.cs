using UnityEngine;

public class PauseEvent : MonoBehaviour 
{
	const string TAG_GAMEMANAGER = "GameManager";

	Pause _pause = null;

	void Start()
	{
		_pause = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<Pause>();
	}

	public void Resume()
	{
		_pause.SetPaused(false);
		_pause.SetPauseMenuActive(false);
	}

	public void Quit()
	{
		Application.LoadLevel("MainMenuScene");
	}
}
