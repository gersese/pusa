using UnityEngine;

public class AudioEffectsManager : MonoBehaviour
{
	[SerializeField]
	AudioClip _ouch;

	[SerializeField]
	AudioClip _coin;

	AudioSource _audioSource = null;
	
    void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = GetAudioEffectVolume();
	}

	public void PlayDamageAudioEffect()
	{
		PlayEffect(_ouch);
	}

	public void PlayCoinSound()
	{
		PlayEffect(_coin);
	}

	void PlayEffect(AudioClip effect)
	{
		_audioSource.PlayOneShot(effect);
	}

	float GetAudioEffectVolume()
	{
		GameDataReader gameDataReader = new GameDataReader();
		return gameDataReader.GetGameData().Effect;
	}
}

