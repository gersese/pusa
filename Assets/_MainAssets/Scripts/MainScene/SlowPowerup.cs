using UnityEngine;
using System.Collections;

public class SlowPowerup : Powerup 
{
	const string TAG_ENEMY_MANAGER = "EnemyManager";	
	const float SLOWED_MOVESPEED = 1.0f;
	const float SLOWED_SPAWN = 3.0f;

	float _slowDuration = 8.0f;

	EnemyManager _enemyManager = null;

	void Start()
	{
		_enemyManager = GameObject.FindGameObjectWithTag(TAG_ENEMY_MANAGER).GetComponent<EnemyManager>();
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
		_enemyManager.SlowEnemies(SLOWED_MOVESPEED, SLOWED_SPAWN, _slowDuration);
	}


}
