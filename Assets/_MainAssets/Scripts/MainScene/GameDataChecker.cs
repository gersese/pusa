using UnityEngine;

public class GameDataChecker
{
	const char TIME_UNIT_SEPARATOR = ':';

	GameDataReader _gameDataReader = null;
	GameData _gameData = null;

	public bool IsCurrentScoreHigher(long score)
	{
		_gameDataReader = new GameDataReader();
		_gameData = _gameDataReader.GetGameData();

		if(score > _gameData.Highscore)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public bool IsElapsedTimeLonger(string time)
	{
		_gameDataReader = new GameDataReader();
		_gameData = _gameDataReader.GetGameData();

		string[] currentUnits = time.Split(TIME_UNIT_SEPARATOR);
		string[] longestUnits = _gameData.BestTime.Split(TIME_UNIT_SEPARATOR);
		
		if((GetMinute(currentUnits) >= GetMinute(longestUnits)) && 
		   GetSeconds(currentUnits) > GetSeconds(longestUnits))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	int GetMinute(string[] units)
	{
		return int.Parse(units[0]);
	}

	int GetSeconds(string[] units)
	{
		return int.Parse(units[1]);
	}
}

