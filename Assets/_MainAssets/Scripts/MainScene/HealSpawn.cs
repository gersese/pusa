using UnityEngine;
using System.Collections;

public class HealSpawn : Spawn
{
	void Start()
	{
		InvokeRepeating("SpawnObject", 1, SECONDS_TO_SPAWN_HEAL);
	}

	protected override void SpawnObject()
	{
		Instantiate(_heal, GetRandomizedSpawnPosition(), Quaternion.identity);
	}

}
