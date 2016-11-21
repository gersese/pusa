using UnityEngine;

public class Coin : Powerup
{
	const string TAG_PLAYER = "Player";
	const string TAG_GAMEMANAGER = "GameManager";
	const string TAG_EFFECTSMANAGER = "EffectsManager";
	const float COIN_MOVE_SPEED_X = 5.00f;

	int _coinValue = 10;

	void Update()
	{
		Move ();
	}

	void OnTriggerEnter(Collider c)
	{
		if(HasAcquiredByPlayer(c.gameObject))
		{
			CoinStash coinStash = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<CoinStash>();
			AudioEffectsManager audioEffectsManager = GameObject.FindGameObjectWithTag(TAG_EFFECTSMANAGER)
				.GetComponent<AudioEffectsManager>();

			coinStash.EarnCoin(_coinValue);
			audioEffectsManager.PlayCoinSound();

			Destroy(gameObject);
		}
	}

	protected override void Move()
	{
		Vector3 direction = new Vector3(-COIN_MOVE_SPEED_X, 0, 0);
		transform.Translate(direction * Time.deltaTime);
	}
	
	protected bool HasAcquiredByPlayer(GameObject objectCollided)
	{
		if(objectCollided.tag == TAG_PLAYER)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}