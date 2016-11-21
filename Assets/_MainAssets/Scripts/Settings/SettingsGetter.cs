using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsGetter : MonoBehaviour 
{
	[SerializeField]
	Slider _music;

	[SerializeField]
	Slider _effects;

	void Start()
	{
		GetSettings();
	}

	public void GetSettings()
	{
		GameDataReader gameDataReader = new GameDataReader();
		GameData gameData = gameDataReader.GetGameData();

		_music.value = float.Parse(gameData.Music.ToString());
		_effects.value = float.Parse(gameData.Effect.ToString());

	}
}
