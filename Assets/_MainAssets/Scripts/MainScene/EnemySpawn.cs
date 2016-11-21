using UnityEngine;

public class EnemySpawn : Spawn 
{
	const string TAG_ENEMY_MANAGER = "EnemyManager";
	
	EnemyManager _enemyManager = null;
	float _nextSpawn = 0.00f;
	
	void Start()
	{
		_enemyManager = GameObject.FindGameObjectWithTag(TAG_ENEMY_MANAGER).GetComponent<EnemyManager>();
	}
	
	void Update () 
	{
		SpawnObject();
	}
	
	protected override void SpawnObject()
	{
		if(Time.time > _nextSpawn)
		{
			Instantiate(_enemy, GetRandomizedSpawnPosition(), Quaternion.identity);
			_nextSpawn = Time.time + _enemyManager.ManagedEnemySpawnRate;
		}
	}
	
	public void SetEnemy(GameObject enemy)
	{
		_enemy = enemy;
	}
	
}
