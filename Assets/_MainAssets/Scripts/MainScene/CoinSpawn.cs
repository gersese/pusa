using UnityEngine;

public class CoinSpawn : Spawn 
{
	const float COIN_SPAWN_TIME = 0.55f;

	void Start () 
	{
		InvokeRepeating("SpawnObject", 1, COIN_SPAWN_TIME);
	}

	protected override void SpawnObject()
	{
		Instantiate(_coin, GetRandomizedSpawnPosition(), Quaternion.identity);
	}
}
