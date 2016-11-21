using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	const string STR_UNIT_FORMAT = "00";

	int _minutes = 0;
	int _seconds = 0;

	void Start()
	{
		InvokeRepeating("UpdateTimer", 0, 1);
	}

	void UpdateTimer()
	{
		++_seconds;
			
		if(_seconds == 60)
		{
			++_minutes;
			_seconds = 0;
		}
	}

	public string GetTimeElapsed()
	{
		string minutes = _minutes.ToString(STR_UNIT_FORMAT);
		string seconds = GetSeconds().ToString(STR_UNIT_FORMAT);
		return  minutes + ":" + seconds ;
	}

	public int GetMinutes()
	{
		return _minutes;
	}

	public int GetSeconds()
	{
		return _seconds;
	}
}
