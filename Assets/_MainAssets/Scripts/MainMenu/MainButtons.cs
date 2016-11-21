using UnityEngine;

public class MainButtons : MonoBehaviour 
{
	public void OnClickStart()
	{
		Application.LoadLevel("MainScene");
	}

	public void OnClickStats()
	{
		Application.LoadLevel("StatisticsScene");
	}

	public void OnClickStore()
	{
		Application.LoadLevel("StoreScene");
	}

	public void OnClickSettings()
	{
		Application.LoadLevel("SettingsScene");
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}

	public void OnClickBack()
	{
		Application.LoadLevel("MainMenuScene");
	}
}
