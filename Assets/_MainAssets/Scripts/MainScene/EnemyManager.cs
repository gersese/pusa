using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	const string TAG_TIMER = "Timer";
	const string TAG_SPAWN_MANAGER = "SpawnManager";
	const float ENEMY_MOVE_SPEED_INCREASE_OVER_TIME = 0.05f;
	const float ENEMY_SPAWN_RATE_INCREASE_OVER_TIME = -0.012f;
	const float MAX_ENEMY_MOVE_SPEED = 24.0f;
	const float MAX_ENEMY_SPAWN_RATE = 0.3f;
	
	float _currentEnemyMoveSpeed = 4.0f;
	float _currentEnemySpawnRate = 0.9f;
	float _enemyMoveSpeedBeforeSlow = 0.0f;
	float _enemySpawnRateBeforeSlow = 0.0f;
	bool _isSlowed = false;

	[SerializeField]
	GameObject _pedoBear;

	[SerializeField]
	GameObject _trollFace;

	EnemySpawn _enemySpawn;
	Timer _timer;
	

	void Start()
	{
		_enemySpawn = GameObject.FindGameObjectWithTag(TAG_SPAWN_MANAGER).GetComponent<EnemySpawn>();
		_timer = GameObject.FindGameObjectWithTag(TAG_TIMER).GetComponent<Timer>();

		_enemySpawn.enabled = true;

		ChangeEnemy();
		
		InvokeRepeating("InvokeIncreaseSpeed", 1, 1);
		InvokeRepeating("ChangeEnemy", 1, 60);
	}
	
	void InvokeIncreaseSpeed()
	{
		if(SpeedsIncreasable())
		{
			_currentEnemyMoveSpeed += ENEMY_MOVE_SPEED_INCREASE_OVER_TIME;
			_currentEnemySpawnRate += ENEMY_SPAWN_RATE_INCREASE_OVER_TIME;
		}
	}
	
	bool SpeedsIncreasable()
	{
		if(_currentEnemySpawnRate > MAX_ENEMY_SPAWN_RATE && _currentEnemyMoveSpeed < MAX_ENEMY_MOVE_SPEED)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void ChangeEnemy()
	{ 
		if(_timer.GetMinutes() == 0)
		{
			_enemySpawn.SetEnemy(_pedoBear);
		}
		else if(_timer.GetMinutes() == 1)
		{
			_enemySpawn.SetEnemy(_trollFace);
		}
	}

	public float ManagedEnemyMoveSpeed
	{
		get{ return _currentEnemyMoveSpeed; }
		set{ _currentEnemyMoveSpeed = value; }
	}
	
	public float ManagedEnemySpawnRate
	{
		get{ return _currentEnemySpawnRate; }
		set{ _currentEnemySpawnRate = value; }
	}

	public void SlowEnemies(float slowedSpeed, float slowedSpawn, float slowDuration)
	{
		if(!_isSlowed)
		{
			_enemyMoveSpeedBeforeSlow = _currentEnemyMoveSpeed;
			_enemySpawnRateBeforeSlow = _currentEnemySpawnRate;
		}
		
		_isSlowed = true;
		
		_currentEnemyMoveSpeed = slowedSpeed;
		_currentEnemySpawnRate = slowedSpawn;

		StartCoroutine(SlowEnemies(slowDuration));
	}

	IEnumerator SlowEnemies(float slowDuration)
	{
		yield return new WaitForSeconds(slowDuration);

		_currentEnemyMoveSpeed = _enemyMoveSpeedBeforeSlow;
		_currentEnemySpawnRate = _enemySpawnRateBeforeSlow;

		_isSlowed = false;
	}

}

