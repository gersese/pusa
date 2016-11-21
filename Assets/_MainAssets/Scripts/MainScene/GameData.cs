using UnityEngine;

public class GameData 
{
	int coins = 0;
	int highscore = 0;
	int gamesPlayed = 0;
	string bestTime = "";
	float effect = 0.00f;
	float music = 0.00f;

	public string BestTime 
	{
		get {return bestTime;}
		set {bestTime = value;}
	}

	public float Effect 
	{
		get {return effect;}
		set {effect = value;}
	}

	public float Music 
	{
		get {return music;}
		set {music = value;}
	}

	public int Coins 
	{
		get {return coins;}
		set {coins = value;}
	}


	public int Highscore 
	{
		get {return highscore;}
		set {highscore = value;}
	}


	public int GamesPlayed 
	{
		get {return gamesPlayed;}
		set {gamesPlayed = value;}
	}
}
