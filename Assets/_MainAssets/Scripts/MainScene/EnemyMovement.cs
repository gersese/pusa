using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
	const string TAG_DESTROY_POINT = "DestroyPoint";
	const string TAG_ENEMY_MANAGER = "EnemyManager";

	EnemyManager _enemyManager = null;
	CharacterController _enemyController = null;

	void Start () 
	{
		_enemyManager = GameObject.FindGameObjectWithTag(TAG_ENEMY_MANAGER).GetComponent<EnemyManager>();
		_enemyController = GetComponent<CharacterController>();
	}

	void Update () 
	{
		Move();
	}

	void Move()
	{
		Vector3 enemyMoveDirection = new Vector3(-_enemyManager.ManagedEnemyMoveSpeed, 0, 0);
		_enemyController.Move(enemyMoveDirection * Time.deltaTime);
	}

}