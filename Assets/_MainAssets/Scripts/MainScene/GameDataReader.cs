using UnityEngine;

public class GameDataReader 
{
	public GameData GetGameData()
	{
		GameData gameData = new GameData();

		gameData.Highscore = PlayerPrefs.GetInt("gs^2_catastrophe_highscore");
		gameData.BestTime = PlayerPrefs.GetString("gs^2_catastrophe_bestTime");
		gameData.Coins = PlayerPrefs.GetInt("gs^2_catastrophe_coins");
		gameData.Effect = PlayerPrefs.GetFloat("gs^2_catastrophe_audio");
		gameData.Music = PlayerPrefs.GetFloat("gs^2_catastrophe_music");
		gameData.GamesPlayed = PlayerPrefs.GetInt("gs^2_catastrophe_games_played");

		return gameData;
	}
}
