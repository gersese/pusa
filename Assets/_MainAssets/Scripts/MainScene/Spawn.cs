using UnityEngine;

public class Spawn : MonoBehaviour 
{
	protected int SECONDS_TO_SPAWN_HEAL = 15;
	
	protected BoxCollider2D _spawnPoint;

	protected GameObject _enemy;

	[SerializeField]
	protected GameObject[] _powerupList = new GameObject[3];

	[SerializeField]
	protected GameObject _coin;

	[SerializeField]
	protected GameObject _heal;

	protected virtual void SpawnObject(){}

	protected virtual bool WillSpawn(){ return true; }

	protected Vector3 GetRandomizedSpawnPosition()
	{ 
		float spawnY = Random.Range(0, 1.0f);
		Vector3 spawnPosition = new Vector3(1.0f, spawnY, 0);
		spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
		spawnPosition.z = 0.0f;

		return spawnPosition;
	}
}
