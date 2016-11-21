using UnityEngine;

public class MusicManager : MonoBehaviour
{
	AudioSource _music = null;

	void Start ()
	{
		_music = GetComponent<AudioSource>();
		_music.volume = GetMusicVolume();
	}
		
	float GetMusicVolume()
	{
		GameDataReader gameDataReader = new GameDataReader();
		return gameDataReader.GetGameData().Music;
	}
}

