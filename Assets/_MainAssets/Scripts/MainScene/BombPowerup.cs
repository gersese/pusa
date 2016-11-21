using UnityEngine;

public class BombPowerup : Powerup 
{
	const string TAG_ENEMY = "Enemy";
	const string TAG_GAMEMANAGER = "GameManager";
	const int BONUS_SCORE = 500;

	ScoreManager _scoreManager = null;

	void Start()
	{
		_scoreManager = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<ScoreManager>();
	}

	void Update () 
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
		KillAllEnemies();
		
		_scoreManager.IncreaseScore(BONUS_SCORE);
	}

	void KillAllEnemies()
	{
		GameObject[] _enemiesInScene = GetAllEnemies();

		foreach(GameObject enemy in _enemiesInScene)
		{
			Destroy(enemy);
		}
	}

	GameObject[] GetAllEnemies()
	{
		return GameObject.FindGameObjectsWithTag(TAG_ENEMY);
	}
}
