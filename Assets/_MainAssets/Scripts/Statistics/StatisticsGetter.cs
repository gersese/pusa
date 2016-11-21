using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatisticsGetter : MonoBehaviour 
{
	[SerializeField]
	Text _txtHighscore;

	[SerializeField]
	Text _txtCoins;

	[SerializeField]
	Text _txtBestTime;

	[SerializeField]
	Text _txtGamesPlayed;


	void Start()
	{
		GameDataReader gameDataReader = new GameDataReader ();
		GameData gameData = gameDataReader.GetGameData ();

		_txtHighscore.text = gameData.Highscore.ToString ();
		_txtCoins.text = gameData.Coins.ToString ();
		_txtBestTime.text = gameData.BestTime;
		_txtGamesPlayed.text = gameData.GamesPlayed.ToString();
	}
}
