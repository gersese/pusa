using UnityEngine;

public class GameDataWriter
{
	public void WriteGameData(GameData gameData)
	{
		GameDataChecker gameDataChecker = new GameDataChecker();

		if(!PlayerPrefs.HasKey("gs^2_catastrophe_bestTime"))
		{
			PlayerPrefs.SetString("gs^2_catastrophe_bestTime", "00:00");
		}

		if(gameDataChecker.IsCurrentScoreHigher(gameData.Highscore))
		{
			PlayerPrefs.SetInt("gs^2_catastrophe_highscore", gameData.Highscore);
		}
		if(gameDataChecker.IsElapsedTimeLonger(gameData.BestTime))
		{
			PlayerPrefs.SetString("gs^2_catastrophe_bestTime", gameData.BestTime);
		}
		
		PlayerPrefs.SetInt("gs^2_catastrophe_coins", (PlayerPrefs.GetInt("gs^2_catastrophe_coins") + gameData.Coins));
		PlayerPrefs.SetFloat("gs^2_catastrophe_audio", gameData.Effect);
		PlayerPrefs.SetFloat("gs^2_catastrophe_music", gameData.Music);
		PlayerPrefs.SetInt("gs^2_catastrophe_games_played", (PlayerPrefs.GetInt("gs^2_catastrophe_games_played") + 1));
	}
}
