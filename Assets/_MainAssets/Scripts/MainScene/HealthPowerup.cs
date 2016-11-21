using UnityEngine;

public class HealthPowerup : Powerup 
{
	const string TAG_PLAYER = "Player";
	const string TAG_GAMEMANAGER = "GameManager";

	int _additionalHealth = 40;

	GameObject _player = null;
	PlayerHealth _playerHealth = null;
	GameManager _gameManager = null;

	void Start()
	{
		_gameManager = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<GameManager>();
		if(!_gameManager.GameOver)
		{
			_player = GameObject.FindGameObjectWithTag(TAG_PLAYER);
			_playerHealth = _player.GetComponent<PlayerHealth>();
		}
	}

	void Update()
	{
		Move();
	}

	void OnTriggerEnter(Collider c)
	{
		if(HasAcquiredByPlayer(c))
		{
			GetPowerupEffect();
			Destroy(gameObject);
		}
	}

	protected override void GetPowerupEffect()
	{
		_playerHealth.Heal(_additionalHealth);
	}
}
