using UnityEngine;

public class PowerupSpawn : Spawn 
{
	float _powerupSpawnPercentage = 5.0f;
	
	void Start()
	{
		InvokeRepeating("SpawnObject", 1, 1);
	}

	protected override void SpawnObject()
	{
		if(WillSpawn())
		{
			Instantiate(GetRandomPowerup(), GetRandomizedSpawnPosition(), Quaternion.identity);
		}
	}

	GameObject GetRandomPowerup()
	{
		return _powerupList[Random.Range(0, _powerupList.Length)];
	}

	protected override bool WillSpawn()
	{
		int factor = Random.Range(0, 100);

		if(_powerupSpawnPercentage >= factor)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
