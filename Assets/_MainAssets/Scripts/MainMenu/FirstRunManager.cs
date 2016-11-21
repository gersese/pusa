using UnityEngine;

public class FirstRunManager : MonoBehaviour 
{
	void Start () 
	{
		if(!PlayerPrefs.HasKey("gs^2_catastrophe_firstRun"))
		{
			GameDataWriter gameDataWriter = new GameDataWriter();

			GameData gameData = new GameData();

			gameData.Music = 1;
			gameData.Effect = 1;
			gameData.Coins = 0;
			gameData.BestTime = "00:00";
			gameData.GamesPlayed = 0;
			gameData.Highscore = 0;

			PlayerPrefs.SetInt("gs^2_catastrophe_firstRun", 1);

			gameDataWriter.WriteGameData(gameData);
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
