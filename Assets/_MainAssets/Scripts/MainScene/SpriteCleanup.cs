using UnityEngine;

public class SpriteCleanup : MonoBehaviour 
{
	const string TAG_ENEMY = "Enemy";
	const string TAG_POWERUP = "Powerup";
	const string TAG_COIN = "Coin";
	const string TAG_GAMEMANAGER = "GameManager";
	const string TAG_POOP = "Poop";

	ScoreManager _scoreManager = null;

	void Start()
	{
		_scoreManager = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider c)
	{
		if(IsDestroyable(c))
		{
			Destroy(c.gameObject);
		}
	}

	bool IsDestroyable(Collider collidedObject)
	{
		if(collidedObject.tag == TAG_ENEMY)
		{
			_scoreManager.IncreaseScore(50);
			return true;
		}
		else if(collidedObject.tag == TAG_COIN)
		{
			return true;
		}
		else if(collidedObject.tag == TAG_POOP)
		{
			return true;
		}
		else if(collidedObject.tag == TAG_POWERUP)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
