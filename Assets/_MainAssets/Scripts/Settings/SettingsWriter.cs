using UnityEngine;
using UnityEngine.UI;

public class SettingsWriter : MonoBehaviour 
{
	[SerializeField]
	Slider _music;

	[SerializeField]
	Slider _audio;

	public void WriteSettings()
	{
		GameDataWriter gameDataWriter = new GameDataWriter();
		GameDataReader gameDataReader = new GameDataReader();

		GameData gameData = new GameData();

		gameData.Effect = float.Parse(_audio.value.ToString());
		gameData.Music = float.Parse(_music.value.ToString());
		gameData.GamesPlayed = gameDataReader.GetGameData().GamesPlayed - 1;
		gameData.BestTime = gameDataReader.GetGameData().BestTime;

		gameDataWriter.WriteGameData(gameData);

		ReturnToMainMenu();
	}

	void ReturnToMainMenu()
	{
		Application.LoadLevel("MainMenuScene");
	}

}
